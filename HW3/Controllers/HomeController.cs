using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HW3.Models;

namespace HW3.Controllers
{
    
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Documents = "checked";
            ViewBag.Image = "";
            ViewBag.Video = "";

            return View();
        }


        [HttpPost]
        //HttpPostedFileBase to get the file information uploaded by the user
        public ActionResult Index(HttpPostedFileBase Files, string fileType)
        {
            //If the folder doesn't exist on the user directory then it will be created
            string folderPath = Server.MapPath("~/Media/");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            //Check if the Files object is valid or not 
            if (Files != null && Files.ContentLength > 0)
            {
                //Get file name
                var fileName = Path.GetFileName(Files.FileName);
                //Upload all documents files under the document's folder if document is the checked radio button
                if (fileType == "Documents")
                {
                    ViewBag.Documents = "checked";

                    var path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName);
                    //Get the file path together with the file name
                    var fullPath = Server.MapPath("~/Media/Documents") + Files.FileName;
                    if (System.IO.File.Exists(fullPath))
                    {
                        ViewBag.Message = "Same File already Exists";
                    }
                    else
                    {
                        Files.SaveAs(path);
                        ViewBag.Message = "File has been uploaded successfull";

                    }
                    ViewBag.Image = "";
                    ViewBag.Video = "";
                }

                //Upload all Images files under the image's folder if Image is the checked radio button
                if (fileType == "Image")
                {
                    ViewBag.Image = "checked";
                    var path = Path.Combine(Server.MapPath("~/Media/Image"), fileName);
                    var fullPath = Server.MapPath("~/Media/Image") + Files.FileName;
                    if (System.IO.File.Exists(fullPath))
                    {
                        ViewBag.Message = "Same File already Exists";
                    }
                    else
                    {
                        Files.SaveAs(path);
                        ViewBag.Message = "File has been uploaded successfull";

                    }
                    ViewBag.Documents = "";
                    ViewBag.Video = "";
                }

                //Upload all Videos files under the document's folder if Video is the checked radio button
                if (fileType == "Video")
                {
                    ViewBag.Video = "checked";
                    var path = Path.Combine(Server.MapPath("~/Media/Video"), fileName);
                    var fullPath = Server.MapPath("~/Media/Video") + Files.FileName;
                    if (System.IO.File.Exists(fullPath))
                    {
                        ViewBag.Message = "Same File already Exists";
                    }
                    else
                    {
                        Files.SaveAs(path);
                        ViewBag.ActionMessage = "File has been uploaded successfull";

                    }
                    ViewBag.Documents = "";
                    ViewBag.Image = "";
                }
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
           
            return View();
        }
    }
}