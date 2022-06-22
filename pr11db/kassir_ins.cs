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
    public partial class kassir_ins : Form
    {
        NpgsqlConnection Nc;
        public kassir_ins()
        {
            InitializeComponent();

            
        }

        public kassir_ins(NpgsqlConnection nc)
        {
            InitializeComponent();
            Nc = nc;

           

        }

        private void kassir_ins_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fam = textBox1.Text;//(string)comboBox1_fam.SelectedItem;
                string name = textBox2.Text;//(string)comboBox2_name.SelectedItem;
                string otch = textBox3.Text;//(string)comboBox3_otch.SelectedItem;
                string shop = textBox4.Text;//(string)comboBox4_shop.SelectedItem;
                string query = $"call insert_kassir( '{fam}' , '{name}' , '{otch}' , '{shop}');";
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

        private void comboBox1_fam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_otch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_shop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
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
    }
}
