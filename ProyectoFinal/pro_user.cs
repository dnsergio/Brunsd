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
using DevExpress.XtraEditors;

namespace ProyectoFinal
{
    public partial class pro_user : DevExpress.XtraEditors.XtraForm
    {
        string nombre;
        public pro_user(String nombre)
        {
            InitializeComponent();
            this.nombre = nombre;

            var select = "SELECT nombreTienda as Tienda, nombreProducto as Producto, cantidadProducto as Cant, fechacreación as FechaCr, fecharecogida as FechaRec FROM Reservas WHERE nombreUsuario="+ "'" + nombre +"'" +"AND confirmacion = 1 ";
            Helper helperclass = new Helper();
            var c = new SqlConnection(helperclass.getConnectionDB(@"(localdb)\BrunsdDB1", "BrunsdDB1")); // Your Connection String here
            ;

            var dataAdap = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdap);
            var ds1 = new DataSet();
            dataAdap.Fill(ds1);
            dtGrid.ReadOnly = true;
            dtGrid.DataSource = ds1.Tables[0];
            dtGrid.ForeColor = Color.Black; 
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
                
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            lobby1 a = new lobby1(nombre);
            a.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
