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
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Servicio_tickets
{
    public partial class _Default : Page
    {
        /*Llave para encriptar contraseñas*/
        private string llave = "b14ca5898a4e4133bbce2ea2315a1916";
        /// <summary>
        /// Se cargan los datos en los select cuando se carga la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            llenaNa();
            llenaTr();
        }

        /// <summary>
        /// Funcion que llena el select de Nivel academico
        /// </summary>
        private void llenaNa()
        {
            SqlConnection conn = new SqlConnection(GetConnectionString()); //Parametros de conexion
            string sql = "select * from Nivel_Academico"; //Query
            //Se sacan los datos y se meten en los select
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            conn.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            NA.DataSource = dt;
            NA.DataTextField = "nombre";
            NA.DataValueField = "idNA";
            NA.DataBind();
            conn.Close();
        }

        /// <summary>
        /// Funcion que llena el select de trabajo
        /// </summary>
        private void llenaTr()
        {
            SqlConnection conn = new SqlConnection(GetConnectionString()); //Parametros de conexion
            string sql = "select * from Trabajo"; //Query
            //Se sacan los datos y se meten en los select
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            conn.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Tr.DataSource = dt;
            Tr.DataTextField = "nombre";
            Tr.DataValueField = "idTrabajo";
            Tr.DataBind();
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
        /// <summary>
        /// Metodo que checa si el usuario ya existe
        /// </summary>
        /// <param name="curp">Recibe la curp que es la clave</param>
        /// <returns>true si existe, false de lo contrario</returns>
        protected bool checaSiexiste(string curp)
        {
            bool ban = false;
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "select * from usuario_externo where curp=@val1";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Val1", curp);
                cmd.CommandType = CommandType.Text;
                //cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) //Si tiene datos
                {
                    ban =  true;
                }
                else
                {
                    ban = false;
                }
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
            return ban;
        }

        /// <summary>
        /// Metodo que registra al usuario en la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void registra_Click1(object sender, EventArgs e)
        {
            //string[] nombcomp = nombre.Text.Split(' ');
            string passEnc = EncriptaCadena(llave, cont.Text);
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "insert into usuario_externo (idTabajo,idNivel_Academico,nombre_completo,curp,email,telefono,contraseña) values (@Val1,@Val2,@Val3,@Val4,@Val5,@Val6,@Val7)";
            //string sql = "insert into usuario_externo (idTabajo,idNivel_Academico,nombre,apellido_paterno,apellido_materno,curp,email,telefono,contraseña) values (@Val1,@Val2,@Val3,@Val4,@Val5,@Val6,@Val7,@Val8,@Val9)";
            if (cont.Text == cont2.Text)
            {
                if (tel.Text.All(char.IsDigit))
                {
                    if (!nombre.Text.Any(char.IsDigit))
                    {
                        if (!checaSiexiste(curp.Text))
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(sql, conn);
                                cmd.Parameters.AddWithValue("@Val1", Tr.SelectedValue);
                                cmd.Parameters.AddWithValue("@Val2", NA.SelectedValue);
                                cmd.Parameters.AddWithValue("@Val3", nombre.Text);
                                cmd.Parameters.AddWithValue("@Val4", curp.Text);
                                cmd.Parameters.AddWithValue("@Val5", email.Text);
                                cmd.Parameters.AddWithValue("@Val6", tel.Text);
                                cmd.Parameters.AddWithValue("@Val7", passEnc);
                                cmd.CommandType = CommandType.Text;
                                int a = cmd.ExecuteNonQuery();
                                Response.Redirect("Index.aspx");
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
                        else
                        {
                            Response.Write("<script>alert('Esa CURP ya está registrada.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('No ponga numeros en su nombre.');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Ponga solo numeros en el telefono');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Las 2 contraseñas no coinciden');</script>");
            }

        }

        /// <summary>
        /// Metodo que encripta la contraseña
        /// </summary>
        /// <param name="key">La llave para encriptar la contraseña</param>
        /// <param name="plainInput">Texto puro de la contraseña</param>
        /// <returns>La contraseña encriptada</returns>
        public static string EncriptaCadena(string key, string plainInput)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainInput);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
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

        /// <summary>
        /// Click en boton cancelar regresa al principio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Index.aspx");
			Server.Transfer("Index.aspx");

        }
    }
}