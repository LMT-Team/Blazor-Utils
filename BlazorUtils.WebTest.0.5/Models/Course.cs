namespace BlazorUtils.WebTest._0._5.Models
{
    public class Course
    {
        public Course(string id, string prof)
        {
            Id = id;
            Prof = prof;
        }

        public string Id { get; set; }
        public string Prof { get; set; }

    }
}
