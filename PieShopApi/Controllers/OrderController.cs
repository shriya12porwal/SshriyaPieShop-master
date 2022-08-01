using Microsoft.AspNetCore.Mvc;
using PieShopApi.Model;

namespace PieShopApi.Controllers
{
    [ApiController]
    [Route("Api/Order")]
    public class OrderController : ControllerBase
    {
       
            private readonly IPieRepository pieRepository;
            private readonly ICategoryRepository categoryRepository;

            public OrderController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
            {
                this.pieRepository = pieRepository;
                this.categoryRepository = categoryRepository;

            }


        }
    }

