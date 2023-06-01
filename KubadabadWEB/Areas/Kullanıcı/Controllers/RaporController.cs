using Kubadabad.DataAccess.Repository.IRepository;
using Kubadabad.Models;
using Kubadabad.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kubadabad.Areas.Kullanıcı.Controllers
{
    [Area("Kullanıcı")]
    public class RaporController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public RaporController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<AçmaRapor> objRapor = _unitOfWork.AçmaRapor.GetAll(includeProperties: "AçmaListesi").ToList();
            return View(objRapor);
        }
        public IActionResult Details(int id)
        {
            AçmaRapor objRapor = _unitOfWork.AçmaRapor.Get(u => u.RaporId == id, includeProperties: "AçmaListesi");
            return View(objRapor);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            RaporVM raporVM = new()
            {
                AçmaList = _unitOfWork.AçmaListesi.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AçmaAdı,
                    Value = u.Id.ToString()
                }),
                AçmaRapor = new AçmaRapor()
            };
            if (id == null || id == 0)
            {
                //create
                return View(raporVM);
            }
            else
            {
                //update
                raporVM.AçmaRapor = _unitOfWork.AçmaRapor.Get(u => u.RaporId == id);
                return View(raporVM);
            }
            return View(raporVM);
        }
        [HttpPost]    
        public IActionResult Upsert(RaporVM obj)
        {     
            if (obj.AçmaRapor.RaporId == 0)
            {
                _unitOfWork.AçmaRapor.Add(obj.AçmaRapor);
                TempData["Başarılı"] = "Rapor Başarıyla Oluşturuldu.";
            }
            else
            {
                _unitOfWork.AçmaRapor.Update(obj.AçmaRapor);
                TempData["Başarılı"] = "Rapor Başarıyla Güncellendi.";
            }

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<AçmaRapor> objRapor = _unitOfWork.AçmaRapor.GetAll(includeProperties: "AçmaListesi").ToList();
            return Json(new { data = objRapor });
        }

        public IActionResult RaporSil(int? id)
        {
            var raporToDelete = _unitOfWork.AçmaRapor.Get(u => u.RaporId == id);
            if (raporToDelete == null)
            {
                return Json(new { success = false, message = "Silinirken Bir Hata Meydana Geldi." });
            }

            
            _unitOfWork.AçmaRapor.Remove(raporToDelete);
            _unitOfWork.Save();
            return Json(new { success = false, message = "Başarıyla Silindi." });
        }
        #endregion
    }
}
