﻿using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;

namespace Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketViewModelService _basketViewModelService;

        public BasketController(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }

        public async Task<IActionResult> Index()
        {
            var basketViewModel = await _basketViewModelService.GetBasketViewModelAsync();
            return View(basketViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddItem(int productId, int quantity = 1)
        {
            var basket = await _basketViewModelService.AddItemToBasketAsync(productId, quantity);
            return Json(basket);
        }

        public async Task<IActionResult> Empty()
        {
            var basketViewModel = await _basketViewModelService.GetBasketViewModelAsync();
            return View(basketViewModel);
        }
    }
}
