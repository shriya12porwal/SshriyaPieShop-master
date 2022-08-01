using Microsoft.AspNetCore.Mvc;
using PieShopApi.Model;

namespace PieShopApi.Controllers
{
    [ApiController]
    [Route("Api/Pie")]
    public class PieController : ControllerBase
    {
        private readonly IPieRepository pieRepository;
        private readonly ICategoryRepository categoryRepository;
      
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            this.pieRepository = pieRepository;
            this.categoryRepository = categoryRepository;

        }
        [HttpGet]
        [Route("AllPies")]

        public IActionResult GetAllPies()
        {
            try
            {
             var pies = this.pieRepository.AllPies;                    
                                                                                                     
                return Ok(pies);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }


        }
        [HttpGet]
        [Route("AllCategory")]

        public IActionResult GetAllCategory()
        {
            try
            {
                var category = this.categoryRepository.AllCategories;

                return Ok(category);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }


        }
        [HttpGet]
        [Route("PiesOfTheWeek")]

        public IActionResult PiesOfTheWeek()
        {
            try
            {
                var weekpies = this.pieRepository.PiesOfTheWeek();

                return Ok(weekpies);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }


        }

        [HttpGet]
        [Route("GetPieById")]

        public IActionResult GetPieById(int id)
        {
            try
            {
                var pie = this.pieRepository.GetPieById(id);

                return Ok(pie);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }


        }


    }
}
