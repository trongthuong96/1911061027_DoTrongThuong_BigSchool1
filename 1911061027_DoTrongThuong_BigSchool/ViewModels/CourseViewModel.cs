using _1911061027_DoTrongThuong_BigSchool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1911061027_DoTrongThuong_BigSchool.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        // update
        public string Heading { get; set; }
        public string Action
        {
            get { return (Id != 0) ? "Update" : "Create"; }
        }

        public DateTime GetDateTime()
        {
            if (Date is null && Time is null)
                return DateTime.Now;
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}