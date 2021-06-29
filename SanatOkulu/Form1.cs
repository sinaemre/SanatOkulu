using SanatOkulu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanatOkulu
{
    public partial class Form1 : Form
    {
        SanatOkuluContext db = new SanatOkuluContext();
        public Form1()
        {
            InitializeComponent();
            SanatcilarıYukle();
            EserleriListele();
        }

        private void SanatcilarıYukle()
        {
            cbxSanatci.DataSource = db.Sanatcilar.OrderBy(x => x.Ad).ToList();
            cbxSanatci.ValueMember = "Id";
            cbxSanatci.DisplayMember = "Ad";
            cbxSanatci.SelectedIndex = -1;
        }

        private void pboYeniSanatci_Click(object sender, EventArgs e)
        {
            SanatciFormuAc();
        }
        void SanatciFormuAc()
        {
            var frm = new SanatciForm(db);
            frm.SanatcilarDegisti += Frm_SanatcilarDegisti;
            frm.ShowDialog();
        }

        private void Frm_SanatcilarDegisti(object sender, EventArgs e)
        {
            EserleriListele();
            SanatcilarıYukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            if (ad == "")
            {
                MessageBox.Show("Lütfen eserin adını giriniz");
                return;
            }
            
            if (cbxSanatci.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen sanatçının adını giriniz");
                return;
            }

            var eser = new Eser()
            {
                Ad = ad,
                SanatciId = (int)cbxSanatci.SelectedValue,
                Yil = mtbYil.Text == "" ? null as int? : Convert.ToInt32(mtbYil.Text)
            };
            db.Eserler.Add(eser);
            db.SaveChanges();
            FormuResetle();
            EserleriListele();
        }

        private void EserleriListele()
        {
            lvwEserler.Items.Clear();
            foreach (Eser eser in db.Eserler.OrderBy(x=>x.Yil))
            {
                ListViewItem lvi = new ListViewItem(eser.Ad);
                lvi.SubItems.Add(eser.Sanatci.Ad);
                lvi.SubItems.Add(eser.Yil.ToString());
                lvwEserler.Items.Add(lvi);
            }
            
        }

        private void FormuResetle()
        {
            txtAd.Clear();
            mtbYil.Clear();
            cbxSanatci.SelectedIndex = -1;
            txtAd.Focus();
        }

        private void tsmiSanatcilar_Click(object sender, EventArgs e)
        {
            SanatciFormuAc();
        }
    }
}
