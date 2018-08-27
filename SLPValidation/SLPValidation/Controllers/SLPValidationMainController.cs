namespace SLPValidation.Controllers
{
    using SLPValidation.Helper;
    using SLPValidation.Models;
    using System;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Authentication]
    public class SLPValidationMainController : Controller
    {
        private SLPEnityDataModels db = new SLPEnityDataModels();

        // GET: SLPValidationMain
        public ActionResult Main()
        {
            ViewData["LoginUser"] = AccountController.GetLoginUser(this);

            return View(db.SLPRequestRecords.ToList());
        }

        public ActionResult Result()
        {
            ViewData["LoginUser"] = AccountController.GetLoginUser(this);

            string requestID = Request.QueryString["RequestID"];
            var result = (from u in db.ValidationResult
                          where u.RequestID == requestID
                          select u).ToList();

            return View(result);
        }

        [HttpPost]
        public ActionResult UploadScannedFile(HttpPostedFileBase uploadScannedFile)
        {
            ResponeMessage resp = new ResponeMessage();

            string fileName = string.Empty;
            if ((uploadScannedFile != null) && (uploadScannedFile.ContentLength > 0))
            {
                // Generate the distinguished file name
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadScannedFile.FileName);
                string saveLocation = @"..\FileUpload\ScannedFile";
                string fullFilePath = Path.Combine(saveLocation, fileName);
                // Get the physical path on server
                fullFilePath = Server.MapPath(fullFilePath);
                uploadScannedFile.SaveAs(fullFilePath);

                string message = string.Empty;
                if (VerifyVisitorInfoFile(fullFilePath, out message))
                {
                    resp.Status = 0;
                    resp.Message = fileName;
                }
                else
                {
                    System.IO.File.Delete(fullFilePath); // 删除上传的文件
                    resp.Status = -1;
                    resp.Message = message;
                }
            }

            return Json(resp);
        }

        [HttpPost]
        public ActionResult SubmitNewRequest()
        {
            string file = Request.Form["ScannedFile"];
            string oppid = Request.Form["OPPID"];

            DbContextTransaction transaction = db.Database.BeginTransaction();

            // Add lock for table PlaceRequestRecords
            string sql = "select * from SLPRequestRecords with(tablockx)";
            db.Database.ExecuteSqlCommand(sql);

            try
            {
                var entity = new SLPRequestRecords();
                entity.RequestID = GetNewRequestID();
                entity.OPPID = oppid;
                entity.RequestDate = DateTime.Now;
                entity.Status = 0;
                entity.ScannedFile = file;

                db.SLPRequestRecords.Add(entity);
                db.SaveChanges();

                transaction.Commit();
                return Json("Success");
            }
            catch(Exception e)
            {
                transaction.Rollback();
                return Json(e.Message);
            }
        }

        private bool VerifyVisitorInfoFile(string path, out string message)
        {
            message = string.Empty;

            return true;
        }

        private string GetNewRequestID()
        {
            string sql = "select max(requestid) from SLPRequestRecords";
            var maxID = db.Database.SqlQuery<string>(sql).First();
            string id = DateTime.Now.ToString("yyyyMMdd") + "0001";

            if (maxID == null || long.Parse(maxID) < long.Parse(id)) // 没有当天的申请记录
            {
                return id;
            }
            else // 在当天的最大记录基础上增加1
            {
                return (long.Parse(maxID) + 1).ToString();
            }            
        }
    }

    /// <summary>
    /// A class for response message
    /// </summary>
    public class ResponeMessage
    {
        public int Status { get; set; }

        public string Message { get; set; }
    }
}
