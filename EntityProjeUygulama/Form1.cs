using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityProjeUygulama;

namespace EntityProjeUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DBEntityUrunEntities db = new DBEntityUrunEntities();
        private void btnlistele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.Tbl_Kategori.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            Tbl_Kategori t = new Tbl_Kategori();
            t.AD = textBox2.Text;
            db.Tbl_Kategori.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int c = Convert.ToInt32(textBox1.Text);
            var ktgr = db.Tbl_Kategori.Find(c);
            db.Tbl_Kategori.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            int c = Convert.ToInt32(textBox1.Text);
            var ktgr = db.Tbl_Kategori.Find(c);
            ktgr.AD = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı");
        }
    }
}
