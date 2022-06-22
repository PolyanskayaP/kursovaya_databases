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
    public partial class provider_ins : Form
    {
        NpgsqlConnection Nc;
        public provider_ins()
        {
            InitializeComponent();
            

        }

        public provider_ins(NpgsqlConnection nc)
        {
            InitializeComponent();
            Nc = nc;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void prv_ins_Click(object sender, EventArgs e)
        {
            try
            {
                string tel = textBox1.Text;
                string name = textBox2.Text;
                string city = textBox3.Text;
                string query = $"call insert_provider( '{tel}' , '{name}' , '{city}');";
                NpgsqlCommand npgc = new NpgsqlCommand(query, Nc);
                npgc.ExecuteNonQuery();
                MessageBox.Show(
                    "Добавление прошло успешно, нажмите select для обновления данных"
                    );
            }
            catch
            {
                MessageBox.Show(
                    "У вас недостаточно прав для добавления."
                    );
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_tel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_city_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
