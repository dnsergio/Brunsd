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
using DevExpress.XtraEditors;
using ProyectoFinal.Admin;

namespace ProyectoFinal
{
    public partial class Add : DevExpress.XtraEditors.XtraForm
    {
        String filename;

        public Add()
        {
            InitializeComponent();

            List<String> listValues = new List<String>();

            Helper helperclass = new Helper();


            using (SqlConnection conection = new SqlConnection(helperclass.getConnectionDB(@"(localdb)\BrunsdDB1", "BrunsdDB1")))
            {

                conection.Open();

                string queryRol = "SELECT nombre_cat FROM Categorias";

                SqlCommand cmdRol = new SqlCommand(queryRol, conection);

                using (SqlDataReader dataRead = cmdRol.ExecuteReader())
                {
                    while (dataRead.Read())
                    {
                        listValues.Add(dataRead["nombre_cat"].ToString());
                    }
                }
            }
            foreach (string option in listValues)
            {
                cb_category.Items.Add(option);
            }

        }

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Boton para subir productos

            Helper helperclass = new Helper();
            using (SqlConnection conection = new SqlConnection(helperclass.getConnectionDB(@"(localdb)\BrunsdDB1", "BrunsdDB1")))
            {

                conection.Open();
                if (String.IsNullOrEmpty(namePro.Text) || String.IsNullOrEmpty(stockPro.Text) || String.IsNullOrEmpty(PricePro.Text) || cb_category.Text== "Elige una")
                {

                    MessageBox.Show("Algunos campos estan vacios, por favor reviselo y rellenelos todos.");

                }
                else
                {
                    try
                    {
                        string queryInsert = "INSERT INTO Productos(nombrePro, stockPro, precioPro, nombre_cat, descPro, image) values('" + namePro.Text + "', '" + stockPro.Text + "', '" + PricePro.Text + "', '" + cb_category.Text + "', '" + desc_tx.Text + "', @Image)";
                        
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
                            XtraMessageBox.Show("Producto registrado correctamente.", "Confirmacion", MessageBoxButtons.OK);
                        }

                        namePro.Text = "";
                        stockPro.Text = "";
                        PricePro.Text = "";
                        desc_tx.Text = "";
                        cb_category.Text = "Elige una";
                        ImgCli.Image = null;




                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.Message + " al intentar crear producto");
                    }
                }
            }
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            DialogResult rs = fo.ShowDialog();
            if (rs== DialogResult.OK) 
            {
                ImgCli.Image = Image.FromFile(fo.FileName);
                filename = fo.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            adminLobby f1 = new adminLobby();
            f1.Show();
            this.Hide();
        }
    }
}