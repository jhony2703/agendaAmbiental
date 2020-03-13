using AgendaAmbiental.LoginServiceReference;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml.Linq;

namespace AgendaAmbiental.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        /*public ActionResult Index()
        {

            return View();
        }*/

        public ActionResult Login(string ticket = null, string ReturnUrl = null)
        {
            int idAplicacion = 0;
            bool esDebug = true;
            string direccionBase;

            if (bool.TryParse(ConfigurationManager.AppSettings["EsDebug"], out esDebug))
            {
                if (esDebug) direccionBase = ConfigurationManager.AppSettings["DireccionBaseDebug"];
                else direccionBase = ConfigurationManager.AppSettings["DireccionBaseRelease"];
            }
            else
            {
                throw new Exception("Error en archivo de configuración. Sección: appSettings Key: EsDebug");
            }


            if (ticket == null)
            {
                XDocument ticketXml;
                LoginServiceClient proxy = new LoginServiceClient("WSHttpBinding_ILoginService");
                if (ReturnUrl == null)
                    ticketXml = XDocument.Parse(proxy.NuevaSesion(idAplicacion));
                else
                    ticketXml = XDocument.Parse(proxy.NuevaSesionConUrlRetorno(idAplicacion, direccionBase + ReturnUrl));
                proxy.Close();
                HttpCookie aCookie = new HttpCookie("SC");
                aCookie.Value = ticketXml.Root.LastAttribute.Value;
                aCookie.Expires = DateTime.Now.AddMinutes(10.0);
                Response.Cookies.Add(aCookie);
                Response.Redirect("https://serviciosenlinea.uaslp.mx/LoginGateway/Default.aspx?Ticket=" + ticketXml.Root.FirstAttribute.Value);
            }
            else
            {
                if (Request.Cookies["SC"] == null)
                {
                    return RedirectToAction("LogOn");
                }
                else
                {
                    int ticket_parsed;
                    int valido = 0;
                    string claveSesion = Server.HtmlEncode(Request.Cookies["SC"].Value);
                    Response.Cookies["SC"].Expires = DateTime.Now.AddDays(-1);
                    if (int.TryParse(ticket, out ticket_parsed))
                    {
                        LoginServiceClient proxy = new LoginServiceClient("WSHttpBinding_ILoginService");
                        valido = proxy.ValidaCliente(ticket_parsed, claveSesion);
                        proxy.Close();
                    }

                    switch (valido)
                    {
                        case 0: // Cookie no es valida o expiro Ticket.
                            ViewBag.Error = "Inicio de Sesión no valido.";
                            return View("Error");
                        case 1: // Ok  Cookie Valida!
                            //Obtener Resultado
                            LoginServiceClient proxy = new LoginServiceClient("WSHttpBinding_ILoginService");
                            XDocument estadoXml = XDocument.Parse(proxy.EstadoUsuario(ticket_parsed, claveSesion));
                            proxy.Close();

                            if (estadoXml.Root.HasAttributes)
                            {

                                XAttribute errorAttribute = estadoXml.Root.Attribute("TextoError");
                                if (errorAttribute == null)
                                {

                                    try
                                    {
                                        if (bool.Parse(estadoXml.Root.Attribute("Autenticado").Value))
                                        {
                                            FormsAuthentication.RedirectFromLoginPage(estadoXml.Root.Attribute("Usuario").Value, false);
                                            //return;
                                        }
                                        ViewBag.Error = "El Usuario no esta autentificado";
                                        return View("Error");
                                    }
                                    catch
                                    {
                                        ViewBag.Error = "Error: No fue posible autentificar al usuario.";
                                        return View("Error");
                                    }
                                }
                                else
                                {
                                    ViewBag.Error = "Se agoto el tiempo.";
                                    return View("Error");
                                }

                            }
                            else
                            {
                                ViewBag.Error = "El Ticket Expiro.";
                                return View("Error");
                            }
                            break;
                        case -1: // Error al conectar, no se pudo validar cookie!                                                                
                            ViewBag.Error = "No se pudo validar, Intentelo de nuevo.";
                                return View("Error");
                            break;
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string ticket)
        {
            return View();
        }

    }
}