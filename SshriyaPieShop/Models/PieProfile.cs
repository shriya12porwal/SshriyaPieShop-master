using AutoMapper;

namespace SshriyaPieShop.Models
{
    public class PieProfile :Profile
    {
        public PieProfile()
        {
            this.CreateMap<Pie, PieMini>();
        }
    }
}
