﻿using System;
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
    public partial class Misticket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["curp"] != null)
            {
                llenaActivos();
                llenaEspera();
                llenaCerrados();
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

        /// <summary>
        /// Metodo que llena los tickets en estado activo
        /// </summary>
        private void llenaActivos()
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "select t.* from Ticket t inner join usuario_externo u on t.idSolicitante = u.idUsuario_Externo where t.Estatus=0 and t.idSolicitante="+Session["id"].ToString();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                HtmlGenericControl divcontrol;
                HyperLink link;
                if (reader.HasRows) //Si tiene datos
                {
                    while (reader.Read())//Se leen
                    {
                        int idticket = reader.GetInt32(0);
                        int Estatus = reader.GetInt32(5);
                        string asunto = reader.GetString(6);
                        divcontrol = new HtmlGenericControl();
                        divcontrol.Attributes["class"] = "row";
                        divcontrol.Attributes["style"] = "margin-bottom:10px";
                        divcontrol.TagName = "div";
                        divact.Controls.Add(divcontrol);
                        link = new HyperLink
                        {
                            Text = asunto,
                            NavigateUrl = "Ticket.aspx?id="+idticket.ToString()+"&estatus="+Estatus.ToString(),
                            ID = idticket.ToString()
                        };
                        link.Style.Add("margin-left", "15px");
                        divcontrol.Controls.Add(link);
                    }
                }
                else
                {
                    divcontrol = new HtmlGenericControl();
                    divcontrol.Attributes["class"] = "row";
                    divcontrol.Attributes["style"] = "margin-bottom:10px";
                    divcontrol.TagName = "div";
                    divact.Controls.Add(divcontrol);
                    Label lab = new Label();
                    lab.Text = "No hay tickets activos por el momento";
                    lab.Style.Add("margin-left", "15px");
                    divcontrol.Controls.Add(lab);
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

        /// <summary>
        /// Metodo que llena los tickets en estado espera
        /// </summary>
        private void llenaEspera()
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "select t.* from Ticket t inner join usuario_externo u on t.idSolicitante = u.idUsuario_Externo where t.Estatus=1 and t.idSolicitante=" + Session["id"].ToString();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                HtmlGenericControl divcontrol;
                HyperLink link;
                if (reader.HasRows) //Si tiene datos
                {
                    while (reader.Read())//Se leen
                    {
                        int idticket = reader.GetInt32(0);
                        int Estatus = reader.GetInt32(5);
                        string asunto = reader.GetString(6);
                        divcontrol = new HtmlGenericControl();
                        divcontrol.Attributes["class"] = "row";
                        divcontrol.Attributes["style"] = "margin-bottom:10px";
                        divcontrol.TagName = "div";
                        divesp.Controls.Add(divcontrol);
                        link = new HyperLink
                        {
                            Text = asunto,
                            NavigateUrl = "Ticket.aspx?id=" + idticket.ToString() + "&estatus=" + Estatus.ToString(),
                            ID = idticket.ToString()
                        };
                        link.Style.Add("margin-left", "15px");
                        divcontrol.Controls.Add(link);
                    }
                }
                else
                {
                    divcontrol = new HtmlGenericControl();
                    divcontrol.Attributes["class"] = "row";
                    divcontrol.Attributes["style"] = "margin-bottom:10px";
                    divcontrol.TagName = "div";
                    divesp.Controls.Add(divcontrol);
                    Label lab = new Label();
                    lab.Text = "No hay tickets en espera por el momento";
                    lab.Style.Add("margin-left", "15px");
                    divcontrol.Controls.Add(lab);
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

        /// <summary>
        /// Metodo que llena los tickets en estado activo
        /// </summary>
        private void llenaCerrados()
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "select t.* from Ticket t inner join usuario_externo u on t.idSolicitante = u.idUsuario_Externo where t.Estatus=2 and t.idSolicitante=" + Session["id"].ToString();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                HtmlGenericControl divcontrol;
                HyperLink link;
                if (reader.HasRows) //Si tiene datos
                {
                    while (reader.Read())//Se leen
                    {
                        int idticket = reader.GetInt32(0);
                        int Estatus = reader.GetInt32(5);
                        string asunto = reader.GetString(6);
                        divcontrol = new HtmlGenericControl();
                        divcontrol.Attributes["class"] = "row";
                        divcontrol.Attributes["style"] = "margin-bottom:10px";
                        divcontrol.TagName = "div";
                        divcerr.Controls.Add(divcontrol);
                        link = new HyperLink
                        {
                            Text = asunto,
                            NavigateUrl = "Ticket.aspx?id=" + idticket.ToString() + "&estatus=" + Estatus.ToString(),
                            ID = idticket.ToString()
                        };
                        link.Style.Add("margin-left", "15px");
                        divcontrol.Controls.Add(link);
                    }
                }
                else
                {
                    divcontrol = new HtmlGenericControl();
                    divcontrol.Attributes["class"] = "row";
                    divcontrol.Attributes["style"] = "margin-bottom:10px";
                    divcontrol.TagName = "div";
                    divcerr.Controls.Add(divcontrol);
                    Label lab = new Label();
                    lab.Text = "No hay tickets cerrados por el momento";
                    lab.Style.Add("margin-left", "15px");
                    divcontrol.Controls.Add(lab);
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