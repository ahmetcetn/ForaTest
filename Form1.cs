using DbManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ForaTest
{
    public partial class Form1 : Form
    {
        EnvarnterBilgiDbManager envarnterBilgiDb;
        public Form1()
        {
            InitializeComponent();
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxPersonelGrubu.Text == "Remote")
            {
                BtnRemote.BackColor = Color.Yellow;
                BtnTeknik.BackColor = Color.Gray;
                BtnYazilim.BackColor = Color.Gray;
                BtnYonetim.BackColor = Color.Gray;
            }
            if (cmbxPersonelGrubu.Text == "Yazilim")
            {
                BtnRemote.BackColor = Color.Gray;
                BtnTeknik.BackColor = Color.Gray;
                BtnYazilim.BackColor = Color.Red;
                BtnYonetim.BackColor = Color.Gray;
            }
            if (cmbxPersonelGrubu.Text == "Teknik")
            {
                BtnRemote.BackColor = Color.Gray;
                BtnTeknik.BackColor = Color.Green;
                BtnYazilim.BackColor = Color.Gray;
                BtnYonetim.BackColor = Color.Gray;
            }
            if (cmbxPersonelGrubu.Text == "Yonetim")
            {
                BtnRemote.BackColor = Color.Gray;
                BtnTeknik.BackColor = Color.Gray;
                BtnYazilim.BackColor = Color.Gray;
                BtnYonetim.BackColor = Color.Orange;
            }
        }

        private void BtnGoruntulu_Click(object sender, EventArgs e)
        {
            try
            {
                string adSoyad = txtAdSoyad.Text;
                string urun = cmbxUrun.Text;
                string ram = txtRam.Text;
                string islemci = txtIslemci.Text;
                string goruntu = cmbxGoruntu.Text;
                string hafiza = txtHafiza.Text;
                string isletimSistemi = txtIsletimSistemi.Text;
                string personel = cmbxPersonelGrubu.Text;
                envarnterBilgiDb = new EnvarnterBilgiDbManager();
                dgvListe.DataSource = envarnterBilgiDb.GetEnvanterBilgiData(adSoyad, urun, ram, islemci, goruntu, hafiza, isletimSistemi, personel);
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu!");
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string adSoyad = txtAdSoyad.Text;
                string urun = cmbxUrun.Text;
                string ram = txtRam.Text;
                string islemci = txtIslemci.Text;
                string goruntu = cmbxGoruntu.Text;
                string hafiza = txtHafiza.Text;
                string isletimSistemi = txtIsletimSistemi.Text;
                string telefon = txtTelefon.Text;
                string notlar = txtNot.Text;
                string personel = cmbxPersonelGrubu.Text;
                envarnterBilgiDb = new EnvarnterBilgiDbManager();
                if (envarnterBilgiDb.Create(adSoyad, urun, ram, islemci, goruntu, hafiza, isletimSistemi, telefon, notlar, personel))
                    MessageBox.Show("Kayıt başarılı");
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt başarısız. Bir hata oluştu!");
            }
        }

        private void BtnDuzelt_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(lblId.Text);
                string adSoyad = txtAdSoyad.Text;
                string urun = cmbxUrun.Text;
                string ram = txtRam.Text;
                string islemci = txtIslemci.Text;
                string goruntu = cmbxGoruntu.Text;
                string hafiza = txtHafiza.Text;
                string isletimSistemi = txtIsletimSistemi.Text;
                string telefon = txtTelefon.Text;
                string notlar = txtNot.Text;
                string personel = cmbxPersonelGrubu.Text;
                envarnterBilgiDb = new EnvarnterBilgiDbManager();
                if (envarnterBilgiDb.Update(id, adSoyad, urun, ram, islemci, goruntu, hafiza, isletimSistemi, telefon, notlar, personel))
                    MessageBox.Show("Duzeltme başarılı");
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt başarısız. Bir hata oluştu!");
            }
        }

        private void dgvListe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblId.Text = string.Empty;
                int index = dgvListe.CurrentCell.RowIndex;
                lblId.Text = dgvListe.Rows[index].Cells[0].Value.ToString();
                int id = int.Parse(lblId.Text);
                envarnterBilgiDb = new EnvarnterBilgiDbManager();
                var data = envarnterBilgiDb.GetEnvanterBilgiData(id);
                if (data != null && data.Rows.Count > 0)
                {
                    txtAdSoyad.Text = data.Rows[0]["AdSoyad"].ToString();
                    cmbxUrun.Text = data.Rows[0]["Urun"].ToString();
                    txtRam.Text = data.Rows[0]["Ram"].ToString();
                    txtIslemci.Text = data.Rows[0]["Islemci"].ToString();
                    cmbxGoruntu.Text = data.Rows[0]["Goruntu"].ToString();
                    txtHafiza.Text = data.Rows[0]["Hafiza"].ToString();
                    txtIsletimSistemi.Text = data.Rows[0]["IsletimSistemi"].ToString();
                    txtTelefon.Text = data.Rows[0]["Telefon"].ToString();
                    txtNot.Text = data.Rows[0]["Notlar"].ToString();
                    cmbxPersonelGrubu.Text = data.Rows[0]["Personel"].ToString();
                }
                else
                    MessageBox.Show("Kayıt bulunamadı");
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu!");
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblId.Text))
                    MessageBox.Show("Kayıt bulunamadı");
                else
                {
                    int id = int.Parse(lblId.Text);
                    envarnterBilgiDb = new EnvarnterBilgiDbManager();
                    if (envarnterBilgiDb.Delete(id))
                        MessageBox.Show("Kayıt silindi");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu!");
            }
        }
    }
}
