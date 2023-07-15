using AutoMapper;
using Demo.BLL.Helper;
using Demo.BLL.Interface;
using Demo.BLL.Models;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {

        #region fieldes
        private readonly IDepartmentRep Department;
        private readonly IEmployeeRep employee;
        private readonly IMapper mapper;
        private readonly ICountryRep country;
        private readonly ICityRep city;
        private readonly IDistrictRep district;
        #endregion


        #region Ctor

        public EmployeeController(IDepartmentRep Department,
            IEmployeeRep employee,
            IMapper mapper,
            ICountryRep country,
            ICityRep city,
            IDistrictRep district)
        {
            this.Department = Department;
            this.employee = employee;
            this.mapper = mapper;
            this.country = country;
            this.city = city;
            this.district = district;
        }

        #endregion


        #region Actions

        public IActionResult Index(string SearchValue = null)
        {
            if (SearchValue == null || SearchValue == "")
            {
                var data = employee.Get();
                var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(result);
            }
            else
            {
                var data = employee.SearchByName(SearchValue);
                var result = mapper.Map<IEnumerable<EmployeeVM>>(data);

                return View(result);
            }
        }

        public IActionResult Details(int id)
        {
            var data = employee.GetById(id);
            var result = mapper.Map<EmployeeVM>(data);

            return View(result);
        }
        public IActionResult Create()
        {

            ViewBag.DepartmentList = new SelectList(Department.Get(), "Id", "DepartmentName");
            ViewBag.CountrytList = new SelectList(country.Get(), "Id", "CountryName");


            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string CvUrl = FileUploader.UploadFile("Files/Docs", model.Cv);
                    string ImageUrl = FileUploader.UploadFile("Files/Imgs", model.Photo);

                    var data = mapper.Map<Employee>(model);
                    data.CvUrl = CvUrl;
                    data.PhotoUrl = ImageUrl;

                    employee.Create(data);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {

            var data = employee.GetById(id);
            var result = mapper.Map<EmployeeVM>(data);


            var dbt = Department?.Get();
            if (dbt != null)
            {
                ViewBag.DepartmentList = new SelectList(dbt, "Id", "DepartmentName", data.DepartmentId);
                return View(result);

            }
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);

                    employee.Edit(data);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var data = employee.GetById(id);
            var result = mapper.Map<EmployeeVM>(data);

            var dbt = Department.Get();
            ViewBag.DepartmentList = new SelectList(dbt, "Id", "DepartmentName", data.DepartmentId);

            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(EmployeeVM model)
        {
            try
            {
                FileUploader.RemoveFile("Files/Docs/", model.CvUrl);
                FileUploader.RemoveFile("Files/Imgs/", model.PhotoUrl);

                var oldData = employee.GetById(model.Id);

                employee.Delete(oldData);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
        #endregion


        #region Ajax Call

        [HttpPost]
        public JsonResult GetCityDataByCountryId(int CtryId)
        {
            var data = city.Get().Where(x => x.CountryId == CtryId);
            return Json(data);
        }

        [HttpPost]
        public JsonResult GetDistrictDataByCityId(int CtyId)
        {
            var data = district.Get().Where(x => x.CityId == CtyId);
            return Json(data);
        }

        #endregion

    }
}
