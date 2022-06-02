using Consultorio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Consultorio.Models.ManageViewModels;

namespace Consultorio.Controllers
{
    public class MedicoController : Controller
    {
        // GET: Medico

        public ActionResult Index(Medico model)
        {
            return View(model);
        }

        // CARGA TODA LA INFORMACION DE LAS CITAS CREADAS, ASI COMO LAS LISTAS DE MEDICO Y PACIENTE.
        public ActionResult Cita()
        {
            // SE LLENA EL SELECT DE LOS PACIENTES
            List<SelectListItem> listPacientes = new List<SelectListItem>();
            listPacientes = BL.PacienteBL.getPaciente();
            ViewBag.listPacientes = listPacientes;

            // SE LLENA EL SELECT DE LOS MEDICOS
            List<SelectListItem> listMedico = new List<SelectListItem>();
            listMedico = BL.MedicoBL.getMedico();
            ViewBag.listMedico = listMedico;

            // SELECT DE SI SE CUENTA O NO CON ESTUDIOS 
            var listEstudios = new List<SelectListItem>();
            listEstudios.Add(new SelectListItem { Text = "Si", Value = "1" });
            listEstudios.Add(new SelectListItem { Text = "No", Value = "0" });
            ViewBag.listEstudios = listEstudios;

            // EXTRAEMOS TODAS LAS CITAS DE LA BASE DE DATOS
            ViewBag.Citas = BL.MedicoBL.getCitas();

            return View();
        }

        //FORMULARIO PARA CREAR UNA NUEVA CITA
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FrmNewCita(Cita model, HttpPostedFileBase expediente)
        {
            int result = 0, result_img = 0;
            string extension = "";

            // REVISAMOS SI EL ARCHIVO DE EXPEDIENTE NO ESTA VACIO
            if (expediente != null)
            {
                // CREAMOS LA CARPETA DONDE DE ALOJARAN LOS EXPEDIENTES
                string carpeta = Path.Combine(Server.MapPath("~/EXPEDIENTES"));
                System.IO.Directory.CreateDirectory(carpeta);

                try
                {
                    //OBTENEMOS LA EXTENSION DEL ARCHIVO CARGADO
                    extension = Path.GetExtension(expediente.FileName);
                    //ASIGNAMOS UN NOMBRE LA ARCHIVO Y LO GUARDAMOS
                    string path = Path.Combine(carpeta, Path.GetFileName(model.PACIENTE + "_" + model.DIACITA + extension));
                    expediente.SaveAs(path);
                    result_img = 1;
                }
                catch (Exception ex)
                {
                    result_img = -1;
                }         

            }

            // ASIGNAMOS EL NOMBRE DEL EXPEDIENTE AL MODELO PARA GUARDARLO EN BD.
            model.EXPEDIENTE = model.PACIENTE + "_" + model.DIACITA + extension;

            // LLAMAMOS AL METODO PARA INSERTAR LA CITA
            result = BL.MedicoBL.IUDCita(model); 

            // SI EL ARCHIVO SE GUARDO CON EXITO Y SE CREO LA CITA
            if (result.Equals(1) && result_img.Equals(1))
            {
                ToastNotification.SetMessage("Cita fue creada correctamente.", "Éxito", "1");
                return RedirectToAction("Cita", "Medico");
            }
            else
            {
                ToastNotification.SetMessage("No fue posible crear la cita", "Error", "0");
                return RedirectToAction("Cita", "Medico");
            }

        }
        
    }
}