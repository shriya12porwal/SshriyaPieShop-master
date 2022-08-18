using Microsoft.EntityFrameworkCore;
namespace SshriyaPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly ICategoryRepository categoryRepostiory;
        public PieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public IEnumerable<Pie> AllPies => appDbContext.Pies;
        public IEnumerable<Order> AllOrders => this.appDbContext.Orders;
        /* new List<Pie>
          {
              new Pie { PieId = 1, Name = "Strawberry Pie", Price = 15.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Category = _categoryRepository.AllCategories.ToList()[0], ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypie.jpg", InStock = true, IsPieOfTheWeek = false, ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg" },
              new Pie { PieId = 2, Name = "Cheese cake", Price = 18.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Category = _categoryRepository.AllCategories.ToList()[1], ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecake.jpg", InStock = true, IsPieOfTheWeek = false, ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecakesmall.jpg" },
              new Pie { PieId = 3, Name = "Rhubarb Pie", Price = 15.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Category = _categoryRepository.AllCategories.ToList()[0], ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpie.jpg", InStock = true, IsPieOfTheWeek = true, ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpiesmall.jpg" },
              new Pie { PieId = 4, Name = "Pumpkin Pie", Price = 12.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Category = _categoryRepository.AllCategories.ToList()[2], ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpie.jpg", InStock = true, IsPieOfTheWeek = true, ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpiesmall.jpg" }

         };*/



        public IEnumerable<Pie> GetPieById(int pieId)
        {
            return AllPies.Where(pie => pie.PieId == pieId);
        }

        public IEnumerable<Pie> PiesOfTheWeek()
        {
            return AllPies.Where(pies => pies.IsPieOfTheWeek);
        }
       




        /*public IEnumerable<Pie> FruitsPies()
        {

            return AllPies.Where(pie => pie.CategoryId == 1);
        }
        public IEnumerable<Pie> Cheesecakes()
        {
            return AllPies.Where(pie => pie.CategoryId == 2);
        }
        public IEnumerable<Pie> Seasonalpies()
        {
            return AllPies.Where(pie => pie.CategoryId == 3);
        }*/

        public Pie CreatePie(Pie pie)
        {
            var pies =  this.appDbContext.Pies.Add(pie);
            appDbContext.SaveChanges();
            return pies.Entity;
        }
        public Pie Remove(int pieid)
        {
            var pie = this.appDbContext.Pies.FirstOrDefault(pie => pie.PieId == pieid);
            var entry = this.appDbContext.Pies.Remove(pie);
            this.appDbContext.SaveChanges();
            return entry.Entity;


        }
        public int CreateOrder(Order order)
        {
            //var pie = pieRepository.AllPies.Where(pie => pie.PieId == pieId);
            var entity = this.appDbContext.Orders.Add(order);
            return this.appDbContext.SaveChanges();


        }
        public int UpdateOrder(Order order)
        {
            //var pie = pieRepository.AllPies.Where(pie => pie.PieId == pieId);
            var entity = this.appDbContext.Orders.Update(order);
            return this.appDbContext.SaveChanges();


        }
       



    }
}
