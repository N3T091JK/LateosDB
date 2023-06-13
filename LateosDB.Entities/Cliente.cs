using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [MaxLength(80)]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        [Required]
        public int IdEstado { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
