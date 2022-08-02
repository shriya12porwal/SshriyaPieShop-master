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
        [Route("GetAllPies")]

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
        [Route("PiesbyCategoryId")]

        public IActionResult PiesbyCategoryId(int id)
        {
            try
            {
               // var category = this.categoryRepository.AllCategories.FirstOrDefault(category => category.CategoryId == id); ;
                var pies = this.pieRepository.AllPies.Where(p => p.CategoryId == id);
                return Ok(pies);
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
        [Route("DetailsofPie")]

        public IActionResult Details(int id)
        {
            try
            {
                var pie = this.pieRepository.Details(id);

                return Ok(pie);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }


        }
        [HttpPost]
        [Route("InsertPie")]

        public IActionResult InsertPie(Pie pie)
        {
            try
            {
                var insertedpie = this.pieRepository.CreatePie(pie);
                return CreatedAtRoute("GetPie", new { id = insertedpie.PieId }, insertedpie);//Return Value

            }

            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpPut]
        [Route("UpdatePie")]

        public IActionResult UpdatePie(Pie pie)
        {
            try
            {
                var updatedPie = this.pieRepository.UpdatePie(pie);
                return Ok(updatedPie);
            }

            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpDelete]
        [Route("RemovePie")]

        public IActionResult DeletePie(int pieId)
        {
            try
            {
                var pie = this.pieRepository.AllPies.FirstOrDefault(Pie => Pie.PieId == pieId);
                if (pie == null)
                {
                    return BadRequest("Pie not found");
                }
                else
                {
                    var deletepie = this.pieRepository.RemovePie(pie);
                    return Ok(deletepie);
                }

            }


            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        


    }
}
