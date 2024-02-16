using efcore_razor_pages.MyModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace efcore_razor_pages.Pages
{
    public class SchoolModel : PageModel
    {
        private readonly SchoolContext _context;

        public SchoolModel(SchoolContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {      

            _context.Database.EnsureCreated();

                //create entity objects
                var grd2 = new Grade() { GradeName = "2st Grade" };
                var std1 = new Student() { FirstName = "James", LastName = "L", Grade = grd2, Gender="M" };

            //add entitiy to the context
            _context.Students.Add(std1);

            //save data to the database tables
            _context.SaveChanges();
          

            Student = await _context.Students
                .Include(s => s.Grade).ToListAsync();
        }
    }
}
