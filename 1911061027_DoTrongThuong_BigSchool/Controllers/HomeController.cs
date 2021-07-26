using _1911061027_DoTrongThuong_BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using _1911061027_DoTrongThuong_BigSchool.ViewModels;
using Microsoft.AspNet.Identity;
using PagedList;

namespace _1911061027_DoTrongThuong_BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index(string search)
        {
            var upcommingCourses = _dbContext.Courses
                    .Include(c => c.Lecturer)
                    .Include(c => c.Category)
                    .Where(c => c.DateTime > DateTime.Now && c.IsCanceled == false);


            if (!String.IsNullOrEmpty(search)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                upcommingCourses = _dbContext.Courses
                    .Include(c => c.Lecturer)
                    .Include(c => c.Category)
                    .Where(c => c.DateTime > DateTime.Now && c.IsCanceled == false && c.Category.Name.ToLower().Contains(search.ToLower()));
            }
            
            var viewModel = new CourseViewModel
            {
                UpcommingCourses = upcommingCourses,
                ShowAction = User.Identity.IsAuthenticated,
            };

            return View(viewModel);
        }
    }
}