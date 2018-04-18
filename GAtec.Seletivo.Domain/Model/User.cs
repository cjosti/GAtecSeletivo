using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GAtec.Seletivo.Domain.Model
{
    public enum UserType { Admin = 1, Candidate = 0 }

    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "The name is required.")]
        [StringLength(50, ErrorMessage = "The length should be lower than 50.")]
        public string Name { get; set; }

        [Display(Name = "Usuário:")]
        [Required(ErrorMessage = "The user name is required.")]
        [StringLength(20, ErrorMessage = "The length should be lower than 20.")]
        public string UserName { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "The e-mail is required.")]
        [StringLength(50, ErrorMessage = "The length should be lower than 50.")]
        public string Email { get; set; }

        [Display(Name = "Senha:")]
        [StringLength(20, ErrorMessage = "The length should be lower than 20.")]
        public string Password { get; set; }

        [Display(Name = "Cpf:")]
        [Required(ErrorMessage = "The cpf is required.")]
        [StringLength(11, ErrorMessage = "The length should be lower than 11.", MinimumLength = 11)]
        public string CPF { get; set; }

        public UserType Type { get; set; }      

    }
}
