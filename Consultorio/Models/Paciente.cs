using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Consultorio.Models
{
    // MODELO QUE CONTIENE LOS CAMPOS DE UN PACIENTE
    public class Paciente
    {
        public string IDPACIENTE { get; set; }
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
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        [StringLength(30)]
        [Required(ErrorMessage = "Fecha de Nacimiento es obligatorio")]
        public string FECHANAC { get; set; }
        [Display(Name = "Localidad")]
        [StringLength(50)]
        [Required(ErrorMessage = "Localidad es obligatoria")]
        public string LOCALIDAD { get; set; }
        [Display(Name = "Teléfono")]
        [StringLength(20)]
        [Required(ErrorMessage = "Teléfono es obligatorio")]
        public string TELEFONO { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email es obligatorio")]
        [StringLength(50)]
        public string EMAIL { get; set; }
        public string HORARIO { get; set; }
        [Display(Name = "Medio por el que se enteró")]
        [Required(ErrorMessage = "Medio es obligatorio")]
        [StringLength(50)]
        public string MEDIO { get; set; }
        public int EDAD { get; set; }

    }
}