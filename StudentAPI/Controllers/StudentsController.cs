using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StudentAPI.Models;
//using Spire.Presentation;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Reflection;
using Microsoft.Office.Core;
using System.Runtime.InteropServices;
using System.IO;
using Grpc.Core;
using System.Web;
//using System.Web.Mvc;
namespace StudentAPI.Controllers
{
    [RoutePrefix("Api/Students")]
    public class StudentAPIController : ApiController
    {
        DBModelsNew db = new DBModelsNew();

        [HttpGet]
        [Route("AllStudents")]
        
        //public ActionResult OpenFile()
        //{
        //    //var pathToTheFile =HttpContext.Current.Server.MapPath("C:/Users/praveen.suggula/source/repos/DialCareLegacyAgile/DialCareAdmin.UI/DialCareAdmin.UI/Images/Oktaauth.pptx");
        //    string pathToTheFile = "C:/Users/praveen.suggula/source/repos/DialCareLegacyAgile/DialCareAdmin.UI/DialCareAdmin.UI/Images/Oktaauth.pptx";
        //    var fileStream = new FileStream(pathToTheFile,
        //                                     FileMode.Open,
        //                                     FileAccess.Read
        //                                 );
        //    return new System.Web.Mvc.FileStreamResult(fileStream, MimeMapping.GetMimeMapping("Oktaauth.pptx"));
        //}
        public IQueryable<Studentstbl> GetStudentstbls()
        {
            //PowerPoint.Application pptApplication = null;
            //PowerPoint.Presentation pptPresentation = null;
            //pptApplication = new PowerPoint.Application();

            try
            {
                //Presentation presentation = new Presentation();
                //presentation.LoadFromFile("C:/Users/praveen.suggula/source/repos/DialCareLegacyAgile/DialCareAdmin.UI/DialCareAdmin.UI/Images/Oktaauth.pptx");
                //presentation.SaveToFile("C:/Users/praveen.suggula/source/repos/DialCareLegacyAgile/DialCareAdmin.UI/DialCareAdmin.UI/Images/Oktaauth.pdf", FileFormat.PDF);


                //string originalPptPath = "C:/Users/praveen.suggula/source/repos/DialCareLegacyAgile/DialCareAdmin.UI/DialCareAdmin.UI/Images/Oktaauth.pptx";
                //pptPresentation = pptApplication.Presentations.Open(originalPptPath, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoFalse);


                //string pdfPath = "C:/Users/praveen.suggula/source/repos/DialCareLegacyAgile/DialCareAdmin.UI/DialCareAdmin.UI/Images/Oktaauth.pdf";
                //if (pptPresentation != null && File.Exists(pdfPath) == false)
                //{
                //    pptPresentation.ExportAsFixedFormat(pdfPath, PowerPoint.PpFixedFormatType.ppFixedFormatTypePDF);
                //}
                //else
                //{
                //    Console.WriteLine("Error occured for conversion of office PowerPoint to PDF");
                //}
               

                return db.Studentstbls;
            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{
            //    if (pptPresentation != null)
            //    {
            //        pptPresentation.Close();
                    
            //        pptPresentation = null;
            //    }

            //    pptApplication.Quit();
                
            //    pptApplication = null;
            //}
        }

        [HttpGet]
        [Route("GetStudentsById/{id}")]
        public IHttpActionResult GetStudentstbl(string id)
        {
            Studentstbl objstd = new Studentstbl();
            int ID = Convert.ToInt32(id);
            try
            {
                objstd = db.Studentstbls.Find(ID);
                if (objstd == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(objstd);
        }

        [HttpPost]
        [Route("InsertStudentDetails")]
        public IHttpActionResult PostStudentstbl(Studentstbl data)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Studentstbls.Add(data);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateStudentDetails")]
        public IHttpActionResult PutStudentstbl(Studentstbl students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Studentstbl objStd = new Studentstbl();
                objStd = db.Studentstbls.Find(students.StudentID);
                if (objStd != null)
                {
                    objStd.StudentFirstName = students.StudentFirstName;
                    objStd.StudentLastName = students.StudentLastName;
                    objStd.Gender = students.Gender;
                    objStd.EmailId = students.EmailId;
                    objStd.MobileNumber = students.MobileNumber;
                    objStd.Address = students.Address;
                    objStd.State = students.State;
                    objStd.PinCode = students.PinCode;
                    objStd.DateOfBirth = students.DateOfBirth;

                }
                int i = this.db.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(students);
        }
        [HttpDelete]
        [Route("DeleteStudentDetails")]
        public IHttpActionResult DeleteStudentstbl(int id)
        {
            //int empId = Convert.ToInt32(id);  
            Studentstbl student = db.Studentstbls.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Studentstbls.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }
    }

}