using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace Servicio_tickets
{
    public partial class Ticket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["curp"] != null)
            {
                if (Request.QueryString["id"] != null)
                    //Response.Write("From Page1 param1 value=" + Request.QueryString["id"]);
                    llenaConversacion(Request.QueryString["id"]);
                else
                    Response.Redirect("Misticket.aspx");
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

        private void llenaConversacion(string id)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "select c.* from Comentario c where c.idTicket="+id+";";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                string msj;
                int idmsj;
                if (reader.HasRows) //Si tiene datos
                {
                    while (reader.Read())//Se leen
                    {
                        Session["ticketid"] = reader.GetInt32(0);
                        idmsj = reader.GetInt32(2);
                        msj = reader.GetString(3);
                        if(idmsj.ToString() != Session["id"].ToString())
                        {
                            creaMsjUs(msj);
                        }
                        else
                        {
                            creaMsjResp(msj);
                        }
                    }
                }
                reader.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        private void creaMsjUs(string msj)
        {
            HtmlGenericControl divcontrol = new HtmlGenericControl();
            HtmlGenericControl img = new HtmlGenericControl();
            HtmlGenericControl p = new HtmlGenericControl();
            divcontrol.Attributes["class"] = "chatCont";
            divcontrol.TagName = "div";
            historial.Controls.Add(divcontrol);
            img.Attributes["src"] = "Imagenes/icono_us.png";
            img.Attributes["style"] = "width:100%;";
            img.Attributes["alt"] = "Avatar";
            img.TagName = "img";
            divcontrol.Controls.Add(img);
            p.Attributes["style"] = "text-align:justify";
            p.InnerText = msj;
            p.TagName = "p";
            divcontrol.Controls.Add(p);
        }

        private void creaMsjResp(string msj)
        {
            HtmlGenericControl divcontrol = new HtmlGenericControl();
            HtmlGenericControl img = new HtmlGenericControl();
            HtmlGenericControl p = new HtmlGenericControl();
            divcontrol.Attributes["class"] = "chatCont darker";
            divcontrol.TagName = "div";
            historial.Controls.Add(divcontrol);
            img.Attributes["src"] = "Imagenes/icono_us.png";
            img.Attributes["class"] = "right";
            img.Attributes["style"] = "width:100%;";
            img.Attributes["alt"] = "Avatar";
            img.TagName = "img";
            divcontrol.Controls.Add(img);
            p.Attributes["style"] = "text-align:justify";
            p.InnerText = msj;
            p.TagName = "p";
            divcontrol.Controls.Add(p);
        }

        /// <summary>
        /// Metodo que regresa la cadena de conexion a la base de datos.
        /// </summary>
        /// <returns>Nombre de la conexión a la BD</returns>
        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
            //the "ConnStringName" is the name of your Connection String that was set up from the Web.Config
        }
    }
}