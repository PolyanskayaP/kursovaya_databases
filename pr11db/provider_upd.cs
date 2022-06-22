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
    public partial class provider_upd : Form
    {
        NpgsqlConnection Nc;
        int Id;
        public provider_upd()
        {
            InitializeComponent();
        }

        public provider_upd(NpgsqlConnection nc, int id)
        {
            InitializeComponent();
            Nc = nc;
            Id = id;

            string query1 = "SELECT name FROM Provider WHERE id = "+ id +";";
            NpgsqlCommand npgc = new NpgsqlCommand(query1, Nc);
            textBox1.Text = npgc.ExecuteScalar().ToString();

            string query2 = "SELECT tel FROM Provider WHERE id = " + id + ";";
            npgc = new NpgsqlCommand(query2, Nc);
            textBox2.Text = npgc.ExecuteScalar().ToString();

            string query3 = "SELECT city FROM Provider WHERE id = " + id + ";";
            npgc = new NpgsqlCommand(query3, Nc);
            textBox3.Text = npgc.ExecuteScalar().ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) //tel
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //name
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) //city 
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string tel = textBox2.Text;
                string name = textBox1.Text;
                string city = textBox3.Text;
                string query = $"call update_provider( {Id} , '{name}' , '{tel}' , '{city}');";
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
