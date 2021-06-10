using DevExpress.XtraEditors;
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

namespace ProyectoFinal.Admin
{
    public partial class addShop : DevExpress.XtraEditors.XtraForm
    {
        String filename;

        public addShop()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Helper helperclass = new Helper();
            using (SqlConnection conection = new SqlConnection(helperclass.getConnectionDB(@"(localdb)\BrunsdDB1", "BrunsdDB1")))
            {
               
                conection.Open();
                if (String.IsNullOrEmpty(nameShop.Text) || String.IsNullOrEmpty(streetShop.Text) || String.IsNullOrEmpty(cpShop.Text) || String.IsNullOrEmpty(numberShop.Text))
                {

                    MessageBox.Show("Algunos campos estan vacios, por favor reviselo y rellenelos todos.");

                }
                else
                {
                    try
                    {
                        string queryInsert = "INSERT INTO Tiendas(nombreTienda, calleTienda, CP, TelTienda, imagen) values('" + nameShop.Text + "', '" + streetShop.Text + "', '" + cpShop.Text + "', '" + numberShop.Text + "', @Image)";
                        
                        using (SqlCommand cmd = new SqlCommand(queryInsert, conection))
                        {
                            FileStream fsBLOBFile = new FileStream(filename, FileMode.Open, FileAccess.Read);
                            Byte[] bytBLOBData = new Byte[fsBLOBFile.Length];
                            fsBLOBFile.Read(bytBLOBData, 0, bytBLOBData.Length);
                            fsBLOBFile.Close();

                            //Create parameter for insert command and add to SqlCommand object.
                            SqlParameter prm = new SqlParameter("@Image", SqlDbType.VarBinary, bytBLOBData.Length, ParameterDirection.Input, false,
                            0, 0, null, DataRowVersion.Current, bytBLOBData);

                            cmd.Parameters.Add(prm);
                            cmd.ExecuteNonQuery();
                            XtraMessageBox.Show("Tienda registrada correctamente.", "Confirmacion", MessageBoxButtons.OK);
                        }


                        nameShop.Text = "";
                        streetShop.Text = "";
                        cpShop.Text = "";
                        numberShop.Text = "";
                        ImgCli.Image = null;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.Message + " al intentar crear tienda");
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            DialogResult rs = fo.ShowDialog();
            if (rs == DialogResult.OK)
            {
                ImgCli.Image = Image.FromFile(fo.FileName);
                filename = fo.FileName;
            }
        }

        private void addShop_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            adminLobby f1 = new adminLobby();
            f1.Show();
            this.Hide();
        }
    }
}