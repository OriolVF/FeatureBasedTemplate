using Microsoft.AspNetCore.Mvc;

namespace FeatureBasedTemplate.Features.Home
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new HomeModel
            {
                Title = "Homepage"
            };

            return View(model);
        }
    }
}
