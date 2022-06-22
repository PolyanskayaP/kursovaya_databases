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
    public partial class kassir_upd : Form
    {
        NpgsqlConnection Nc;
        int Id;
        public kassir_upd(NpgsqlConnection nc, int id)
        {
            InitializeComponent();
            Nc = nc;
            Id = id;

            string query1 = "SELECT fam FROM Kassir WHERE id = " + id + ";";
            NpgsqlCommand npgc = new NpgsqlCommand(query1, Nc);
            textBox1.Text = npgc.ExecuteScalar().ToString();

            string query2 = "SELECT name FROM Kassir WHERE id = " + id + ";";
            npgc = new NpgsqlCommand(query2, Nc);
            textBox2.Text = npgc.ExecuteScalar().ToString();

            string query3 = "SELECT otch FROM Kassir WHERE id = " + id + ";";
            npgc = new NpgsqlCommand(query3, Nc);
            textBox3.Text = npgc.ExecuteScalar().ToString();

            string query4 = "SELECT shop FROM Kassir WHERE id = " + id + ";";
            npgc = new NpgsqlCommand(query4, Nc);
            textBox4.Text = npgc.ExecuteScalar().ToString();
        }
        public kassir_upd()
        {
            InitializeComponent();
        }

        private void kassir_upd_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fam = textBox1.Text;
                string name = textBox2.Text;
                string otch = textBox3.Text;
                string shop = textBox4.Text;
                string query = $"call update_kassir( {Id} , '{fam}' , '{name}' , '{otch}', '{shop}');";
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
