using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;

namespace WaterProject.Controllers
{
    public class DonationController : Controller
    {

        private IDonationRepository repo { get; set; }
        private Basket basket { get; set; }
        public DonationController(IDonationRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        // We also need to know what is in their basket. That is why we pass in the session basket.

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Donation());
        }

        [HttpPost]
        public IActionResult Checkout(Donation donation)
        {
            // Send this to the database
            if (basket.Items.Count == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");

            }

            if (ModelState.IsValid)
            {
                donation.Lines = basket.Items.ToArray();
                repo.SaveDonation(donation);
                basket.ClearBasket();

                return RedirectToPage("/DonationCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
