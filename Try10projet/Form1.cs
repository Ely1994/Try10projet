using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Try10projet {
    public partial class M2Lprojet : Form {
        public M2Lprojet() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            DBFournisseur conect = new DBFournisseur();
            Fournisseur f = conect.Read(1);
            label1.Text = f.getNom() + " " + f.getVille() + " " + f.getTarif();
            // LOAD -> afficher la table Fournisseur
            //listbox1

            DBFournisseur abc = new DBFournisseur();
            List<Fournisseur> et = abc.ReadAll();
            foreach (var item in et) {
                listBox1.Items.Add(item.getId()+" "+item.getNom() + " " + item.getVille() + " " + item.getTarif());
            }
            
        }

        private void button1_Click(object sender, EventArgs e) {
            DBFournisseur conect = new DBFournisseur();
            String nom = textBox2.Text;
            String ville = textBox3.Text;
            int tarif = Int32.Parse(textBox4.Text);
            conect.Add(nom, ville, tarif);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
