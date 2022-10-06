using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlogWeb.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Adı"), StringLength(50)]
        public string? Name { get; set; }
        [Display(Name = "Soyadı"), StringLength(50)]
        public string? Surname { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [Display(Name = "Kullanıcı Adı"), StringLength(50), Required(ErrorMessage = "Bu alan gereklidir!")]
        public string Username { get; set; }
        [Display(Name = "Şifre"), StringLength(50), Required(ErrorMessage = "Bu alan gereklidir!")]
        public string Password { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }
    }
}
