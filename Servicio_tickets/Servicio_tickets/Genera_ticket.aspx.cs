using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Servicio_tickets
{
    public partial class Genera_ticket : System.Web.UI.Page
    {
        /// <summary>
        /// Metodo que carga los datos de la sesion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["curp"] != null)
            {
                if (!IsPostBack)
                {
                    SqlConnection conn = new SqlConnection(GetConnectionString());
                    string sql = "select * from usuario_externo where curp=@val1";
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Val1", Session["curp"].ToString());
                        cmd.CommandType = CommandType.Text;
                        //cmd.ExecuteNonQuery();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows) //Si tiene datos
                        {
                            while (reader.Read())//Se leen
                            {
                                Session["id"] = reader.GetInt32(0);
                                Session["nombre"] = nombC.Text = reader.GetString(3);
                                usu.Text = reader.GetString(4);
                                Session["correo"] = correo.Text = reader.GetString(5);
                                Session["cel"] = tel.Text = reader.GetString(6);
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Ocurrio un error');</script>");
                            Response.Redirect("Index.aspx");
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
                    llenaProcesos();
                }
            }
            else
            {
                Response.Redirect("Index.aspx");
            }

            
}

        public void insertaTicket()
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "insert into Ticket (idServicio,idSolicitante,Fecha_ini,Fecha_fin,Estatus,Asunto) values (@Val1,@Val2,@Val3,@Val4,@Val5,@Val6)";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Val1", Serv.SelectedValue);
                cmd.Parameters.AddWithValue("@Val2", Int32.Parse(Session["id"].ToString()));
                cmd.Parameters.AddWithValue("@Val3", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@Val4", DBNull.Value);
                cmd.Parameters.AddWithValue("@Val5", 1);
                cmd.Parameters.AddWithValue("@Val6", asunto.Value);
                cmd.CommandType = CommandType.Text;
                int a = cmd.ExecuteNonQuery();
                if (a > 0) { insertaComentario(); }
                
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

        private void insertaComentario()
        {
            int idTick = dameIdultimo();
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "insert into Comentario (idTicket,idSolicitante,Descripcion) values (@Val1,@Val2,@Val3)";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Val1", idTick);
                cmd.Parameters.AddWithValue("@Val2", Int32.Parse(Session["id"].ToString()));
                cmd.Parameters.AddWithValue("@Val3", detalle.Value);
                cmd.CommandType = CommandType.Text;
                int a = cmd.ExecuteNonQuery();
                if (a > 0) { Response.Redirect("Misticket.aspx"); }

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

        private int dameIdultimo()
        {
            int val = 0;
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "select * from Ticket where idSolicitante=@Val1 and Asunto=@Val2";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Val1", Int32.Parse(Session["id"].ToString()));
                cmd.Parameters.AddWithValue("@Val2", asunto.Value);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) //Si tiene datos
                {
                    while (reader.Read())//Se leen
                    {
                       val = reader.GetInt32(0);
                    }
                }
                else
                {
                    val = 0;
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
            return val;
        }

        private void llenaProcesos()
        {
            SqlConnection conn = new SqlConnection(GetConnectionString()); //Parametros de conexion
            string sql = "select * from Unidad"; //Query
            //Se sacan los datos y se meten en los select
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            conn.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Pro.DataSource = dt;
            Pro.DataTextField = "nombre";
            Pro.DataValueField = "idUnidad";
            Pro.DataBind();
            conn.Close();
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

        protected void envia_Click(object sender, EventArgs e)
        {
            insertaTicket();
        }

        protected void Pro_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Pro_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString()); //Parametros de conexion
            string sql = "select * from Servicio where idUnidad=" + Pro.SelectedValue; //Query
            //Se sacan los datos y se meten en los select
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            conn.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Serv.DataSource = dt;
            Serv.DataTextField = "nombre";
            Serv.DataValueField = "idServicio";
            Serv.DataBind();
            conn.Close();
        }
    }


}