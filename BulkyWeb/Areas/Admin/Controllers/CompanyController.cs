using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }
        public IActionResult Index()
        {
            var Companys = _unitOfWork.Company.GetAll();
            return View(Companys);
        }
        public IActionResult Upsert(int? id)
        {
            if (id is null || id == 0)
            {
                // Create
                return View(new Company());
            }
            
            // Update
            Company Company = _unitOfWork.Company.Get(p => p.Id == id);
            return View(Company);
        }

        [HttpPost]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                    TempData["success"] = "Company created successfully";
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                    TempData["success"] = "Company updated successfully";
                }
                    _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(company);
        }
        //public IActionResult Delete(int id)
        //{
        //    var Company = _unitOfWork.Company.Get(c => c.Id == id);
        //    if (Company is null)
        //    {
        //        return NotFound();
        //    }

        //    return View(Company);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePOST(int id)
        //{
        //    var obj = _unitOfWork.Company.Get(c => c.Id == id);
        //    if (obj is null)
        //    {
        //        return NotFound();
        //    }

        //    _unitOfWork.Company.Remove(obj);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Company deleted successfully";
        //    return RedirectToAction("Index");
        //}

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Company.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyDeleted = _unitOfWork.Company.Get(c => c.Id == id);
            if (CompanyDeleted is null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Company.Remove(CompanyDeleted);
            _unitOfWork.Save();
            TempData["success"] = "Company deleted successfully";
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion

    }
}
