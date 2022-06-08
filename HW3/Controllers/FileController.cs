using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HW3.Models;

namespace HW3.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            //String array that will contain the file path of the fetched files using the "Directory.GetFiles()" function
            var path = Server.MapPath("~/Media/Documents");
            string[] folderPath = Directory.GetFiles(path); 
            List<FileModel> files = new List<FileModel>();
            //
            foreach (string filepath in folderPath)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filepath) });
            }
            //Returning the list to the view
            return View(files);
        }

        //Recieved file ("fileName") as a parameter sent to the view
        public FileResult DownloadFile(string fileName)
        {
            //To retrieve the full file path
            string path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName);
            //To read the file data using the ReadAllBytes method passing the string path above
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            //Send and Return the downloaded file
            //System.Net.Mime.MediaTypeNames.Application.Octet to be able to handle any format of files that are downloaded
            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {

            string path = Request.MapPath("~/Media/Documents/" + fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return RedirectToAction("Index");
        }


    }
}