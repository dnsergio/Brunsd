using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;

namespace ProyectoFinal
{
    public class Helper
    {

        //Return SqlConnectionStringBuilder with decrypted AppSettings value
        public string getConnectionDB(string server, string dataBase)
        {
            var conectionString = new SqlConnectionStringBuilder();

            if (!String.IsNullOrEmpty(server) && !String.IsNullOrEmpty(dataBase))
            {

                conectionString.DataSource = server;
                conectionString.InitialCatalog = dataBase;
            }

            return Convert.ToString(conectionString);

        }
        public class wrapperProduct
        {
            public PictureBox pictureBoxImage;
            public Button buReserver;
            public Button buCancel;
            public String Name;
            public String Price;
            public String Id;
            public String Stock;
            public String Category;
            public String descPro;
            public String oldpriPro;
            public Label lbName;
            public Label lbPrice;
            public Label lbDesc;
            public Label lbReserver;
            public Label lbStock;
            public Label lbold;
            public Label lbId;
            public Image imProduct;
            public Panel panelProduct;
            public Image productImage;

        }

        public class wrapperShop
        {
            public PictureBox pictureBoxImage;
            public Image productImage;
            public Panel panelProduct;
            public Image imProduct;
            public String tlf;
            public String cp;
            public String street;
            public String Id;
            public String name;
            public Label lb_tlf;
            public Label lb_cp;
            public Label lb_street;
            public Label lb_name;


        }
        //Resize image
        public static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        public SqlCommand querys(String query, SqlConnection sql)
        {
            try
            {
                sql.Open();

                string queryLogin = query;

                SqlCommand cmdLogin = new SqlCommand(queryLogin, sql);

                return cmdLogin;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}