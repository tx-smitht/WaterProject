using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterProject.Infrastructure;
using WaterProject.Models;

namespace WaterProject.Pages
{
    public class DonateModel : PageModel
    {   
        // Bring in the data side of things with the repo.
        // Need this to get the project ID
        private IWaterProjectRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }


        // Creating instance of the repo when the object is created.
        public DonateModel (IWaterProjectRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }


        // Lines that have been commented out have to do with session.
        // We used to be handling that here, but we have since moved it.
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }


        public IActionResult OnPost(int projectId, string returnUrl)
        {
            Project p = repo.Projects.FirstOrDefault(x => x.ProjectId == projectId);

            // This says if the basket item exists, then set basket = to that.
            // If not, create a new thing.
            //basket = HttpContext.Session.GetJson<Basket>("basket") ??  new Basket();
            basket.AddItem(p, 1);

            // Setting the "basket" variable within session
            //HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
        

        // This handles the removal of objects
        public IActionResult OnPostRemove(int projectId, string returnUrl)
        {

            basket.RemoveItem(basket.Items.First(x => x.Project.ProjectId == projectId).Project);
            return RedirectToPage ( new {ReturnUrl = returnUrl});
        }
    }
}
