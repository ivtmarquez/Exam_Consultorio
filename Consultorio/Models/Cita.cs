using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Consultorio.Models
{
    // MODELO QUE CONTIENE LA INFORMACION DE UNA CITA
    public class Cita
    {
        public int IDCITA { get; set; }
        [Display(Name = "Médico")]
        [Required(ErrorMessage = "Médico es obligatorio")]
        [StringLength(90)]
        public string MEDICO { get; set; }
        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Paciente es obligatorio")]
        [StringLength(90)]
        public string PACIENTE { get; set; }
        [Display(Name = "Día")]
        [Required(ErrorMessage = "Día es obligatorio")]
        public string DIACITA { get; set; }
        [Display(Name = "Hora")]
        [Required(ErrorMessage = "Hora es obligatorio")]
        public string HORACITA { get; set; }
        [Display(Name = "Expediente")]
        [Required(ErrorMessage = "Expediente es obligatorio")]
        public string EXPEDIENTE { get; set; }
        [Display(Name = "Estudios")]
        [Required(ErrorMessage = "Estudios es obligatorio")]
        public string ESTUDIOS { get; set; }
        [Display(Name = "Observaciones")]
        [Required(ErrorMessage = "Observaciones es obligatorio")]
        public string OBSERVACIONES { get; set; }
    }
}