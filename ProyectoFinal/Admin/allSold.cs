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
using ProyectoFinal.Admin;

namespace ProyectoFinal
{
    public partial class allSold : Form
    {
        string nombre;
        all2 pro;
        Helper.wrapperProduct product = new Helper.wrapperProduct();


        Dictionary<int, Helper.wrapperProduct> mapProducts = new Dictionary<int, Helper.wrapperProduct>();

        public allSold()
        {
            InitializeComponent();

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

                    SqlCommand cmd = new SqlCommand("SELECT idReserva, nombreUsuario, nombreTienda  , nombreProducto , cantidadProducto , fechacreación , fecharecogida , confirmacion FROM Reservas WHERE confirmacion = 2 ", conection);

                    cmd.CommandText += getFilter();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);


                    DataSet ds = new DataSet();

                    da.Fill(ds, "Products");
                    int c = ds.Tables["Products"].Rows.Count;

                    for (int i = 0; i < c; i++)
                    {
                        Helper.wrapperProduct product = new Helper.wrapperProduct();

                        product.Id = ds.Tables["Products"].Rows[i]["idReserva"].ToString();
                        product.Price = ds.Tables["Products"].Rows[i]["nombreUsuario"].ToString();
                        product.Name = ds.Tables["Products"].Rows[i]["nombreProducto"].ToString();
                        product.Stock = ds.Tables["Products"].Rows[i]["nombreTienda"].ToString();
                        product.Category = ds.Tables["Products"].Rows[i]["cantidadProducto"].ToString();
                        product.descPro = ds.Tables["Products"].Rows[i]["fecharecogida"].ToString();

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

                    Label labelHeaderName = new Label
                    {
                        Name = "labelHeaderName" + (i),
                        Size = new Size(269, 20),
                        Location = new Point(10 + resizeHorizontal, 45 + resizeVertical),
                        Text = "Producto: " + mapProducts[i].Name,
                        BackColor = Color.DarkCyan,
                        Font = new System.Drawing.Font(new Font("Verdana", 12), FontStyle.Bold),
                        ForeColor = Color.Black,
                    };
                    Label labelHeaderPrice = new Label
                    {
                        Name = "labelHeaderPrice" + (i),
                        Size = new Size(269, 20),
                        Location = new Point(10 + resizeHorizontal, 70 + resizeVertical),
                        Text = "Usuario: " + mapProducts[i].Price,
                        BackColor = Color.DarkCyan,
                        Font = new System.Drawing.Font(new Font("Verdana", 12), FontStyle.Regular),
                    };
                    Label labelId = new Label
                    {
                        Name = "labelId" + (i),
                        Size = new Size(120, 20),
                        Location = new Point(10 + resizeHorizontal, 20 + resizeVertical),
                        Text = "Id: " + mapProducts[i].Id,
                        BackColor = Color.DarkCyan,
                        Font = new System.Drawing.Font(new Font("Verdana", 12), FontStyle.Regular),
                    };
                    Label lbDesc = new Label
                    {
                        Name = "lbDesc" + (i),
                        Size = new Size(269, 20),
                        Location = new Point(10 + resizeHorizontal, 123 + resizeVertical),
                        Text = "Fecha recogida: " + mapProducts[i].descPro,
                        BackColor = Color.DarkCyan,
                    };
                    Label lbStock = new Label
                    {
                        Name = "lbStock" + (i),
                        Size = new Size(269, 20),
                        Location = new Point(10 + resizeHorizontal, 95 + resizeVertical),
                        Text = "Tienda: " + mapProducts[i].Stock,
                        BackColor = Color.DarkCyan,
                        Font = new System.Drawing.Font(new Font("Verdana", 10), FontStyle.Regular),
                    };
                    Button buttonReserver = new Button
                    {
                        Name = "Reservar" + (i),
                        Size = new Size(269, 65),
                        Location = new Point(10 + resizeHorizontal, 160 + resizeVertical),
                        Text = "Devolver a reserva",
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

                    
                    panel3.Controls.Add(labelHeaderName);
                    panel3.Controls.Add(labelHeaderPrice);
                    panel3.Controls.Add(buttonReserver);
                    panel3.Controls.Add(lbDesc);
                    panel3.Controls.Add(lbStock);
                    panel3.Controls.Add(labelId);

                    panel3.Controls.Add(panelProduct);

                    panelProduct.BringToFront();
                    labelHeaderName.BringToFront();
                    labelHeaderPrice.BringToFront();
                    lbDesc.BringToFront();
                    lbStock.BringToFront();
                    labelId.BringToFront();


                    buttonReserver.BringToFront();


                    mapProducts[i].lbName = labelHeaderName;
                    mapProducts[i].lbPrice = labelHeaderPrice;
                    mapProducts[i].buReserver = buttonReserver;
                    mapProducts[i].lbDesc = lbDesc;
                    mapProducts[i].lbStock = lbStock;
                    mapProducts[i].lbId = labelId;
                    mapProducts[i].panelProduct = panelProduct;
                    

                    count++;
                }
            }

            count = 0;
            PerformLayout();
        }
        private void buReserver_Click(object sender, EventArgs e)
        {

            //boton para editar
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

                    confirmacionsold r1 = new confirmacionsold(productselect, this);
                    r1.Show();

                }
            }
        }
            private string getFilter()
        {
            String filter = "";


            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                filter += " AND nombreUsuario LIKE '%" + textBox1.Text + "%'";
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            adminLobby f1 = new adminLobby();
            f1.Show();
            this.Hide();
        }
    }
}

