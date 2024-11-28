using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_sistemas.Shared.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "El campo no {0} debe tener maximo {1} caracteres")]
        [Display(Name = "Order")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "El campo no {0} debe tener maximo {1} caracteres")]
        [Display(Name = "Total")]
        public int Total { get; set; }

        // Relación muchos a muchos con Product a través de OrderItem
        public ICollection<OrderItem> OrderItems { get; set; }
    }

}
