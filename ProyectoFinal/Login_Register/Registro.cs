using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ProyectoFinal
{
    public partial class Registro : DevExpress.XtraEditors.XtraForm
    {
        Form1 Inicio;
        public Registro(Form1 Inicio)
        {
            InitializeComponent();
            this.Inicio = Inicio;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Helper helperclass = new Helper();
            using (SqlConnection conection = new SqlConnection(helperclass.getConnectionDB(@"(localdb)\BrunsdDB1", "BrunsdDB1")))
            {
                try
                {
                    conection.Open();
                    // @ para no poder hacer inserción de código al hacer login.

                    //letras de la A a la Z, mayusculas y minusculas
                    Regex letras = new Regex(@"[a-zA-z]");
                    //digitos del 0 al 9
                    Regex numeros = new Regex(@"[0-9]");
                    //cualquier caracter del conjunto
                    Regex caracEsp = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");

                    int longitud = 6;

                    if (String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(textpass.Text) || String.IsNullOrEmpty(textpass2.Text))
                    {

                        MessageBox.Show("Algunos campos estan vacios, por favor reviselo y rellenelos todos.");
                        textpass.Text = "";
                        textpass2.Text = "";

                    }
                    else if (!letras.IsMatch(textpass.Text) || !numeros.IsMatch(textpass.Text) || !caracEsp.IsMatch(textpass.Text) || textpass.Text.Length < longitud){
                        MessageBox.Show("Compruebe por favor que la contraseña contiene al menos una letra, un número o un caracter especiales y que tenga una longitud de más de 6 caracteres.");
                        textpass.Text = "";
                        textpass2.Text = "";
                    }
                    else
                    {

                        string queryLogin = "SELECT Usuario FROM Usuarios WHERE Usuario=@Usuario";

                        SqlCommand cmdLogin = new SqlCommand(queryLogin, conection);
                        cmdLogin.Parameters.AddWithValue("@Usuario", username.Text);

                        Boolean acces = false;

                        using (SqlDataReader dataReader = cmdLogin.ExecuteReader())
                        {

                            while (dataReader.Read())
                            {
                                MessageBox.Show("Nombre de usuario ya registrado");
                                acces = true;
                                textpass.Text = "";
                                textpass2.Text = "";
                            }
                        }
                        if (!acces)
                        {
                            if (!Object.Equals(textpass.Text, textpass2.Text))
                            {
                                MessageBox.Show("No coinciden las contraseñas, vuelva a introducirlas.");
                                textpass.Text = "";
                                textpass2.Text = "";
                            }
                            else
                            {
                                try
                                {

                                    var key = "b14ca5898a4e4133bbce2ea2315a1916";
                                    var str = textpass.Text;
                                    var encryptedString = ProyectoFinal.Helper.EncryptString(key, str);

                                    string queryInsert = "INSERT INTO Usuarios(Usuario, Contraseña, Rol) values('" + username.Text + "', '" + encryptedString + "', '" + 1 + "')";

                                    SqlCommand cmdInsert = new SqlCommand(queryInsert, conection);
                                    cmdInsert.ExecuteNonQuery();
                                    XtraMessageBox.Show("Usuario registrado correctamente. Por favor logueate a continuación.", "Confirmacion", MessageBoxButtons.OK);
                                    this.Close();
                                    Inicio.Show();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error " + ex.Message + " al intentar crear un usuario");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message + " al intentar conectarse a la base de datos.");
                }
            }
        }
            
private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }   
    }
