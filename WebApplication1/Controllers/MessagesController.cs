using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmailVM model)/*To receive objective "model" then to post it.*/
        {
            //If no file is uploaded, or if file name is null, or file content is 0, then show users errors.
            if ((model.ToAttachFile == null) || (model.ToAttachFile.FileName == null) || (model.ToAttachFile.ContentLength == 0))
            {
                ModelState.AddModelError("ToAttachFile", "Attachments are mandatory.");/*Error 顯示在ToAttachFile旁邊*/
                ModelState.AddModelError(String.Empty, "Attachments are mandatory.");/*Error 顯示在畫面上方*/
                return View(model);
            }
            else
            {
                string path = Server.MapPath(@"~/UploadsAreStoredHere/");/*從根目錄尋找相對路徑*/
                string newFileName = model.ToAttachFile.FileName;/*尋找檔名*/
                string fullStoredPath = System.IO.Path.Combine(path + newFileName);/*fullStoredPath == 檔案要存放的位置*/

                try 
                {
                    model.ToAttachFile.SaveAs(fullStoredPath);/*嘗試存檔*/
                    return RedirectToAction("Index");
                } catch (Exception ex) /*存檔有機會失敗，例如: 權限不足*/
                {
                    ModelState.AddModelError("ToAttachFile", "Your attachment is not uploaded. Reason:" + ex.Message);
                    return View(model);
                }
            }
        }
    }
}
