

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace efcore_razor_pages.MyModel
{
    public class Student
    {
        public Guid StudentId { get; set; }

        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }

    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("T_Student");
            builder.Property(x => x.Gender).HasMaxLength(1).IsRequired();
            //builder.Property(x => x.StudentId).HasDefaultValueSql("newid()");
        }
    }

    public class Grade
    {
        public Grade()
        {
            Students = new List<Student>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public IList<Student> Students { get; set; }
    }





    public class Order
    {
        public int OrderId { get; set; }

        public string OrderName { get; set; } = string.Empty;
 
        public Delivery DeliveryObj { get; set; }
    }


    public class Delivery
    {
        public int DeliveryId { get; set; }

        public string DeliveryName { get;set; }

        public Order OrderObj { get; set; }


        public int OrderId { get; set; }

    }



    public class DeliverConfig : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.ToTable("T_Delivery");
            //builder.HasOne(d => d.OrderObj).WithOne(o => o.DeliveryObj).HasForeignKey<Order>(x => x.OrderId);
            builder.HasOne(d => d.OrderObj).WithOne(o => o.DeliveryObj).HasForeignKey<Delivery>(x => x.OrderId);
        }
    }



    public class Teacher
    {
        public int TeacherId { get; set;}
        public string TeacherName { get; set; }

        public List<Xuesheng> Xueshengs { get; set; }
    }


    public class Xuesheng
    {
        public int XueshengId { get; set; }
        public string XueshengName { get; set; }

        public List<Teacher> Teacherss { get; set;}
    }


    public class XueshengConfig : IEntityTypeConfiguration<Xuesheng>
    {
        public void Configure(EntityTypeBuilder<Xuesheng> builder)
        {
            builder.ToTable("T_Xuesheng");

            builder.HasMany(x => x.Teacherss).WithMany(t => t.Xueshengs).UsingEntity(r => r.ToTable("T_Teacher_Xuesheng"));
        }
    }
}
