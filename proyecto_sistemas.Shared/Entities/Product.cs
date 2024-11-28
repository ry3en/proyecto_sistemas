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
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public Brand Brand { get; set; }


        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }


        [Required]
        [MaxLength(100, ErrorMessage = "El campo no {0} debe tener maximo {1} caracteres")]
        [Display(Name = "Category")]
        public Category Category { get; set; }

        //public Category category { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "El campo no {0} debe tener maximo {1} caracteres")]
        [Display(Name = "Total")]
        public int Total { get; set; }


    }
}
