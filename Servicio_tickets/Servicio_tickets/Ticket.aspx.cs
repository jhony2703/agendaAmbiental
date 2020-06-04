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
                if (Request.QueryString["id"] != null && Request.QueryString["estatus"] != null)
                {
                    llenaConversacion(Request.QueryString["id"]);
                    llenaInfo(Request.QueryString["id"]);
                }
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
                        Session["ticketid"] = reader.GetInt32(1);
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
                if(Request.QueryString["estatus"].ToString() == "2")
                {
                    divcerrar.Visible = false;
                    divabr.Visible = true;
                    Respuesta.Disabled = true;
                    responde.Enabled = false;
                }
                else
                {
                    divcerrar.Visible = true;
                    divabr.Visible = false;
                    Respuesta.Disabled = false;
                    responde.Enabled = true;
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

        private void llenaInfo(string id)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "select s.nombre as Servicio, u.nombre as Unidad, e.nombre_completo as Encargado from Servicio s inner join Ticket t on t.idServicio = s.idServicio inner join Unidad u on u.idUnidad=s.idUnidad inner join Encargado e on e.RPE = u.RPE where t.idTicket=" + id + ";";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) //Si tiene datos
                {
                    while (reader.Read())//Se leen
                    {
                        HtmlGenericControl divrow = new HtmlGenericControl();
                        HtmlGenericControl divcol = new HtmlGenericControl();
                        HtmlGenericControl p = new HtmlGenericControl();
                        divrow.Attributes["class"] = "row";
                        divrow.TagName = "div";
                        divinfo.Controls.Add(divrow);
                        divcol.Attributes["class"] = "col-sm";
                        divcol.TagName = "div";
                        divrow.Controls.Add(divcol);
                        p.InnerText = "Area:"+ reader.GetString(1);
                        p.TagName = "p";
                        divcol.Controls.Add(p);

                        HtmlGenericControl divcol2 = new HtmlGenericControl();
                        HtmlGenericControl p2 = new HtmlGenericControl();
                        divcol2.Attributes["class"] = "col-sm";
                        divcol2.TagName = "div";
                        divrow.Controls.Add(divcol2);
                        p2.InnerText = "Servicio:" + reader.GetString(0);
                        p2.TagName = "p";
                        divcol2.Controls.Add(p2);

                        HtmlGenericControl divcol3 = new HtmlGenericControl();
                        HtmlGenericControl p3 = new HtmlGenericControl();
                        divcol3.Attributes["class"] = "col-sm";
                        divcol3.TagName = "div";
                        divrow.Controls.Add(divcol3);
                        p3.InnerText = "Encargado:" + reader.GetString(2);
                        p3.TagName = "p";
                        divcol3.Controls.Add(p3);

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

        protected void cerrar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "UPDATE Ticket SET Estatus=2, Fecha_fin=@Val1 where idTicket=@Val2";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Val1", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@Val2", Int32.Parse(Session["ticketid"].ToString()));
                cmd.CommandType = CommandType.Text;
                int a = cmd.ExecuteNonQuery();
                Response.Redirect("Misticket.aspx");
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

        protected void responde_Click(object sender, EventArgs e)
        {
            insertComentario();
            actualizaEstatus();
        }

        private void actualizaEstatus()
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "UPDATE Ticket SET Estatus=1 where idTicket=@Val1";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Val1", Int32.Parse(Session["ticketid"].ToString()));
                cmd.CommandType = CommandType.Text;
                int a = cmd.ExecuteNonQuery();
                if (a > 0) { Response.Redirect("Ticket.aspx?id=" + Session["ticketid"].ToString() + "&estatus=1"); }
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

        private void insertComentario()
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "insert into Comentario (idTicket,idSolicitante,Descripcion) values (@Val1,@Val2,@Val3)";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Val1", Int32.Parse(Session["ticketid"].ToString()));
                cmd.Parameters.AddWithValue("@Val2", Int32.Parse(Session["id"].ToString()));
                cmd.Parameters.AddWithValue("@Val3", Respuesta.Value);
                cmd.CommandType = CommandType.Text;
                int a = cmd.ExecuteNonQuery();

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

        protected void open_tick(object sender, EventArgs e)
        {
            divcerrar.Visible = true;
            divabr.Visible = false;
            Respuesta.Disabled = false;
            responde.Enabled = true;
        }
    }
}