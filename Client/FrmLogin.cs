using Common;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();
            // Communication.Instance.Connect();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //sve mora da bude u if-u!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Administrator admincic = new Administrator();
            if (Communication.Instance.Connect())
            {
                Administrator admin = new Administrator()
                {
                    Email = textBox1.Text,
                    Password = textBox2.Text
                };
                admin = Communication.Instance.Login(admin);
                if (admin != null)
                {
                    FrmMain fm = new FrmMain(admin);
                    fm.ShowDialog();
                    //ne mroam closeovati lopgin mzd oce opet
                }
                else
                {
                    MessageBox.Show("Pogresio si marmune ili je korisnik vec ulogovan");
                }
            }
            else
            {
                MessageBox.Show("Nisi se povezao sa serverom");
            }

            //LOGIN VRACA CELOG ADMINA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        }
    }
}
