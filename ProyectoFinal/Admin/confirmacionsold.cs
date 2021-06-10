using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.Admin
{
    public partial class confirmacionsold : DevExpress.XtraEditors.XtraForm
    {
        Helper.wrapperProduct product;
        allSold pro;
        public confirmacionsold(Helper.wrapperProduct product, allSold pro)
        {
            InitializeComponent();

            textBox4.Text = product.Name;

            this.pro = pro;
            this.product = product;
        }

        
        private void bu_res_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Helper helperclass = new Helper();



                using (SqlConnection conection = new SqlConnection(helperclass.getConnectionDB(@"(localdb)\BrunsdDB1", "BrunsdDB1")))
                {
                    conection.Open();

                    int stockDB = 0;
                    //consultar stock


                    //update stock y ahi restarlo

                    string queryUpdate = "UPDATE Reservas SET confirmacion = " + 1 + "WHERE idReserva=@idProd";

                    SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conection);

                    cmdUpdate.Parameters.AddWithValue("@idProd", product.Id);

                    cmdUpdate.ExecuteNonQuery();

                }


                MessageBox.Show("Venta completada");

                pro.getData();
                pro.paintEmails();
                this.Close();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bu_res_Load_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}