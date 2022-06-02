using Consultorio.Models;
using Consultorio.TL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consultorio.BL
{
    //BUSINESS LAYER 
    //METODOS QUE SON LLAMADOS DESDE LOS CONTROLADORES E IRAN A LA BASE DE DATOS
    public class PacienteBL
    {
        // INSERT, UPDATE Y DELETE DE UN PACIENTE
        internal static int IUDPaciente(Paciente model)
        {
            return PacienteTL.IUDPaciente(model);
        }

        // OBTENER TODA LA INFORMACION DE LOS PACIENTES
        internal static List<Paciente> getPacientes()
        {
            return PacienteTL.getPacientes();
        }
        // OBTENER ID Y NOMBRE DE LOS PACIENTES
        internal static List<SelectListItem> getPaciente()
        {
            return PacienteTL.getPaciente();
        }
    }
}