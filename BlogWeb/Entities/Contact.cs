using System.ComponentModel.DataAnnotations;


namespace BlogWeb.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        [Display(Name = "İsim"), StringLength(50), Required(ErrorMessage = "Bu alan gereklidir!")]
        public string Name { get; set; }
        [Display(Name = "Soyisim"), StringLength(50), Required(ErrorMessage = "Bu alan gereklidir!")]
        public string Surname { get; set; }
        [StringLength(50), Required(ErrorMessage = "Bu alan gereklidir!")]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [Display(Name = "Mesaj"), StringLength(500), Required(ErrorMessage = "Bu alan gereklidir!"), DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
