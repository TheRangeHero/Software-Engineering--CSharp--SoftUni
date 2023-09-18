using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Contracts;
using SoftUniBazar.Models;

namespace SoftUniBazar.Controllers
{
    public class AdController : BaseController
    {
        private readonly IAdService adService;

        public AdController(IAdService _adService)
        {
            this.adService = _adService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await adService.GetAllAdsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddAdViewModel model = await adService.GetNewAddBookModelAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddAdViewModel model)
        {


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = GetUserId();

            await adService.AddBookAsync(model, userId);


            return RedirectToAction("Cart", "All");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AddAdViewModel? ad = await adService.GetAdByIdForEditAsync(id);

            if (ad == null)
            {
                return RedirectToAction("All", "Ad");
            }
            return View(ad);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddAdViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            await adService.EditAdAsync(model, id);
            return RedirectToAction("All", "Ad");
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var ad = await adService.GetAdByIdAsync(id);

            if (ad == null)
            {
                return RedirectToAction("All", "Ad");
            }

            var userId = GetUserId();


            bool isAdded = await adService.AdAlreadyAddedToCartAsync(userId, id);
            if (isAdded)
            {
                return RedirectToAction("All", "Ad");
            }

            await adService.AddAdToCollectionAsync(userId, ad);

            return RedirectToAction("Cart", "Ad");
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var model = await adService.GetMyAdsAsync(GetUserId());

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var book = await adService.GetAdByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction("All", "Ad");
            }

            var userId = GetUserId();

            await adService.RemoveAdFromCollectionAsync(userId, book);

            return RedirectToAction("All", "Ad");
        }

    }
}
