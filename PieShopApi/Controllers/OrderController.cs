using Microsoft.AspNetCore.Mvc;
using PieShopApi.Model;

namespace PieShopApi.Controllers
{
    [ApiController]
    [Route("Api/Order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        [HttpGet]
        [Route("GetAllOrder")]
        public IActionResult GetAllOrders(Order order)

        {
            try
            {
                var orders = this.orderRepository.AllOrders;

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }


        }

        [HttpGet]
        [Route("InsertOrder")]
        public IActionResult InsertOrder(Order order)
      
        {
            try
            {
                var pies = this.orderRepository.AddOrder(order);

                return Ok(pies);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }


        }
        [HttpDelete]
        [Route("DeleteOrder")]
        public IActionResult DeleteOrder(int orderid)

        {
            try
            {
                
                var pies = this.orderRepository.DeleteOrder(orderid);

                return Ok(pies);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }


        }
        [HttpPut]
        [Route("UpdateOrder")]
        public IActionResult UpdateOrder(Order order)

        {
            try
            {
                var pies = this.orderRepository.UpdateOrder(order);

                return Ok(pies);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }


        }

    }
}
