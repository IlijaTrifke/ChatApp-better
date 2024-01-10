using System;
using System.Windows.Forms;

namespace Serverski
{
    public partial class FrmServer : Form
    {
        Server server;
        public FrmServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            server = new Server();
            server.Start();
            textBox1.Text = "Server radi";
            button2.Enabled = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            server.Stop();
            //Environment.Exit(0);

            textBox1.Text = "Server ne radi";
            button1.Enabled = true;
            //treba da ispraznimo listu tada
        }
    }
}
