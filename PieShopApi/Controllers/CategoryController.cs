using Microsoft.AspNetCore.Mvc;
using PieShopApi.Model;

namespace PieShopApi.Controllers
{
    [ApiController]
    [Route("Api/Category")]
    public class CategoryController :  ControllerBase
    {
       
            private readonly IPieRepository pieRepository;
            private readonly ICategoryRepository categoryRepository;

            public CategoryController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
            {
                this.pieRepository = pieRepository;
                this.categoryRepository = categoryRepository;

            }


        }
    }

