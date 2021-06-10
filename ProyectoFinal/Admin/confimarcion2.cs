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
    public partial class confirmacion2 : DevExpress.XtraEditors.XtraForm
    {
        Helper.wrapperProduct product;
        all2 pro;
        public confirmacion2(Helper.wrapperProduct product, all2 pro)
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

                    string queryUpdate = "DELETE FROM Reservas WHERE idReserva=@idProd";

                    SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conection);

                    cmdUpdate.Parameters.AddWithValue("@idProd", product.Id);

                    cmdUpdate.ExecuteNonQuery();
                }

                MessageBox.Show("Venta cancelada");

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
    }
}