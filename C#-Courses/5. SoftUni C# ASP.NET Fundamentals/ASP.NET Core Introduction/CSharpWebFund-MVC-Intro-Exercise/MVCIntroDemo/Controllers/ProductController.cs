namespace MVCIntroDemo.Controllers

{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    using MVCIntroDemo.ViewModels.Product;
    using Newtonsoft.Json;
    using System.Text;
    using System.Text.Json;
    using static MVCIntroDemo.Seeding.ProductsData;
    public class ProductController : Controller
    {
        public IActionResult All()
        {

            return View(Products);
        }

        public IActionResult ById(string id)
        {
            ProductViewModel? product = Products.FirstOrDefault(p=>p.Id.ToString().Equals(id));
            if (product == null)
            {
                return this.RedirectToAction("All");
            }

            return View(product);
        }

        public IActionResult AllAsJson()
        {
            string jsonText = JsonConvert.SerializeObject(Products, Formatting.Indented);

            return Json(jsonText);

            //return Json((Products, new JsonSerializerOptions()
            //{
            //    WriteIndented = true,
            //});)
        }

        public IActionResult DownloadProductsInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var product in Products)
            {
                sb
                    .AppendLine($"Product with Id: {product.Id}")
                    .AppendLine($"## Product Name: {product.Name}")
                    .AppendLine($"## Price: {product.Price:f2}$")
                    .AppendLine($"-------------------------------");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, "attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString()),"text/plain");
        }
    }
}
