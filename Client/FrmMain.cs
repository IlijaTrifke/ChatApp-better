using Common;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Client
{

    public partial class FrmMain : Form
    {
        public BindingList<PorukaSvima> DosadasnjePoruke = new BindingList<PorukaSvima>();
        public BindingList<PorukaSvima> PrikaziSvePorukePoslateOdNjega = new BindingList<PorukaSvima>();
        public BindingList<PorukaSvima> PrikaziSpecificno = new BindingList<PorukaSvima>();
        public string Adminy { get; set; }
        PorukaSvima porukaSvimaa;
        public FrmMain(Administrator admincic)
        {
            InitializeComponent();
            Adminy = admincic.Email;
            Control.CheckForIllegalCrossThreadCalls = false;
            //inicijalizujjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj
            Thread thread = new Thread(Osvezi);
            thread.Start();
            Communication.Instance.GetAll();



        }
        public void Osvezi()
        {
            //kad je thread negde frm main i invoke kad nema al kad zovemo van forme sa forme
            try
            {

                while (true)
                {
                    //svim drugima se popunilo u frmloginu, a prvom se nije popunilo jer ceka ovde primaj
                    //dve receive cim vidim ono 00EEFF exception!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!ili binary formatter stream invalid
                    Common.Message m = Communication.Instance.Primaj();
                    //sendujesklijentu a on nije trazio
                    switch (m.Operacija)
                    {
                        //ne treba login jer ce se 1 ulogovati i toga nema u dgv
                        case Operation.Login:
                            while (!this.IsHandleCreated)
                                System.Threading.Thread.Sleep(100);
                            Invoke(new Action(() =>
                            {

                                cmb.DataSource = /*new BindingList<string>*/(m.TrenutnoPrijavljeni);

                            }));

                            break;
                        case Operation.SendOne:
                            porukaSvimaa = new PorukaSvima()
                            {
                                Email = m.Email,
                                SkracenaPoruka = m.Poruka.Length > 20 ? m.Poruka.Substring(0, 20) : m.Poruka,
                                Poruka = m.Poruka,
                                Kome = m.Kome

                            };
                            DosadasnjePoruke.Insert(0, porukaSvimaa);
                            Invoke(new Action(() =>
                            {

                                dgvSvePoruke.DataSource = DosadasnjePoruke;
                                dgvPoslednjeTri.DataSource = DosadasnjePoruke.Take(3).ToList();
                                dgvSvePoruke.Columns[2].Visible = false;
                                dgvPoslednjeTri.Columns[2].Visible = false;

                                //dgvSvePoruke.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                                //dgvSvePoruke.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                //dgvPoslednjeTri.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                                //dgvPoslednjeTri.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                //dgvSvePoruke.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                                //dgvPoslednjeTri.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                            }));

                            //insert stavlja na pocetak
                            break;
                        case Operation.SendAll:
                            //DgvKlasa klasa = new DgvKlasa()
                            //{
                            //    Email = m.Email,
                            //    Poruka = m.Poruka
                            //};
                            //Dgv.Add(klasa);


                            PorukaSvima porukaSvima = new PorukaSvima()
                            {
                                Email = m.Email,
                                SkracenaPoruka = m.Poruka.Length > 20 ? m.Poruka.Substring(0, 20) : m.Poruka,
                                Poruka = m.Poruka,
                                Kome = "Svima",


                            };
                            DosadasnjePoruke.Insert(0, porukaSvima);
                            //insert na pocetak ovako stavlja u listu

                            Invoke(new Action(() =>
                            {
                                dgvSvePoruke.DataSource = DosadasnjePoruke;
                                dgvPoslednjeTri.DataSource = DosadasnjePoruke.Take(3).ToList();
                                dgvSvePoruke.Columns[2].Visible = false;
                                dgvPoslednjeTri.Columns[2].Visible = false;
                                //how to aenable wrap in dgv c#
                                //dgvSvePoruke.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                                //dgvSvePoruke.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                //dgvPoslednjeTri.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                                //dgvPoslednjeTri.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                //dgvSvePoruke.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                                //dgvPoslednjeTri.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                            }));


                            //dgv gleda sve i lupa prazno gde nije inixijalizovano pa pravimo gv klasu sa potrebnim info samo
                            break;
                        case Operation.Kraj:
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(">>>>" + ex.Message);
            }
        }
        private void btnPosaljiSvima_Click(object sender, System.EventArgs e)
        {
            //max 200 karaktera

            if (isValid())
            {
                Communication.Instance.SaljiSvima(richTextBox1.Text);
            }
            else
            {
                MessageBox.Show("Predugacka je poruka");
            }

        }
        public bool isValid()
        {
            if (richTextBox1.Text.Length > 200)
            {

                return false;
            }
            return true;
        }

        private void btnPosaljiSpecificno_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                Communication.Instance.SaljiSpecificno(richTextBox1.Text, cmb.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Predugacka je poruka");
            }
        }

        private void btnPrikaziFulPoruku_Click(object sender, EventArgs e)
        {
            if (dgvSvePoruke.SelectedRows.Count == 0)
            {

                MessageBox.Show("Nisi selektovao nista!");
            }
            else
            {
                if (dgvSvePoruke.SelectedRows[0].Cells[2].Value.ToString().Length > 20)
                {
                    richTextBox2.Text = dgvSvePoruke.SelectedRows[0].Cells[2].Value.ToString();

                }
            }

        }

        private void btnPrikaziSve_Click(object sender, EventArgs e)
        {
            // dgvSvePoruke.DataSource = DosadasnjePoruke;
            //if (dgvSvePoruke.SelectedRows.Count == 0)
            //{

            //    MessageBox.Show("Nisi selektovao nista!"); 
            //}
            PrikaziSvePorukePoslateOdNjega.Clear();
            foreach (PorukaSvima poruka in DosadasnjePoruke)
            {
                if (poruka.Kome == "Svima")
                {

                    PrikaziSvePorukePoslateOdNjega.Insert(0, poruka);
                }
            }




            dgvSvePoruke.DataSource = PrikaziSvePorukePoslateOdNjega;


        }

        private void btnPrikaziSpecificno_Click(object sender, EventArgs e)
        {
            // dgvSvePoruke.DataSource = DosadasnjePoruke;
            //if (dgvSvePoruke.SelectedRows.Count == 0)
            //{

            //    MessageBox.Show("Nisi selektovao nista!");
            //}
            PrikaziSpecificno.Clear();
            string odkoga = cmb.SelectedItem.ToString();
            foreach (PorukaSvima poruka in DosadasnjePoruke)
            {

                if (poruka.Kome == Adminy && poruka.Email == odkoga)
                {

                    PrikaziSpecificno.Insert(0, poruka);
                }
            }




            dgvSvePoruke.DataSource = PrikaziSpecificno;
        }

    }
}
