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

        [HttpGet]
        [Route("GetCategoryById")]

        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var category = this.categoryRepository.AllCategories.FirstOrDefault(category => category.CategoryId == id);

                return Ok(category);
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
        [HttpPost]
        [Route("Insertcategory")]

        public IActionResult InsertCategory(Category category)
        {
            try
            {
                var insertedcategory = this.categoryRepository.CreateCategory(category);
                return Ok(insertedcategory);//Return Value

            }

            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpPut]
        [Route("UpdateCategory")]

        public IActionResult UpdateCategory(Category category)
        {
            try
            {
                var updatedcategory = this.categoryRepository.UpdateCategory(category);
                return Ok(updatedcategory);
            }

            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpDelete]
        [Route("RemoveCategory")]

        public IActionResult DeleteCategory(int categoryid)
        {
            try
            {
                var category = this.categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId == categoryid);
                if (category == null)
                {
                    return BadRequest("Category not found");
                }
                else
                {
                    var deletecategory = this.categoryRepository.RemoveCategory(category);
                    return Ok(deletecategory);
                }

            }


            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }



    }
}

