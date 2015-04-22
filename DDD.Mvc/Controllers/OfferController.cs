using System;
using AutoMapper;
using DDD.Application.Interface;
using DDD.Domain.Entities;
using DDD.Mvc.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DDD.Mvc.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferAppService _offerApp;

        public OfferController(IOfferAppService offerApp)
        {
            _offerApp = offerApp;
        }

        public ActionResult Index()
        {
            var offerViewModel = Mapper.Map<IEnumerable<Offer>, IEnumerable<OfferViewModel>>(_offerApp.GetList());
            return View(offerViewModel);
        }

        public ActionResult Details(int id)
        {
            var offerViewModel = Mapper.Map<Offer, OfferViewModel>(_offerApp.GetById(id));
            return View(offerViewModel);
        }

        public ActionResult Create()
        {
            return View(new OfferViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfferViewModel offerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var offerDomain = Mapper.Map<OfferViewModel, Offer>(offerViewModel);
                    _offerApp.Add(offerDomain);
                    return RedirectToAction("Index");
                }

                return View(offerViewModel);
            }
            catch
            {
                return View(offerViewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            var offerViewModel = Mapper.Map<Offer, OfferViewModel>(_offerApp.GetById(id));
            return View(offerViewModel);
        }

        [HttpPost]
        public ActionResult Edit(OfferViewModel offerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var offerDomain = Mapper.Map<OfferViewModel, Offer>(offerViewModel);
                    _offerApp.Update(offerDomain);
                    return RedirectToAction("Index");
                }

                return View(offerViewModel);
            }
            catch
            {
                return View(offerViewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var offerViewModel = Mapper.Map<Offer, OfferViewModel>(_offerApp.GetById(id));
            return View(offerViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var offer = _offerApp.GetById(id);
            _offerApp.Delete(offer);
            return RedirectToAction("Index");
        }

        public JsonResult GetValidOffer(int amount)
        {
            var offerViewModel = Mapper.Map<IEnumerable<Offer>, IEnumerable<OfferViewModel>>(_offerApp.GetValidOffers(amount));
            return Json(offerViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}
