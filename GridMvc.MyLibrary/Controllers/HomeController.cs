using GridMvc.MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GridMvc.MyLibrary.Controllers
{
    public class HomeController : Controller
    {
        private static List<Kisi> _sampleKisiler = null;
        private static int _count = 20;
        // GET: Home
        public ActionResult Index(int? id)
        {
            if (id == null) id = 20;

            if (_sampleKisiler == null || id != _count)
            {
                _count = (int)id;
                _sampleKisiler = Kisi.GetSampleKisiler(_count);
            }

            return View(_sampleKisiler);
        }

        public ActionResult Index2(int? id)
        {
            if (id == null) id = 20;

            if (_sampleKisiler == null || id != _count)
            {
                _count = (int)id;
                _sampleKisiler = Kisi.GetSampleKisiler(_count);
            }

            return View(_sampleKisiler);
        }

        public JsonResult GetKisilerAjax()
        {
            return Json(_sampleKisiler.Select(x => x.FullName).OrderBy(x => x.ToString()));
        }
    }
}