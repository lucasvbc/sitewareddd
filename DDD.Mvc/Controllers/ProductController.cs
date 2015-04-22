using System;
using AutoMapper;
using DDD.Application.Interface;
using DDD.Domain.Entities;
using DDD.Mvc.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DDD.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductAppService _productApp;

        public ProductController(IProductAppService productApp)
        {
            _productApp = productApp;
        }

        public ActionResult Index()
        {
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(_productApp.GetList());
            return View(productViewModel);
        }

        public ActionResult Details(int id)
        {
            var productViewModel = Mapper.Map<Product, ProductViewModel>(_productApp.GetById(id));
            return View(productViewModel);
        }

        public ActionResult Create()
        {
            return View(new ProductViewModel());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productDomain = Mapper.Map<ProductViewModel, Product>(productViewModel);
                    _productApp.Add(productDomain);
                    return RedirectToAction("Index");
                }

                return View(productViewModel);
            }
            catch
            {
                return View(productViewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            var productViewModel = Mapper.Map<Product, ProductViewModel>(_productApp.GetById(id));
            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productDomain = Mapper.Map<ProductViewModel, Product>(productViewModel);
                    _productApp.Update(productDomain);
                    return RedirectToAction("Index");
                }

                return View(productViewModel);
            }
            catch
            {
                return View(productViewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var productViewModel = Mapper.Map<Product, ProductViewModel>(_productApp.GetById(id));
            return View(productViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _productApp.GetById(id);
            _productApp.Delete(product);
            return RedirectToAction("Index");
        }
    }
}
