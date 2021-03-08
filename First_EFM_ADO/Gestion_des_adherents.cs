using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First_EFM_ADO
{
    public partial class Gestion_des_adherents : Form
    {
        public Gestion_des_adherents()
        {
            InitializeComponent();
        }

        private void Gestion_des_adherents_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetADH.ADHERENTS' table. You can move, or remove it, as needed.
            this.aDHERENTSTableAdapter.Fill(this.dataSetADH.ADHERENTS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.aDHERENTSBindingSource.Position++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.aDHERENTSBindingSource.Position = this.aDHERENTSBindingSource.Count - 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.aDHERENTSBindingSource.Position--;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test"+ this.aDHERENTSBindingSource.Position.ToString());
            this.aDHERENTSBindingSource.Position = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text =( this.aDHERENTSBindingSource.Count +1).ToString();
            textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text  = textBox7.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != ""  && textBox7.Text != "")
            {
                try
                {
                    DataRow C1 = this.dataSetADH.ADHERENTS.NewRow();
                    C1.BeginEdit();
                    C1[0] = textBox1.Text;
                    C1[1] = textBox2.Text;
                    C1[2] = textBox3.Text;
                    C1[3] = textBox4.Text;
                    C1[4] = textBox5.Text;
                    C1[5] = dateTimePicker1.Text;
                    C1[6] = textBox7.Text;
                    C1.EndEdit();
                    this.dataSetADH.ADHERENTS.Rows.Add(C1);
                    this.aDHERENTSTableAdapter.Update(this.dataSetADH.ADHERENTS);
                    MessageBox.Show("Ajout effectué");


                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            else
            {
                MessageBox.Show("Remplir les champs");
            }
        }
       // SqlConnection con = new SqlConnection(@"data source = .\SQLEXPRESS;database=VolAvion;Integrated Security=True");

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked && textBox8.Text!="")
            {
                this.aDHERENTSBindingSource.Filter = $"Substring(nomAdh,1,1)='{textBox8.Text}'";

            }
        }
    }
}
