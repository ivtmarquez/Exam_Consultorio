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
    public class MedicoBL
    {
        // REVISAR SI EXISTE EL USUARIO QUE INTENTA INICIAR SESION
        internal static Medico getLogin(Medico model)
        {
            return MedicoTL.getLogin(model);
        }
        // INSERT, UPDATE Y DELETE DE UN MEDICO
        internal static int IUDMedico(Medico model)
        {
            return MedicoTL.IUDMedico(model);
        }
        // LISTADO DE MEDICOS, SOLO ID Y NOMBRE
        internal static List<SelectListItem> getMedico()
        {
            return MedicoTL.getMedico();
        }

        // INSERT, UPDATE Y DELETE DE UNA CITA
        internal static int IUDCita(Cita model)
        {
            return MedicoTL.IUDCita(model);
        }

        // OBTENER TODA LA INFORMACION DE LAS CITAS ALMACENADAS
        internal static List<Cita> getCitas()
        {
            return MedicoTL.getCitas();
        }
    }
}