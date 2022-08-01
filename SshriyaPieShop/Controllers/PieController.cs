using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SshriyaPieShop.Models;
using System.Security.Claims;

namespace SshriyaPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepostiory;
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepostiory;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IConfiguration confriguration;
        string baseaddress;
        public PieController(IPieRepository pieRepostior, IMapper mapper, IHttpContextAccessor httpContext, IConfiguration confriguration, ICategoryRepository categoryRepostiory)
        {
            this._pieRepostiory = pieRepostior;
            this.mapper = mapper;
            this.httpContextAccessor = httpContext;
            this.categoryRepostiory = categoryRepostiory;
            this.baseaddress = confriguration.GetValue<string>("BaseAddress");
        }
        public async Task<ViewResult> List(int categoryId )
        {
            /*var user = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name);
            Console.WriteLine(user);*/
            IEnumerable<Pie> pies = new List<Pie>();

            if (categoryId > 0)
            {
                using (var httpClient = new HttpClient())
                {
                   
                    using (var response = await httpClient.GetAsync("https://localhost:7070/Api/Pie/PiesbyCategoryId?id=" + categoryId))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);//convert json to student array
                    }
                }
                //pies = _pieRepostiory.AllPies.Where(pie => pie.CategoryId == categoryId);

            }
            else
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://localhost:7070/Api/Pie/GetAllPies"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);//convert json to student array
                    }
                }
            }
            return View(pies);
        }


        public async Task<ViewResult> ListMini()
        {
            IEnumerable<Pie> pies = new List<Pie>();
            // var pie = _pieRepostiory.AllPies;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7070/Api/Pie/GetAllPies"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);//convert json to student array
                }
            }
            var piemini = mapper.Map<PieMini[]>(pies);
            return View(piemini);
        }




        public async Task<ViewResult> Details(int id)
        {
            IEnumerable<Pie> pies = new List<Pie>();
            // var pie = _pieRepostiory.AllPies;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7070/Api/Pie/DetailsofPie?id="+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);//convert json to student array
                }
            }
            var pie  = pies.FirstOrDefault(pie => pie.PieId == id);
            
            return View(pie);

        }

        public async Task<ViewResult> PiesOfTheWeek()
        {
            IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7070/Api/Pie/PiesOfTheWeek"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);//convert json to student array
                }
            }
            return View(pies);
            //Because return type is task that's why recieve is result 

        }
        [Authorize]
        public ViewResult Create()
        {
           var categories =  categoryRepostiory.AllCategories;

            var categoriesItems = new List<SelectListItem>();
            foreach (var category in categories)
            {
                categoriesItems.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryId.ToString() });
            }

            // var pie = new Pie();
            ViewBag.Categories = categoriesItems;
            return View();
        }

        public async Task<IActionResult> AddtoCart(Pie pie)
        {
            IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("https://localhost:7070/Api/Pie/InsertPie", pie))
                {
   
                    return RedirectToAction("AddToCart");
                }
            }
            return RedirectToAction("AddToCart");

            // var pies = _pieRepostiory.CreatePie(pie);
            //return View(pies);
        }

        public async Task<IActionResult> CreatePie(Pie pie)
        {
            IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("https://localhost:7070/Api/Pie/InsertPie", pie))
                {
                    /*string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);//convert json to student array*/
                    return RedirectToAction("PiesOfTheWeek");
                }
            }
            return RedirectToAction("PiesOfTheWeek");

            // var pies = _pieRepostiory.CreatePie(pie);
            //return View(pies);
        }
        public async Task<IActionResult> DeletePie(int pieId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7070/Api/Pie/RemovePie?pieId=" + pieId))
                {
                      string apiResponse = await response.Content.ReadAsStringAsync();
                    
                }
            }
            return RedirectToAction("PiesOfTheWeek");
        }
       

        public async Task<ViewResult> Edit(int id)
        {

            IEnumerable<Pie> pies = new List<Pie>();
            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7070/Api/Pie/DetailsofPie?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);//convert json to student array
                }
            }
            var pie = pies.FirstOrDefault(pie => pie.PieId == id);

            
            //var pies = _pieRepostiory.AllPies.FirstOrDefault(pie => pie.PieId == id);
            var categories = categoryRepostiory.AllCategories;

            var categoriesItems = new List<SelectListItem>();
            foreach (var category in categories)
            {
                categoriesItems.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryId.ToString() });
            }
            ViewBag.Categories = categoriesItems;
            return View(pie);
          

        }

        
        public async Task<IActionResult> UpdatePie(Pie pie)
        {
            IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync("https://localhost:7070/Api/Pie/UpdatePie", pie))
                {
                    return RedirectToAction("PiesOfTheWeek");
                }
            }
            return RedirectToAction("PiesOfTheWeek");


        }
    }
  
}

