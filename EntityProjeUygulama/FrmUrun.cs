using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        DBEntityUrunEntities db = new DBEntityUrunEntities();
        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.Tbl_Urun
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.STOK,
                                            x.FİYAT,
                                            x.Tbl_Kategori.AD,
                                            x.DURUM
                                        }).ToList();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            Tbl_Urun t = new Tbl_Urun();
            t.URUNAD = txturunad.Text;
            t.MARKA = txtmarka.Text;
            t.STOK =short.Parse( txtstok.Text);
            t.KATEGORİ = int.Parse(comboBox1.SelectedValue.ToString());
            t.FİYAT = decimal.Parse(txtfiyat.Text);
            t.DURUM = true;
            db.Tbl_Urun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Sisteme Kaydedildi");

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var urun = db.Tbl_Urun.Find(x);
            db.Tbl_Urun.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi");

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var urun = db.Tbl_Urun.Find(x);
            urun.URUNAD = txturunad.Text;
            urun.STOK = short.Parse(txtstok.Text);
            urun.MARKA = txtmarka.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı");

        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.Tbl_Kategori 
                               select new 
                               { x.ID, x.AD }
                               ).ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "AD";
            comboBox1.DataSource = kategoriler;

        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txturunad.Text = comboBox1.SelectedValue.ToString();
        }
    }
}
