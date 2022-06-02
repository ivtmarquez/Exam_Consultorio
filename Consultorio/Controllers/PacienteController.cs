using Consultorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Consultorio.Models.ManageViewModels;

namespace Consultorio.Controllers
{
    public class PacienteController : Controller
    {
        // SE LLENAN LAS OPCIONES PARA LOS MEDIOS Y SE EXTRAE TODA LA INFORMACION DE LOS PACIENTES.
        public ActionResult Index()
        {
            // ASIGNAMOS A UN VIEWBAG EL LISTADO DE LOS PACIENTES 
            ViewBag.Pacientes = BL.PacienteBL.getPacientes();

            // OPCIONES DE MEDIOS 
            var ltsMedios = new List<SelectListItem>();
            ltsMedios.Add(new SelectListItem { Text = "-- Seleccionar --", Value = "" });
            ltsMedios.Add(new SelectListItem { Text = "Televisión", Value = "Television" });
            ltsMedios.Add(new SelectListItem { Text = "Facebook", Value = "Facebook" });
            ltsMedios.Add(new SelectListItem { Text = "Radio", Value = "Radio" });
            ltsMedios.Add(new SelectListItem { Text = "Otro", Value = "Otro" });
            ViewBag.ltsMedios = ltsMedios;

            return View();
        }


        // FORMULARIO PARA INSERTAR NUEVO PACIENTE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FrmNewPaciente(Paciente model)
        {

            // ENVIAMOS EL MODELO A LA BD
            int result = BL.PacienteBL.IUDPaciente(model);

            // SI REGRESA 1 SIGNIFICA QUE INSERTO EL REGISTRO EXITOSAMENTE
            if (result.Equals(1))
            {
                ToastNotification.SetMessage("Paciente fue creado correctamente.", "Éxito", "1");
                return RedirectToAction("Index", "Paciente");
            }
            else
            {
                ToastNotification.SetMessage("No fue posible añadir un nuevo paciente", "Error", "0");
                return RedirectToAction("Index", "Paciente");
            }

        }

            
    }
}