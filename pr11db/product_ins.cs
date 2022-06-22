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
    public partial class product_ins : Form
    {
        NpgsqlConnection Nc;
        public product_ins()
        {
            InitializeComponent();
        }
        
        public product_ins(NpgsqlConnection nc)
        {
            InitializeComponent();
            Nc = nc;

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

        
        }

        private void product_ins_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_prov_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_name_SelectedIndexChanged(object sender, EventArgs e)
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



                string query = $"call insert_product( {provider_id} , '{name}' , {price}, {kolvo});";
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
