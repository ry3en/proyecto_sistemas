using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace proyecto_sistemas.Shared.Entities
{
    public class User:IdentityUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Foto")]
        public string? Photo { get; set; }

        [Required]
        public int UserTypeId { get; set; }

        public UserType UserType { get; set; } = null!;

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
