using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HW3.Models;

namespace HW3.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            string[] ImagePath = Directory.GetFiles(Server.MapPath("~/Media/Image"));
            List<FileModel> files = new List<FileModel>();
            foreach (string filepath in ImagePath)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filepath) });
            }

            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            string path = Path.Combine(Server.MapPath("~/Media/Image"), fileName);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {

            string path = Request.MapPath("~/Media/Image/" + fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return RedirectToAction("Index");
        }
    }
}