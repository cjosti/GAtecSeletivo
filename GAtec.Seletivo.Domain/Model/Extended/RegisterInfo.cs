using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GAtec.Seletivo.Domain.Model.Extended
{
    class RegisterInfo
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "The user name is required.")]
        [StringLength(20, ErrorMessage = "The length should be lower than 20.")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        //[Required(ErrorMessage = "The password is required.")]
        [StringLength(20, ErrorMessage = "The length should be lower than 20.")]
        public string Password { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "The name is required.")]
        [StringLength(50, ErrorMessage = "The length should be lower than 50.")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "The e-mail is required.")]
        [StringLength(50, ErrorMessage = "The length should be lower than 50.")]
        public string Email { get; set; }

        [Display(Name = "Cpf")]
        [Required(ErrorMessage = "The cpf is required.")]
        [StringLength(12, ErrorMessage = "The length should be lower than 12.", MinimumLength = 12)]
        public string Cpf { get; set; }

        [Display(Name = "Type")]
        public UserType Type;
    }
}
