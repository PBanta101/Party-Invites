using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
   public class GuestResponse
   {
      //   F i e l d s   ( I n s t a n c e   V a r i a b l e s )

      [Required(ErrorMessage = "Name Is Required, Pally")]
      public string Name { get; set; }

      [Required(ErrorMessage = "Email Is Required")]
      [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Invalid Email Address")]
      public string Email { get; set; }

      [Required(ErrorMessage = "Phone Is Required")]
      public string Phone { get; set; }

      public bool? WillAttend { get; set; }

   }
}
