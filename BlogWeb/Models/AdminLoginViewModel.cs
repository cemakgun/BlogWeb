using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlogWeb.Models
{
    public class AdminLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı"), StringLength(50), Required(ErrorMessage = "Bu alan gereklidir!")]
        public string Username { get; set; }
        [Display(Name = "Şifre"), StringLength(50), Required(ErrorMessage = "Bu alan gereklidir!"), DataType(DataType.Password)]
        public string Password { get; set; }




    }
}
