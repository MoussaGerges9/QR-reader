using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec.Data;

namespace QR_reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
                {Filter = "JPEG|*.jpg|PNG|*.png", ValidateNames = true, Multiselect = false})
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    MessagingToolkit.QRCode.Codec.QRCodeDecoder decoder =
                        new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
                    textBox1.Text = decoder.Decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap));
                }
            }
        }
    }
}
