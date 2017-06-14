using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using MvcClient.Areas.Courses.Models;
using System.Threading.Tasks;
using System.Net.Http;

namespace MvcClient.Areas.Courses.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses/Courses
        public ActionResult Index()
        {
            return View();
        }


        public static String domain = "http://taiwanuniversitiescourses.azurewebsites.net/";
        public static String queryString = null;


        public async Task<ActionResult> GetNtuBySearchAll(string query = null)
        {
            IEnumerable<NtuCourseModel> ntuCourses = await CoursesControllerUtl.BySearchAllWholeWork<NtuCourseModel>(domain, "ntu", query);
            return PartialView(ntuCourses);
        }


        public async Task<ActionResult> GetNtpuBySearchAll(string query = null)
        {
            IEnumerable<NtpuCourseModel> ntpuCourses = await CoursesControllerUtl.BySearchAllWholeWork<NtpuCourseModel>(domain, "ntpu", query);
            return PartialView(ntpuCourses);
        }


        public async Task<ActionResult> GetNctuBySearchAll(string query = null)
        {
            IEnumerable<NctuCourseModel> nctuCourses = await CoursesControllerUtl.BySearchAllWholeWork<NctuCourseModel>(domain, "nctu", query);
            return PartialView(nctuCourses);
        }


        public async Task<ActionResult> GetNckuBySearchAll(string query = null)
        {
            IEnumerable<NckuCourseModel> nckuCourses = await CoursesControllerUtl.BySearchAllWholeWork<NckuCourseModel>(domain, "ncku", query);
            return PartialView(nckuCourses);
        }

        //[ChildActionOnly]
        public async Task<ActionResult> GetBySearchAll(string college = "NTU", string query = null)
        {
            IEnumerable<AllCollegeCourseModel> AllCollegeCourses = await CoursesControllerUtl.BySearchAllWholeWorkForAll<AllCollegeCourseModel>(domain, "AllCollege", college, query);
            return PartialView(AllCollegeCourses);
        }

        public async Task<ActionResult> GetCourseDetail(string strid)
        {
            AllCollegeCourseModel SingleCourse = await CoursesControllerUtl.ByIdWholeWorkForAll<AllCollegeCourseModel>(domain, "AllCollege", strid);
            return View(SingleCourse);

        }

        public async Task<ActionResult> GetComments(string strid)
        {
            AllCollegeCourseModel SingleCourse = await CoursesControllerUtl.ByIdWholeWorkForAll<AllCollegeCourseModel>(domain, "AllCollege", strid);
            List<Comment> comments = SingleCourse.commentdata;
            return PartialView(comments);
        }

        public async Task<ActionResult> GetRankings(string strid)
        {
            AllCollegeCourseModel SingleCourse = await CoursesControllerUtl.ByIdWholeWorkForAll<AllCollegeCourseModel>(domain, "AllCollege", strid);
            List<Ranking> rankings = SingleCourse.rankingdata;
            return PartialView(rankings);
        }


        [HttpGet]
        public ActionResult PostComment()
        {
            return PartialView();
        }


        [HttpGet]
        public ActionResult PostRanking()
        {
            return PartialView();
        }


        [HttpPost]
        public async Task<ActionResult> PostComment(string strid, Comment comment)
        {
            AllCollegeCourseModel SingleCourse = await CoursesControllerUtl.ByIdWholeWorkForAll<AllCollegeCourseModel>(domain, "AllCollege", strid);
            return PartialView(SingleCourse);
        }



        [HttpPost]
        public async Task<ActionResult> PostRanking(string strid, Ranking ranking)
        {
            AllCollegeCourseModel SingleCourse = await CoursesControllerUtl.ByIdWholeWorkForAll<AllCollegeCourseModel>(domain, "AllCollege", strid);
            return PartialView(SingleCourse);
        }




    }
}