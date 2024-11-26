using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_sistemas.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo no {0} debe tener maximo {1} caracteres")]
        [Display(Name = "Producto")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "El campo no {0} debe tener maximo {1} caracteres")]
        [Display(Name = "Size")]
        public string Size { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "El campo no {0} debe tener maximo {1} caracteres")]
        [Display(Name = "Brand")]
        public int Brand { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "El campo no {0} debe tener maximo {1} caracteres")]
        [Display(Name = "Category")]
        public int Category { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "El campo no {0} debe tener maximo {1} caracteres")]
        [Display(Name = "Total")]
        public double Total { get; set; }

    }
}
