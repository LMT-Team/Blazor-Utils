using System.Collections.Generic;
using System.Linq;
using BlazorUtils.Dom.Attributes;

namespace BlazorUtils.WebTest._0._5.Models
{
    public sealed class Student
    {
        [Head("id")]
        public string StudentId { get; set; }

        [Head("name", 1)]
        public string StudentName { get; set; }

        [Head("is male", 3)]
        public bool IsMale { get; set; }

        [Head("age", 2)]
        public int Age { get; set; }

        [Head("Profile Url", Dom.DomUtils.TagType.a, 4)]
        [Link("Search Id on Bing", "_blank")]
        public string ProfileUrl {
            get => $"https://www.bing.com/search?q={StudentId}";
        }

        [Head("Functions", Dom.DomUtils.TagType.button, 5)]
        [Button("Edit")]
        public string ButtonData
        {
            get => StudentId;
        }

        private string _Token = "Secret!";
        public List<int> Classes = null;
        public Course course;

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
