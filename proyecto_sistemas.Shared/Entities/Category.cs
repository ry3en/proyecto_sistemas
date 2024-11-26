using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_sistemas.Shared.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo no {0} debe tener maximo {1} caracteres")]
        [Display(Name = "Category")]
        public string Name { get; set; }

    }
}