using _1911061027_DoTrongThuong_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1911061027_DoTrongThuong_BigSchool.Controllers.Api
{
    public class CoursesController : ApiController
    {
        public ApplicationDbContext _dbContext { get; set; }

        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel (int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses.Single(c => c.Id == id && c.LecturerId == userId);

            if (course.IsCanceled)
                return NotFound();

            course.IsCanceled = true;
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Show(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses.Single(c => c.Id == id && c.LecturerId == userId);

            if (!course.IsCanceled)
                return NotFound();

            course.IsCanceled = false;
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
