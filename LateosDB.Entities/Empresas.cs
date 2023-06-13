using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Empresas
    {
        [Key]
        public int IdEmpresa { get; set; }
        [MaxLength(80)]
        [Required]
        public string NombreComercial { get; set; }
        [Required]
        public string NombreLegal { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Rubro { get; set; }
    }
}
