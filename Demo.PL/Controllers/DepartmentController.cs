using AutoMapper;
using Demo.BLL.Interface;
using Demo.BLL.Models;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        #region fieldes

        private readonly IDepartmentRep Department;
        private readonly IMapper mapper;
        #endregion


        #region Ctor
        public DepartmentController(IDepartmentRep Department, IMapper mapper)
        {
            this.Department = Department;
            this.mapper = mapper;
        }


        #endregion


        #region Actions

        public IActionResult Index(string SearchValue = null)
        {
            if (SearchValue == null || SearchValue == "")
            {
                var data = Department.Get();
                var result = mapper.Map<IEnumerable<DepartmentVM>>(data);
                return View(result);
            }
            else
            {
                var data = Department.SearchByName(SearchValue);
                var result = mapper.Map<IEnumerable<DepartmentVM>>(data);

                return View(result);
            }
        }

        public IActionResult Details(int id)
        {
            var data = Department.GetById(id);
            var result = mapper.Map<DepartmentVM>(data);

            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);
                    Department.Create(data);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                //Handle Exception
                //log Exception
                return View();
            }
        }

        public IActionResult Edit(int id)
        {

            var data = Department.GetById(id);
            var result = mapper.Map<DepartmentVM>(data);

            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);

                    Department.Edit(data);
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
            var data = Department.GetById(id);
            var result = mapper.Map<DepartmentVM>(data);

            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(DepartmentVM model)
        {
            try
            {
                var oldData = Department.GetById(model.Id);

                Department.Delete(oldData);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
        #endregion
    }
}
