using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consultorio.Models
{
    // MODELO QUE ALIMENTA LAS NOTIFICACIONES TOAST
    public class ManageViewModels
    {
        public static class ToastNotification
        {
            public static string Message { get; set; }
            public static string Status { get; set; }
            public static string Title { get; set; }

            /// <summary>
            /// Método para limpiar la información del Mensaje y Título
            /// </summary>
            public static void ResetData()
            {
                Message = "";
                Status = "";
            }

            /// <summary>
            /// Método para fijar Mensaje y Título que mostrará la ventana Toast
            /// </summary>
            /// <param name="prMessage">Mensaje de la ventana</param>
            /// <param name="prTitle">Título mostrado en la ventana</param>
            /// <param name="prStatus">Tipo de ventana Toast, 1=Succes, 0=Error, 2=Warning</param>
            public static void SetMessage(string prMessage, string prTitle, string prStatus)
            {
                Message = prMessage;
                Status = prStatus;
                Title = prTitle;
            }
        }
    }
}