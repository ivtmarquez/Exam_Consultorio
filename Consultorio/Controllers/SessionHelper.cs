using System;
using System.Web;
using System.Web.Security;

namespace Consultorio.Controllers
{
    public class SessionHelper
    {
        // Comprueba que el usuario esté autenticado
        public static bool ExistUserInSession()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        // Elimina autenticación de usuario
        public static void DestroyUserSession()
        {
            FormsAuthentication.SignOut();
        }

        // Devuelve ID de usuario logueado
        public static string GetUser()
        {
            string lcUserID = "";

            // Si el usuario está Autenticado
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                // Obtiene ID de usuario guardado en Cookie encriptada
                FormsAuthenticationTicket lcTicket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                if (lcTicket != null)
                {
                    lcUserID = lcTicket.UserData;
                }
            }

            return lcUserID;
        }


        // Almacena y encripta ID de usuario en Cookie
        // Persiste sesión de usuario de ser necesario
      
        public static void AddUserToSession(string prID, bool prPersist)
        {
            // Crea una cookie de autenticación para un ID de usuario determinado
            HttpCookie lcAuthCookie = FormsAuthentication.GetAuthCookie(prID, prPersist);

            lcAuthCookie.Name = FormsAuthentication.FormsCookieName;

            if (!prPersist)
            {
                lcAuthCookie.Expires = DateTime.Now.AddMinutes(30);
            }

            // Obtiene el ticket de autenticación de formularios
            FormsAuthenticationTicket lcTicket = FormsAuthentication.Decrypt(lcAuthCookie.Value);
            FormsAuthenticationTicket lcNewTicket = new FormsAuthenticationTicket(lcTicket.Version, lcTicket.Name, lcTicket.IssueDate, lcTicket.Expiration, lcTicket.IsPersistent, prID);

            // Cifra ticket y crea cookie para almacenar información
            lcAuthCookie.Value = FormsAuthentication.Encrypt(lcNewTicket);
            HttpContext.Current.Response.Cookies.Add(lcAuthCookie);
        }
    }
}