using ProyectoFinal.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void botonRegistro_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registro rg = new Registro(this);
            rg.Show();



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void botonLogin_Click(object sender, EventArgs e)
        {
            //Nos conectamos a la base de datos.
            string nombreUsuario = "";
            string contraUsuario = "";
            Helper helperclass = new Helper();

            

            using (SqlConnection conection = new SqlConnection(helperclass.getConnectionDB(@"(localdb)\BrunsdDB1","BrunsdDB1")))
            {
                try
                {
                    conection.Open();
                    // @ para no poder hacer inserción de código al hacer login.

                    var key = "b14ca5898a4e4133bbce2ea2315a1916";

                    string queryLogin = "SELECT Usuario , Contraseña FROM Usuarios WHERE Usuario=@Usuario";

                    SqlCommand cmdLogin = new SqlCommand(queryLogin, conection);
                    cmdLogin.Parameters.AddWithValue("@Usuario", textuser.Text);


                    string queryRol = "SELECT Rol FROM Usuarios WHERE Usuario=@Usuario";

                    SqlCommand cmdRol = new SqlCommand(queryRol, conection);
                    cmdRol.Parameters.AddWithValue("@Usuario", textuser.Text);

                    Boolean acces = false;

                    using (SqlDataReader dataReader = cmdLogin.ExecuteReader())
                    { 
                        while (dataReader.Read())
                        {
                            //guardamos nombre de usuario
                            nombreUsuario = dataReader["Usuario"].ToString();
                            contraUsuario = dataReader["Contraseña"].ToString();

                            var decryptedString = ProyectoFinal.Helper.DecryptString(key, contraUsuario);

                            if (textpassword.Text == decryptedString)
                            {
                                acces = true;
                            }
                        }
                        if (!acces)
                        {
                            MessageBox.Show("Usuario y/o contraseña incorrecta.");
                        }
                    }

                    if (acces == true)
                    {
                        using (SqlDataReader dataRead = cmdRol.ExecuteReader())
                        {
                            while (dataRead.Read())
                            {
                                if (dataRead["Rol"].ToString().Equals("1"))
                                {
                                    //usuario normal
                                    lobby1 l1 = new lobby1(nombreUsuario);
                                    l1.Show();
                                    this.Hide();

                                }
                                else if (dataRead["Rol"].ToString().Equals("2"))
                                {
                                    adminLobby ap = new adminLobby();
                                    ap.Show();
                                    this.Hide();
                                }
                            }
                                
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message + " al intentar a la base de datos.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


