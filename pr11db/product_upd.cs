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
    public partial class product_upd : Form
    {
        NpgsqlConnection Nc;
        int Id;
        public product_upd(NpgsqlConnection nc, int id)
        {
            InitializeComponent();
            Nc = nc;
            Id = id;

            List<idpolya> list1 = new List<idpolya>();
            string query = "SELECT id, name FROM Provider ;";
            NpgsqlCommand npgc = new NpgsqlCommand(query, Nc);
            NpgsqlDataReader reader = npgc.ExecuteReader();
            list1.Clear();

            if (reader.HasRows)//Если пришли результаты
            {
                while (reader.Read())//Пока есть записи
                {
                    idpolya item = new idpolya();
                    item.id = (int)reader[0];
                    item.polya = reader[1].ToString();
                    list1.Add(item);
                }
            }

            comboBox1_prov.DataSource = list1;
            comboBox1_prov.DisplayMember = "polya";
            comboBox1_prov.ValueMember = "id";

            comboBox1_prov.SelectedIndexChanged += comboBox1_prov_SelectedIndexChanged;

            reader.Close();

            //    string query_c = "SELECT ";
            //   comboBox1_prov.

            string query11 = "select id_prov from product where id=" + Id + ";";
            npgc = new NpgsqlCommand(query11, Nc);
            int id_p = (int)npgc.ExecuteScalar();
            comboBox1_prov.SelectedValue = id_p;

            //string query11 = "SELECT name FROM Provider WHERE id = " + id + ";";
            //npgc = new NpgsqlCommand(query11, Nc);
            //textBox1.Text = npgc.ExecuteScalar().ToString();

            string query1 = "SELECT name FROM Product WHERE id = " + id + ";";
            npgc = new NpgsqlCommand(query1, Nc);
            textBox1.Text = npgc.ExecuteScalar().ToString();

            string query2 = "SELECT price FROM Product WHERE id = " + id + ";";
            npgc = new NpgsqlCommand(query2, Nc);
            numericUpDown1.Value = (int)npgc.ExecuteScalar();

            string query3 = "SELECT kolvo FROM Product WHERE id = " + id + ";";
            npgc = new NpgsqlCommand(query3, Nc);
            numericUpDown2.Value = (int)npgc.ExecuteScalar();
            

        }
        public product_upd()
        {
            InitializeComponent();
        }

        private void product_upd_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_prov_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int provider_id = (int)comboBox1_prov.SelectedValue;
                string name = textBox1.Text; //(string)comboBox2_name.SelectedItem;
                int price = (int)numericUpDown1.Value;
                int kolvo = (int)numericUpDown2.Value;

                string query = $"call update_product({Id} , '{name}' , {provider_id}  , {price}, {kolvo});";
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
