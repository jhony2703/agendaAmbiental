using AgendaAmbiental_v6.LoginServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace AgendaAmbiental_v6
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                /* Inicializar Variables */
                int idAplicacion = 126;
                string direccionBase = "http://uaslp.mx";

                if (Request.QueryString["Ticket"] == null)
                {
                    XDocument ticketXml;
                    LoginServiceClient proxy = new LoginServiceClient("WSHttpBinding_ILoginService");
                    if (Request.QueryString["ReturnUrl"] == null)
                        ticketXml = XDocument.Parse(proxy.NuevaSesion(idAplicacion));
                    else
                        ticketXml = XDocument.Parse(proxy.NuevaSesionConUrlRetorno(idAplicacion, direccionBase + Request.QueryString["ReturnUrl"]));
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
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        int ticket;
                        int valido = 0;
                        string claveSesion = Server.HtmlEncode(Request.Cookies["SC"].Value);
                        Response.Cookies["SC"].Expires = DateTime.Now.AddDays(-1);
                        //Validar cookie
                        if (int.TryParse(Request.QueryString["Ticket"], out ticket))
                        {
                            LoginServiceClient proxy = new LoginServiceClient("WSHttpBinding_ILoginService");
                            valido = proxy.ValidaCliente(ticket, claveSesion);
                            proxy.Close();
                        }

                        switch (valido)
                        {
                            case 0: // Cookie no es valida o expiro Ticket.
                                FailureDiv.Visible = true;
                                FailureText.Text = "Inicio de Sesión no valido.";
                                break;
                            case 1: // Ok  Cookie Valida!

                                //Obtener Resultado
                                LoginServiceClient proxy = new LoginServiceClient("WSHttpBinding_ILoginService");
                                XDocument estadoXml = XDocument.Parse(proxy.EstadoUsuario(ticket, claveSesion));
                                proxy.Close();

                                if (estadoXml.Root.HasAttributes)
                                {
                                    //Verificar que no exista error    
                                    XAttribute errorAttribute = estadoXml.Root.Attribute("TextoError");
                                    if (errorAttribute == null)
                                    {
                                        //Si esta autentificado Autentificar por programacion la sesion local.
                                        try
                                        {
                                            if (bool.Parse(estadoXml.Root.Attribute("Autenticado").Value))
                                            {
                                                /*Aqui se redirecciona a otra pagina*/
                                                FormsAuthentication.RedirectFromLoginPage(estadoXml.Root.Attribute("Usuario").Value, false);
                                                return;
                                            }
                                            else FailureText.Text = "El Usuario no esta autentificado";
                                        }
                                        catch
                                        {
                                            FailureText.Text = "Error: No fue posible autentificar al usuario.";
                                        }
                                    }
                                    else
                                        FailureText.Text = "Se agoto el tiempo.";

                                }
                                else
                                {
                                    FailureText.Text = "El Ticket Expiro.";
                                }
                                FailureDiv.Visible = true;
                                break;
                            case -1: // Error al conectar, no se pudo validar cookie!
                                FailureDiv.Visible = true;
                                FailureText.Text = "No se pudo validar, Intentelo de nuevo.";
                                break;
                        }
                    }
                }
            }
        }
    }
}