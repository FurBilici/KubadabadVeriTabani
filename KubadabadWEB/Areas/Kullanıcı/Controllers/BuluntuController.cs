using Kubadabad.DataAccess.Repository.IRepository;
using Kubadabad.Models;
using Kubadabad.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kubadabad.Areas.Kullanıcı.Controllers
{
    [Area("Kullanıcı")]
    public class BuluntuController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BuluntuController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Buluntular> objBuluntular = _unitOfWork.Buluntular.GetAll(includeProperties: "AçmaListesi").ToList();
            return View(objBuluntular);
        }

        public IActionResult Details(int id)
        {
            Buluntular objBuluntu = _unitOfWork.Buluntular.Get(u=>u.BuluntuId==id,includeProperties: "AçmaListesi");
            return View(objBuluntu);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            BuluntuVM buluntuVM = new()
            {
                AçmaList = _unitOfWork.AçmaListesi.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AçmaAdı,
                    Value = u.Id.ToString()
                }),
                Buluntular = new Buluntular()
            };
            if (id == null || id == 0)
            {
                //create
                return View(buluntuVM);
            }
            else
            {
                //update
                buluntuVM.Buluntular = _unitOfWork.Buluntular.Get(u => u.BuluntuId == id);
                return View(buluntuVM);
            }
            return View(buluntuVM);
        }
        [HttpPost]
        public IActionResult Upsert(BuluntuVM obj)
        {
            if (obj.Buluntular.BuluntuId == 0)
            {
                _unitOfWork.Buluntular.Add(obj.Buluntular);
                TempData["Başarılı"] = "Buluntu Başarıyla Oluşturuldu.";
            }
            else
            {
                _unitOfWork.Buluntular.Update(obj.Buluntular);
                TempData["Başarılı"] = "Rapor Başarıyla Güncellendi.";
            }

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Buluntular> objBuluntu = _unitOfWork.Buluntular.GetAll(includeProperties: "AçmaListesi").ToList();
            return Json(new { data = objBuluntu });
        }

        public IActionResult BuluntuSil(int? id)
        {
            var buluntuToDelete = _unitOfWork.Buluntular.Get(u => u.BuluntuId == id);
            if (buluntuToDelete == null)
            {
                return Json(new { success = false, message = "Silinirken Bir Hata Meydana Geldi." });
            }


            _unitOfWork.Buluntular.Remove(buluntuToDelete);
            _unitOfWork.Save();
            return Json(new { success = false, message = "Başarıyla Silindi." });
        }
        #endregion
    }
}
