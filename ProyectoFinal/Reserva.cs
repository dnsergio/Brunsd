using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class Reserva : Form
    {
        string nombreusuario;
        Helper.wrapperProduct product;
        List<String> listatiendas;
        String type;
        pro_multii pro;
        pro_elec elec;
        pro_garden garden;
        pro_home home;
        pro_other other;
        pro_ropa ropa;
        pro_sport sport;
        pro_videog videog;
        sale2 sale;
        public Reserva() 
        {
            InitializeComponent();
        }
        public Reserva(Helper.wrapperProduct product, List<String> listatiendas, string nombreusuario, pro_multii pro)
        {
            InitializeComponent();

            foreach (string option in listatiendas)
            {
                comboBox1.Items.Add(option);
            }

            textBox1.Text = product.Name;
            textBox2.Text = product.Category;

            label6.Text += product.Stock.ToString();

            this.nombreusuario = nombreusuario;

            this.pro = pro;

            this.product = product;
            type = "multi";
        }
        public Reserva(Helper.wrapperProduct product, List<String> listatiendas, string nombreusuario, pro_elec elec)
        {
            InitializeComponent();

            foreach (string option in listatiendas)
            {
                comboBox1.Items.Add(option);
            }

            textBox1.Text = product.Name;
            textBox2.Text = product.Category;

            label6.Text += product.Stock.ToString();

            this.nombreusuario = nombreusuario;

            this.elec = elec;

            this.product = product;
            type = "elec";
        }
        public Reserva(Helper.wrapperProduct product, List<String> listatiendas, string nombreusuario, pro_garden garden)
        {
            InitializeComponent();

            foreach (string option in listatiendas)
            {
                comboBox1.Items.Add(option);
            }

            textBox1.Text = product.Name;
            textBox2.Text = product.Category;

            label6.Text += product.Stock.ToString();

            this.nombreusuario = nombreusuario;

            this.garden = garden;

            this.product = product;
            type = "garden";
        }
        public Reserva(Helper.wrapperProduct product, List<String> listatiendas, string nombreusuario, pro_home home)
        {
            InitializeComponent();

            foreach (string option in listatiendas)
            {
                comboBox1.Items.Add(option);
            }

            textBox1.Text = product.Name;
            textBox2.Text = product.Category;

            label6.Text += product.Stock.ToString();

            this.nombreusuario = nombreusuario;

            this.home = home;

            this.product = product;
            type = "home";
        }
        public Reserva(Helper.wrapperProduct product, List<String> listatiendas, string nombreusuario, pro_other other)
        {
            InitializeComponent();

            foreach (string option in listatiendas)
            {
                comboBox1.Items.Add(option);
            }

            textBox1.Text = product.Name;
            textBox2.Text = product.Category;

            label6.Text += product.Stock.ToString();

            this.nombreusuario = nombreusuario;

            this.other = other;

            this.product = product;
            type = "other";
        }
        public Reserva(Helper.wrapperProduct product, List<String> listatiendas, string nombreusuario, pro_ropa ropa)
        {
            InitializeComponent();

            foreach (string option in listatiendas)
            {
                comboBox1.Items.Add(option);
            }

            textBox1.Text = product.Name;
            textBox2.Text = product.Category;

            label6.Text += product.Stock.ToString();

            this.nombreusuario = nombreusuario;

            this.ropa = ropa;

            this.product = product;
            type = "ropa";
        }
        public Reserva(Helper.wrapperProduct product, List<String> listatiendas, string nombreusuario, pro_sport sport)
        {
            InitializeComponent();

            foreach (string option in listatiendas)
            {
                comboBox1.Items.Add(option);
            }

            textBox1.Text = product.Name;
            textBox2.Text = product.Category;

            label6.Text += product.Stock.ToString();

            this.nombreusuario = nombreusuario;

            this.sport = sport;

            this.product = product;
            type = "sport";
        }
        public Reserva(Helper.wrapperProduct product, List<String> listatiendas, string nombreusuario, pro_videog videog)
        {
            InitializeComponent();

            foreach (string option in listatiendas)
            {
                comboBox1.Items.Add(option);
            }

            textBox1.Text = product.Name;
            textBox2.Text = product.Category;

            label6.Text += product.Stock.ToString();

            this.nombreusuario = nombreusuario;

            this.videog = videog;

            this.product = product;
            type = "videog";
        }
        public Reserva(Helper.wrapperProduct product, List<String> listatiendas, string nombreusuario, sale2 sale)
        {
            InitializeComponent();

            foreach (string option in listatiendas)
            {
                comboBox1.Items.Add(option);
            }

            textBox1.Text = product.Name;
            textBox2.Text = product.Category;

            label6.Text += product.Stock.ToString();

            this.nombreusuario = nombreusuario;

            this.sale = sale;

            this.product = product;
            type = "sale";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
                Helper helperclass = new Helper();


            using (SqlConnection conection = new SqlConnection(helperclass.getConnectionDB(@"(localdb)\BrunsdDB1", "BrunsdDB1")))
                {
                DateTime dt = monthCalendar1.SelectionRange.Start;

                dt.ToUniversalTime();
                
                int stockDB = int.Parse(product.Stock);
                conection.Open();

                    
                    if (String.IsNullOrEmpty(nombreusuario) || String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox3.Text.ToString()) || int.Parse(textBox3.Text.ToString())<=0 || comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Algunos campos estan vacios, por favor reviselo y rellenelos todos.");
                    }
                    else if (dt <= DateTime.Now)
                    {
                        MessageBox.Show("Mal seleccionada la fecha.");
                    }
                    else
                    {
                        try
                        {

                            if (stockDB < int.Parse(textBox3.Text))
                            {
                                MessageBox.Show("Mas cantidad que el stock disponible");
                            }
                            else
                            {
                                string queryInsert = "INSERT INTO Reservas(nombreUsuario, nombreTienda, nombreProducto, cantidadProducto, fechacreación, fecharecogida, confirmacion) values('" + nombreusuario + "', '" + comboBox1.SelectedItem.ToString() + "', '" + product.Name + "', '" + textBox3.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + 1 + "')";

                                SqlCommand cmdInsert = new SqlCommand(queryInsert, conection);

                                cmdInsert.ExecuteNonQuery();

                                //consultar stock

                                string querystock = "SELECT stockPro FROM Productos WHERE nombrePro=@nombreProd";

                                SqlCommand cmdstock = new SqlCommand(querystock, conection);

                                cmdstock.Parameters.AddWithValue("@nombreProd", product.Name);

                                using (SqlDataReader dataReader = cmdstock.ExecuteReader())
                                {
                                    while (dataReader.Read())
                                    {
                                        stockDB = int.Parse(dataReader["stockPro"].ToString());
                                    }
                                }
                            //update stock y ahi restarlo

                            int finalstock = stockDB - int.Parse(textBox3.Text);

                            string queryUpdate = "UPDATE Productos SET stockPro = " + finalstock + " WHERE nombrePro=@nombreProd";

                            SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conection);

                            cmdUpdate.Parameters.AddWithValue("@nombreProd", product.Name);

                            cmdUpdate.ExecuteNonQuery();

                            //Enviar email   

                            if (!String.IsNullOrEmpty(tb_email.Text))
                            {

                                string deDireccionOrigen = "brunsdproyecto@gmail.com";

                                MailMessage message = new MailMessage();

                                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                                smtpClient.UseDefaultCredentials = false;
                                smtpClient.Credentials = new System.Net.NetworkCredential()
                                {
                                    UserName = deDireccionOrigen,
                                    Password = "proyecto123"
                                };

                                smtpClient.EnableSsl = true;
                                message.From = new MailAddress(deDireccionOrigen);
                                message.To.Add(new MailAddress(tb_email.Text));
                                message.Subject = "Información reserva Brunsd";
                                message.IsBodyHtml = true;
                                message.Body = " Hola buenas le recordamos que ha reservado " + product.Name + " en la tienda " + comboBox1.SelectedItem.ToString() + " el dia " + dt.ToString("yyyy-MM-dd") + ". Saludos.";


                                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                                smtpClient.Send(message);
                            }

                            MessageBox.Show("Reserva completada");
                            this.Close();

                            switch (type)
                            {
                                case "multi":
                                    pro.getData();
                                    pro.paintEmails();
                                    break;
                                case "sale":
                                    sale.getData();
                                    sale.paintEmails();
                                    break;
                                case "garden":
                                    garden.getData();
                                    garden.paintEmails();
                                    break;
                                case "home":
                                    home.getData();
                                    home.paintEmails();
                                    break;
                                case "elec":
                                    elec.getData();
                                    elec.paintEmails();
                                    break;
                                case "other":
                                    other.getData();
                                    other.paintEmails();
                                    break;
                                case "ropa":
                                    ropa.getData();
                                    ropa.paintEmails();
                                    break;
                                case "sport":
                                    sport.getData();
                                    sport.paintEmails();
                                    break;
                                case "videog":
                                    videog.getData();
                                    videog.paintEmails();
                                    break;

                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("problema reserva " + ex.Message);
                    }


                    }
                
                
            }
        }

        private void Reserva_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}


