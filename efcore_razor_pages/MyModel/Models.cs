namespace efcore_razor_pages.MyModel
{
    public class Student
    {
        public int StudentId { get; set; }

        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }
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
}
