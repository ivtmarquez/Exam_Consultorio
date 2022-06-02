using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Consultorio.Models
{
    // MODELO QUE CONTIENE LOS CAMPOS DE UN MEDICO
    public class Medico
    {
        public int IDMEDICO { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email es obligatorio")]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Contraseña es obligatoria")]
        [StringLength(15)]
        public string PASSWORD { get; set; }

        [Display(Name = "Repetir contraseña")]
        [Required(ErrorMessage = "Contraseña es obligatoria")]
        [StringLength(15)]
        public string PASSWORDCONFIRM { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30)]
        public string NOMBRE { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "Apellido Paterno es obligatorio")]
        [StringLength(30)]
        public string APPATERNO { get; set; }
        [Display(Name = "Apellido Materno")]
        [StringLength(30)]
        public string APMATERNO { get; set; }
    }
}