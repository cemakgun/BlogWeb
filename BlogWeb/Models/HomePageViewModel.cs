using BlogWeb.Entities;

namespace AspNetCoreBlog.Models
{
    public class HomePageViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Post> Posts { get; set; }
    }
}
