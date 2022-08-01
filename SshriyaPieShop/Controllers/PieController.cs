using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public PieController(IPieRepository pieRepostior , IMapper mapper, IHttpContextAccessor  httpContext )
        {
            this._pieRepostiory = pieRepostior;
            this.mapper = mapper;
            this.httpContextAccessor = httpContext;
        }
        public IActionResult List(int categoryId)
        {
            var user = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name);
            Console.WriteLine(user);

            IEnumerable<Pie> pies;
            if (categoryId > 0)
            {
                pies = _pieRepostiory.AllPies.Where(pie => pie.CategoryId == categoryId);
                
            }
            else
            {
                pies = _pieRepostiory.AllPies;
            }
            return View(pies);
        }


        public IActionResult ListMini()
        {
            var pie = _pieRepostiory.AllPies;
            var piemini = mapper.Map<PieMini[]>(pie);
            return View(piemini);
        }
        
      
        

        public ViewResult Details(int id)
        {
            var pie = _pieRepostiory.AllPies.FirstOrDefault(pie => pie.PieId == id);
            return View(pie);

        }

        public ViewResult PiesOfTheWeek()
        {
            var pie = _pieRepostiory.PiesOfTheWeek();
            return View(pie);
        }
       /* public ViewResult FruitsPies()
        {
            // var categoryid = categoryRepostiory.AllCategories.Select(category => category.CategoryName == "Fruit pies");
            var pie = _pieRepostiory.FruitsPies();
            return View(pie);

        }
        public ViewResult CheeseCakes()
        {

            var pie = _pieRepostiory.Cheesecakes();
            return View(pie);

        }
        public ViewResult SeasonalPies()
        {
            *//* var category = categoryRepostiory.AllCategories.Where(category => category.CategoryName == "Seasonal pies");*//*
            var pie = _pieRepostiory.Seasonalpies();
            return View(pie);

        }
        */
        public ViewResult GetPieById(int id)
        {
            /* var category = categoryRepostiory.AllCategories.Where(category => category.CategoryName == "Seasonal pies");*/
            var pie = _pieRepostiory.GetPieById(id);
            return View(pie);

        }
       



    }

}


