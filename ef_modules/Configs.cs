using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ef_models
{


    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("T_Student");
            builder.Property(x => x.Gender).HasMaxLength(1).IsRequired();
            //builder.Property(x => x.StudentId).HasDefaultValueSql("newid()");
        }
    }
}
