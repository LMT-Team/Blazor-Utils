using System.Collections.Generic;
using System.Linq;

namespace BlazorUtils.WebTest._0._5.Models
{
    public sealed class Student
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public bool IsMale { get; set; }
        public int Age { get; set; }
        private string _Token = "Secret!";
        public List<int> Classes = null;

        public static List<Student> lstStudent()
        {
            return new Student[] {
                new Student{
                    StudentId = "123",
                    Age = 15,
                    IsMale = true,
                    StudentName = "Tim"
            },
                new Student{
                    StudentId = "321",
                    Age = 12,
                    IsMale = true,
                    StudentName = "Jack"
            },
                    new Student{
                    StudentId = "4543",
                    Age = 10,
                    IsMale = false,
                    StudentName = "Laura"
            }
            }.ToList();
        }
    }
}
