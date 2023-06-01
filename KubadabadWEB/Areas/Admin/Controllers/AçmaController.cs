using Kubadabad.DataAccess.Repository.IRepository;
using Kubadabad.Models;
using Kubadabad.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Kubadabad.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class AçmaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AçmaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<AçmaListesi> objAçmaListesi = _unitOfWork.AçmaListesi.GetAll().ToList();
            return View(objAçmaListesi);
        }

        [HttpGet]
        public IActionResult AçmaOluştur()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AçmaOluştur(AçmaListesi obj)
        {
            _unitOfWork.AçmaListesi.Add(obj);
            _unitOfWork.Save();
            TempData["Başarılı"] = "Açma Başarıyla Oluşturuldu.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AçmaDüzenle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            AçmaListesi? açmaFromDb = _unitOfWork.AçmaListesi.Get(u => u.Id == id);
            if (açmaFromDb == null)
            {
                return NotFound();
            }
            return View(açmaFromDb);
        }
        [HttpPost]
        public IActionResult AçmaDüzenle(AçmaListesi obj)
        {
            _unitOfWork.AçmaListesi.Update(obj);
            _unitOfWork.Save();
            TempData["Başarılı"] = "Açma Başarıyla Güncellendi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AçmaSil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            AçmaListesi açmaFromDb = _unitOfWork.AçmaListesi.Get(u => u.Id == id);
            if (açmaFromDb == null)
            {
                return NotFound();
            }
            return View(açmaFromDb);
        }
        [HttpPost, ActionName("AçmaSil")]
        public IActionResult AçmaSilPOST(int? id)
        {
            AçmaListesi obj = _unitOfWork.AçmaListesi.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.AçmaListesi.Remove(obj);
            _unitOfWork.Save();
            TempData["Başarılı"] = "Açma Başarıyla Silindi.";
            return RedirectToAction("Index");
        }       
    }
}
