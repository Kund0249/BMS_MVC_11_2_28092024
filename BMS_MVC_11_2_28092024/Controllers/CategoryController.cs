using BMS_MVC_11_2_28092024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BMS_MVC.DataAccess;
using BMS_MVC.DataAccess.Repositories;
using BMS_MVC.DataAccess.Entity;

namespace BMS_MVC_11_2_28092024.Controllers
{

    //Controller Class - Handle the http request and response
    public class CategoryController : Controller
    {
        private CategoryRepository categoryRepository;
        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
        }
        //Action method
        /*
            should be public
            shoul be non-static
            decorate with http verbs (default is get)
            can't overload like c# method
         */

        [HttpGet]
        public ViewResult Index()
        {
            List<CategoryEntity> list = categoryRepository.Get();
            List<CategoryModel> data = new List<CategoryModel>();
            if (list != null)
            {
                foreach (var item in list)
                {
                    data.Add(new CategoryModel()
                    {
                        Id = item.CategoryId,
                        Name = item.Name,
                        Description = item.Discription
                    });
                }
            }

            return View(data);
        }

        [HttpGet]
        public ViewResult Create()
        {
           
            return View();
        }

       
        [HttpPost]
        public RedirectToRouteResult Create(CategoryModel model)
        {
            CategoryEntity entity = new CategoryEntity()
            {
                Name = model.Name,
                Discription = model.Description
            };
            //CategoryRepository repository = new CategoryRepository();
            categoryRepository.Add(entity);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public RedirectToRouteResult Delete(int id)
        {
            categoryRepository.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}