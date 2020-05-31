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
    public partial class Index : System.Web.UI.Page
    {
        /*Llave para desencriptar la contraseña*/
        private string llave = "b14ca5898a4e4133bbce2ea2315a1916";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metodo que verifica el inicio de sesion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIS_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "select contraseña from usuario_externo where curp=@val1";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Val1", usuario.Text);
                cmd.CommandType = CommandType.Text;
                //cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) //Si tiene datos
                {
                    while (reader.Read())//Se leen
                    {
                        /*Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                            reader.GetString(1));*/
                        if(contra.Text == DecryptString(llave, reader.GetString(0)))//Si la contraseña coincide
                        {
                            Session["curp"] = usuario.Text;
                            Response.Redirect("Genera_ticket.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('La contraseña no es correcta');</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('El usuario no existe');</script>");
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


        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
            //the "ConnStringName" is the name of your Connection String that was set up from the Web.Config
        }

        /// <summary>
        /// Metodo que desencripta la contraseña
        /// </summary>
        /// <param name="key">La llave para desencriptar la contraseña</param>
        /// <param name="cipherText">La contraseña encriptada</param>
        /// <returns>La contraseña desencriptada</returns>
        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}