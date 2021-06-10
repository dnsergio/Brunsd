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
    public partial class pro_ropa : Form
    {
        string nombre;
        Dictionary<int, Helper.wrapperProduct> mapProducts = new Dictionary<int, Helper.wrapperProduct>();

        public pro_ropa(string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;

            getData();
            paintEmails();

        }
        public void getData()
        {

            mapProducts = new Dictionary<int, Helper.wrapperProduct>();

            Helper h1 = new Helper();

            using (SqlConnection conection = new SqlConnection(h1.getConnectionDB(@"(localdb)\BrunsdDB1", "BrunsdDB1")))
            {
                try
                {
                    conection.Open();

                    SqlCommand cmd = new SqlCommand("SELECT idPro, nombrePro , descPro , nombre_cat , precioPro , stockPro , image  FROM Productos WHERE nombre_cat='Ropa' AND stockPro>0", conection);

                    cmd.CommandText += getFilter();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);


                    DataSet ds = new DataSet();

                    da.Fill(ds, "Products");
                    int c = ds.Tables["Products"].Rows.Count;

                    for (int i = 0; i < c; i++)
                    {
                        Helper.wrapperProduct product = new Helper.wrapperProduct();

                        product.Id = ds.Tables["Products"].Rows[i]["idPro"].ToString();
                        product.Price = ds.Tables["Products"].Rows[i]["precioPro"].ToString();
                        product.Name = ds.Tables["Products"].Rows[i]["nombrePro"].ToString();
                        product.Stock = ds.Tables["Products"].Rows[i]["stockPro"].ToString();
                        product.Category = ds.Tables["Products"].Rows[i]["nombre_cat"].ToString();
                        product.descPro = ds.Tables["Products"].Rows[i]["descPro"].ToString();


                        Byte[] byteBLOBData = new Byte[0];
                        byteBLOBData = (Byte[])(ds.Tables["Products"].Rows[i]["image"]);
                        MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                        product.imProduct = Image.FromStream(stmBLOBData);

                        mapProducts.Add(Convert.ToInt32(product.Id), product);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al recibir productos de la base de datos: \n" + ex.Message);
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

            foreach (int i in mapProducts.Keys)
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
                        Image = Helper.resizeImage(mapProducts[i].imProduct, new Size(260, 185)),
                        BackColor = Color.DarkCyan,
                    };

                    Label labelHeaderName = new Label
                    {
                        Name = "labelHeaderName" + (i),
                        Size = new Size(160, 25),
                        Location = new Point(10 + resizeHorizontal, 210 + resizeVertical),
                        Text = mapProducts[i].Name,
                        BackColor = Color.DarkCyan,
                        Font = new System.Drawing.Font(new Font("Verdana", 12), FontStyle.Bold),
                        ForeColor = Color.Black,
                    };
                    Label labelHeaderPrice = new Label
                    {
                        Name = "labelHeaderPrice" + (i),
                        Size = new Size(120, 30),
                        Location = new Point(160 + resizeHorizontal, 225 + resizeVertical),
                        Text = mapProducts[i].Price + " €",
                        BackColor = Color.DarkCyan,
                        Font = new System.Drawing.Font(new Font("Verdana", 20), FontStyle.Bold),
                    };
                    Label lbDesc = new Label
                    {
                        Name = "lbDesc" + (i),
                        Size = new Size(135, 40),
                        Location = new Point(10 + resizeHorizontal, 230 + resizeVertical),
                        Text = mapProducts[i].descPro,
                        BackColor = Color.DarkCyan,
                    };
                    Label lbStock = new Label
                    {
                        Name = "lbStock" + (i),
                        Size = new Size(100, 20),
                        Location = new Point(165 + resizeHorizontal, 205 + resizeVertical),
                        Text = "Unidad/es: " + mapProducts[i].Stock,
                        BackColor = Color.DarkCyan,
                        Font = new System.Drawing.Font(new Font("Verdana", 9), FontStyle.Regular),
                    };
                    Button buttonReserver = new Button
                    {
                        Name = "Reservar" + (i),
                        Size = new Size(100, 30),
                        Location = new Point(165 + resizeHorizontal, 260 + resizeVertical),
                        Text = "Reservar",
                    };


                    Panel panelProduct = new Panel
                    {
                        Name = "panelProduct" + (i),
                        Size = new Size(273, 285),
                        Location = new Point(9 + resizeHorizontal, 13 + resizeVertical),
                        BackColor = Color.DarkCyan,
                        BorderStyle = BorderStyle.None,
                    };

                    buttonReserver.Click += new System.EventHandler(buReserver_Click);

                    panel3.Controls.Add(pictureBoxImage);
                    panel3.Controls.Add(labelHeaderName);
                    panel3.Controls.Add(labelHeaderPrice);
                    panel3.Controls.Add(buttonReserver);
                    panel3.Controls.Add(lbDesc);
                    panel3.Controls.Add(lbStock);
                    panel3.Controls.Add(panelProduct);

                    panelProduct.BringToFront();
                    pictureBoxImage.BringToFront();
                    labelHeaderName.BringToFront();
                    labelHeaderPrice.BringToFront();
                    lbDesc.BringToFront();
                    lbStock.BringToFront();

                    buttonReserver.BringToFront();

                    mapProducts[i].pictureBoxImage = pictureBoxImage;
                    mapProducts[i].lbName = labelHeaderName;
                    mapProducts[i].lbPrice = labelHeaderPrice;
                    mapProducts[i].buReserver = buttonReserver;
                    mapProducts[i].lbDesc = lbDesc;
                    mapProducts[i].lbDesc = lbStock;
                    mapProducts[i].panelProduct = panelProduct;
                    

                    count++;
                }
            }

            count = 0;
            PerformLayout();
        }
        private void buReserver_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                getData();

                if (sender is Button)
                {
                    Button bu = (Button)sender;

                    

                    Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
                    Match result = re.Match(bu.Name);

                    string alphaPart = result.Groups[1].Value;
                    string numberPart = result.Groups[2].Value;


                    Helper.wrapperProduct productselect = new Helper.wrapperProduct();

                    productselect = mapProducts[Convert.ToInt32(numberPart)];

                    List<String> listValues = new List<String>();

                    Helper helperclass = new Helper();

                    using (SqlConnection conection = new SqlConnection(helperclass.getConnectionDB(@"(localdb)\BrunsdDB1", "BrunsdDB1")))
                    {
                        conection.Open();
                        string queryRol = "SELECT nombreTienda FROM Tiendas";

                        SqlCommand cmdRol = new SqlCommand(queryRol, conection);

                        using (SqlDataReader dataRead = cmdRol.ExecuteReader())
                        {
                            while (dataRead.Read())
                            {
                                listValues.Add(dataRead["nombreTienda"].ToString());
                            }
                        }
                    }

                    Reserva r1 = new Reserva(productselect,listValues,nombre,this);
                    r1.Show();

                }
            }
        }

        private string getFilter()
        {
            String filter = "";


            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                filter += " AND nombrePro LIKE '%" + textBox1.Text + "%'";
            }
            return filter;
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

