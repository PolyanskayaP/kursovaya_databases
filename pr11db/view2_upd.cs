using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr11db
{
    public partial class view2_upd : Form
    {
        NpgsqlConnection Nc;
        string textg;
        
        public view2_upd(NpgsqlConnection nc, string text)
        {
            InitializeComponent();
            Nc = nc;
            textg = text;

            string query1 = "SELECT name FROM view2 WHERE name = '" + textg + "';";
            NpgsqlCommand npgc = new NpgsqlCommand(query1, Nc);
            textBox1.Text = npgc.ExecuteScalar().ToString();
           
            query1 = "SELECT provider FROM view2 WHERE name = '" + textg + "';";
            npgc = new NpgsqlCommand(query1, Nc);
            textBox2.Text = npgc.ExecuteScalar().ToString();

            query1 = "SELECT price FROM view2 WHERE name = '" + textg + "';";
            npgc = new NpgsqlCommand(query1, Nc);
            numericUpDown1.Value = (int)npgc.ExecuteScalar();

        }
        public view2_upd()
        {
            InitializeComponent();
        }

        private void view2_upd_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_prov_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text; //(string)comboBox2_name.SelectedItem;
                int price = (int)numericUpDown1.Value;
                string provider = textBox2.Text;

                string query = $"call upd_view2('{textg}' , '{name}' , {price}, '{provider}');";
                NpgsqlCommand npgc = new NpgsqlCommand(query, Nc);
                npgc.ExecuteNonQuery();
                MessageBox.Show(
                        "Обновление прошло успешно, нажмите select"
                        );
            }
            catch
            {
                MessageBox.Show(
                    "У вас недостаточно прав для обновления."
                    );
            }
        }
    }
}
