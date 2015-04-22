using AutoMapper;
using DDD.Application.Interface;
using DDD.Domain.Entities;
using DDD.Mvc.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDD.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductAppService _productApp;
        private readonly IOfferAppService _offerApp;

        public HomeController(IProductAppService productApp, IOfferAppService offerApp)
        {
            _productApp = productApp;
            _offerApp = offerApp;
        }

        public ActionResult Index()
        {
            var shoppingCartCookie = Request.Cookies["shoppingCart"] ?? new HttpCookie("shoppingCart");

            var productList = new SelectList(_productApp.GetList(), "ProductId", "Name");
            var offerList = new SelectList(_offerApp.GetList(), "OfferId", "Name");

            ViewData["products"] = productList;
            ViewData["offer"] = offerList;

            var shoppingCart = new ShoppingCartViewModel();

            if (!string.IsNullOrEmpty(shoppingCartCookie.Value))
                shoppingCart = JsonConvert
                    .DeserializeObject<ShoppingCartViewModel>(shoppingCartCookie.Value);

            ViewData["shoppingCart"] = shoppingCart;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection form)
        {
            var shoppingCartCookie = Request.Cookies["shoppingCart"] ?? new HttpCookie("shoppingCart");
            var productId = int.Parse(form["productsList"]);

            var shoppingCart = new ShoppingCartViewModel();

            if (!string.IsNullOrEmpty(shoppingCartCookie.Value))
                shoppingCart = JsonConvert
                    .DeserializeObject<ShoppingCartViewModel>(shoppingCartCookie.Value);

            if (shoppingCart.Items == null)
                shoppingCart.Items = new List<ShoppingCartItemViewModel>();

            var lst = shoppingCart.Items.ToList();

            var product = _productApp.GetById(productId);

            var newShoppingCartItemViewModel = new ShoppingCartItemViewModel
            {
                ShoppingCartItemId = Guid.NewGuid(),
                ProductId = productId,
                ProductName = product.Name,
                Amount = 1,
                Price = 1 * product.Price
            };

            lst.Add(newShoppingCartItemViewModel);
            shoppingCart.Items = lst;

            shoppingCartCookie.Value = JsonConvert.SerializeObject(shoppingCart);
            shoppingCartCookie.Expires = DateTime.Now.AddDays(5);

            Response.Cookies.Add(shoppingCartCookie);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeAmountOfProduct(int Amount, Guid shoppingCartItemId)
        {
            var shoppingCartCookie = Request.Cookies["shoppingCart"] ?? new HttpCookie("shoppingCart");

            var shoppingCart = new ShoppingCartViewModel();

            if (!string.IsNullOrEmpty(shoppingCartCookie.Value))
            {
                shoppingCart = JsonConvert
                    .DeserializeObject<ShoppingCartViewModel>(shoppingCartCookie.Value);

                if (shoppingCart.Items != null)
                {
                    var shoppingCartItem = shoppingCart.Items.Where(x => x.ShoppingCartItemId == shoppingCartItemId).First();

                    if (shoppingCartItem != null)
                    {
                        var product = _productApp.GetById(shoppingCartItem.ProductId);

                        shoppingCartItem.Amount = Amount;
                        shoppingCartItem.Price = Amount * product.Price;
                        shoppingCartItem.OfferId = 0;

                        shoppingCartCookie.Value = JsonConvert.SerializeObject(shoppingCart);
                        shoppingCartCookie.Expires = DateTime.Now.AddDays(5);

                        Response.Cookies.Add(shoppingCartCookie);

                        return Json(shoppingCartItem.Price);
                    }
                    return Json(0);
                }
                return Json(0);
            }

            return Json(0);
        }

        [HttpPost]
        public JsonResult ChangeOffer(int? offerId, Guid shoppingCartItemId)
        {
            var shoppingCartCookie = Request.Cookies["shoppingCart"] ?? new HttpCookie("shoppingCart");

            var shoppingCart = new ShoppingCartViewModel();

            if (!string.IsNullOrEmpty(shoppingCartCookie.Value))
            {
                shoppingCart = JsonConvert
                    .DeserializeObject<ShoppingCartViewModel>(shoppingCartCookie.Value);

                if (shoppingCart.Items != null)
                {
                    var shoppingCartItem = shoppingCart.Items.Where(x => x.ShoppingCartItemId == shoppingCartItemId).First();

                    if (shoppingCartItem != null)
                    {
                        var product = _productApp.GetById(shoppingCartItem.ProductId);

                        if (offerId == null)
                        {
                            shoppingCartItem.Amount = 1;
                            shoppingCartItem.Price = product.Price;
                            shoppingCartItem.OfferId = 0;
                        }
                        else
                        {
                            var offer = _offerApp.GetById(offerId.Value);

                            shoppingCartItem.Amount = offer.Amount;

                            shoppingCartItem.Price = offer.Price;
                            shoppingCartItem.OfferId = offer.OfferId;

                            if (offer.PriceBasedOnProduct == true && offer.NumberOfProductsPriceBased != null)
                            {
                                shoppingCartItem.Price = product.Price * offer.NumberOfProductsPriceBased.Value;
                                shoppingCartItem.Amount = offer.Amount;
                            }
                        }

                        shoppingCartCookie.Value = JsonConvert.SerializeObject(shoppingCart);
                        shoppingCartCookie.Expires = DateTime.Now.AddDays(5);

                        Response.Cookies.Add(shoppingCartCookie);

                        return Json(shoppingCartItem.Price);
                    }
                    return Json(0);
                }
                return Json(0);
            }

            return Json(0);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}