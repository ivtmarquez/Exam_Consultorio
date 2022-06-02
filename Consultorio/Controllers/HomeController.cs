using Consultorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Consultorio.Models.ManageViewModels;

namespace Consultorio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // LOGIN
        public ActionResult FrmLogin(Medico model)
        {
            Medico med = new Medico();
            // REVISAR SI EXISTE EL USUARIO EN BD
            med = BL.MedicoBL.getLogin(model);
            // SI LA CONSULTA REGRESA EL MODELO CON INFORMACION EL USUARIO EXISTE.
            if (med.IDMEDICO > 0)
            {
                //AGREGAMOS LA SESIÓN
                SessionHelper.AddUserToSession(model.EMAIL, true);
                ToastNotification.SetMessage("¡Bienvenido" + model.NOMBRE + "!", "Éxito", "1");
                return RedirectToAction("Index", "Medico", med);
            }
            else
            {
                // DATOS INCORRECTOS, CARGAMOS NUEVAMENTE EL LOGIN
                ToastNotification.SetMessage("Email y/o contraseña son incorrectos", "Error", "0");
                return RedirectToAction("Index", "Home");
            }
        }

        // FORMULARIO PARA REGISTRAR UN NUEVO MEDICO
        public ActionResult FrmRegister(Medico model)
        {
            // VERIFICR QUE LAS CONTRASEÑAS COINDIDAN
            if (model.PASSWORD.Equals(model.PASSWORDCONFIRM))
            {
                // REVISAR SI EXISTE EN BASE DE DATOS
                int result = BL.MedicoBL.IUDMedico(model);

                // ALTA DE USUARIO FUE EXITOSO
                if (result.Equals(1))
                {
                    //AGREGAMOS LA SESIÓN
                    ToastNotification.SetMessage("Usuario fue creado correctamente.", "Éxito", "1");
                    return RedirectToAction("Index", "Home");
                }
                // EL USUARIO YA EXISTE O NO SE PUEDO DAR DE ALTA
                else
                {
                    ToastNotification.SetMessage("El usuario ya existe.", "Error", "0");
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ToastNotification.SetMessage("Contraseñas no coinciden", "Error", "0");
                return RedirectToAction("Index", "Home");
            }
            
        }
        
        // LOGOUT, DESTRUIMOS LA SESION
        public ActionResult Salir()
        {
            //DESTRUIMOS LA SESION
            SessionHelper.DestroyUserSession();
            return RedirectToAction("Index", "Home");
        }
    }
}