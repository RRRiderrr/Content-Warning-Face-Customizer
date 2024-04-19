using Microsoft.Win32;
using System;
using System.Text;
using System.Windows.Forms;

namespace CWCF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string inputText = textBox1.Text;

            
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(inputText);

            
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Landfall Games\Content Warning");
                key.SetValue("FaceText_h3883740665", utf8Bytes, RegistryValueKind.Binary);
                key.Close();
                MessageBox.Show("The face has been successfully set!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                button1.Enabled = false;
            }
            else
                button1.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                textBox1.Clear();
                textBox1.Text = listBox1.SelectedItem.ToString();
            }
        }
    }
}
