using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProyectoFinal
{
    public partial class shops : Form
    {
        string nombre;
        Dictionary<int, Helper.wrapperShop> mapShop = new Dictionary<int, Helper.wrapperShop>();

        public shops(string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;

            getData();
            paintEmails();

        }
        public void getData()
        {

            mapShop = new Dictionary<int, Helper.wrapperShop>();

            Helper h1 = new Helper();

            using (SqlConnection conection = new SqlConnection(h1.getConnectionDB(@"(localdb)\BrunsdDB1", "BrunsdDB1")))
            {
                try
                {
                    conection.Open();

                    SqlCommand cmd = new SqlCommand("SELECT idTienda , nombreTienda , calleTienda , CP , telTienda , imagen FROM Tiendas", conection);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds, "Shop");
                    int c = ds.Tables["Shop"].Rows.Count;

                    for (int i = 0; i < c; i++)
                    {
                        Helper.wrapperShop shop = new Helper.wrapperShop();

                        shop.Id = ds.Tables["Shop"].Rows[i]["idTienda"].ToString();
                        shop.name = ds.Tables["Shop"].Rows[i]["nombreTienda"].ToString();
                        shop.street = ds.Tables["Shop"].Rows[i]["calleTienda"].ToString();
                        shop.cp = ds.Tables["Shop"].Rows[i]["CP"].ToString();
                        shop.tlf = ds.Tables["Shop"].Rows[i]["telTienda"].ToString();


                        Byte[] byteBLOBData = new Byte[0];
                        byteBLOBData = (Byte[])(ds.Tables["Shop"].Rows[i]["imagen"]);
                        MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                        shop.imProduct = Image.FromStream(stmBLOBData);

                        mapShop.Add(Convert.ToInt32(shop.Id), shop);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al recibir tiendas de la base de datos: \n" + ex.Message);
                }
            }
        }

        public void paintEmails()
        {
            int count = 0;
            double horizontalDiv = 4;
            string horizontal;
            string vertical = "0";
            int resizeHorizontal = 0;
            int resizeVertical = 0;

            panel3.Controls.Clear();

            foreach (int i in mapShop.Keys)
            {
                if (count <= 50)
                {
                    double auxHorizontal = count / horizontalDiv;

                    string[] auxNum = auxHorizontal.ToString().Split(',');

                    horizontal = auxNum.Length == 1 ? auxNum[0] : auxNum[1];
                    vertical = auxNum[0];

                    if (int.Parse(vertical) > 0) resizeVertical = 291 * int.Parse(vertical);

                    horizontal = count % 4 == 0 ? "0" : horizontal;

                    

                    switch (horizontal)
                    {
                        case "25":
                            resizeHorizontal = 280;
                            break;
                        case "5":
                            resizeHorizontal = 560;
                            break;
                        case "75":
                            resizeHorizontal = 840;
                            break;
                        default:
                            resizeHorizontal = 0;
                            break;
                    }
                    PictureBox pictureBoxImage = new PictureBox
                    {
                        Name = "pictureBoxImage" + (i),
                        Size = new Size(260, 185),
                        Location = new Point(15 + resizeHorizontal, 20 + resizeVertical),
                        Image = Helper.resizeImage(mapShop[i].imProduct, new Size(260, 185)),
                        BackColor = Color.DarkCyan,
                    };

                    Label labelHeaderName = new Label
                    {
                        Name = "labelHeaderName" + (i),
                        Size = new Size(160, 45),
                        Location = new Point(10 + resizeHorizontal, 210 + resizeVertical),
                        Text = mapShop[i].name,
                        BackColor = Color.DarkCyan,
                        Font = new System.Drawing.Font(new Font("Verdana", 11), FontStyle.Bold),
                        ForeColor = Color.Black,
                    };
                    Label labelHeaderstreet = new Label
                    {
                        Name = "labelHeaderStreet" + (i),
                        Size = new Size(160, 45),
                        Location = new Point(10 + resizeHorizontal, 230 + resizeVertical),
                        Text = mapShop[i].street ,
                        BackColor = Color.DarkCyan,
                        Font = new System.Drawing.Font(new Font("Verdana", 10), FontStyle.Bold),
                    };
                    Label lbDesc = new Label
                    {
                        Name = "lbDesc" + (i),
                        Size = new Size(100, 20),
                        Location = new Point(10 + resizeHorizontal, 275 + resizeVertical),
                        Text = "CP : " + mapShop[i].cp,
                        BackColor = Color.DarkCyan,
                        Font = new System.Drawing.Font(new Font("Verdana", 10), FontStyle.Regular),

                    };
                    Label lbTlf = new Label
                    {
                        Name = "lbTlf" + (i),
                        Size = new Size(160, 20),
                        Location = new Point(100 + resizeHorizontal, 275 + resizeVertical),
                        Text = "Tlf: " +mapShop[i].tlf,
                        BackColor = Color.DarkCyan,
                        Font = new System.Drawing.Font(new Font("Verdana", 10), FontStyle.Regular),
                    };


                    Panel panelProduct = new Panel
                    {
                        Name = "panelProduct" + (i),
                        Size = new Size(273, 285),
                        Location = new Point(9 + resizeHorizontal, 13 + resizeVertical),
                        BackColor = Color.DarkCyan,
                        BorderStyle = BorderStyle.None,
                    };


                    panel3.Controls.Add(pictureBoxImage);
                    panel3.Controls.Add(labelHeaderName);
                    panel3.Controls.Add(labelHeaderstreet);
                    panel3.Controls.Add(lbDesc);
                    panel3.Controls.Add(lbTlf);
                    panel3.Controls.Add(panelProduct);

                    panelProduct.BringToFront();
                    pictureBoxImage.BringToFront();
                    labelHeaderName.BringToFront();
                    labelHeaderstreet.BringToFront();
                    lbDesc.BringToFront();
                    lbTlf.BringToFront();


                    mapShop[i].pictureBoxImage = pictureBoxImage;
                    mapShop[i].lb_name = labelHeaderName;
                    mapShop[i].lb_street = labelHeaderstreet;
                    mapShop[i].lb_cp = lbDesc;
                    mapShop[i].lb_tlf = lbTlf;
                    mapShop[i].panelProduct = panelProduct;
                    

                    count++;
                }
            }

            count = 0;
            PerformLayout();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getData();
            paintEmails();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            InitializeComponent();

        }

        private void pro_multi_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            getData();
            paintEmails();
        }

        private void bu_pro_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            pro pro = new pro(nombre);
            pro.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            sale2 pro = new sale2(nombre);
            pro.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            shops shop = new shops(nombre);
            shop.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            contact con = new contact(nombre);
            con.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/brunsdproyecto/");
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/Brunds5");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void bu_lobby_Click(object sender, EventArgs e)
        {
            lobby1 l1 = new lobby1(nombre);
            l1.Show();
            this.Hide();
        }
    }
}

