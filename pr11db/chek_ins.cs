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
    public partial class chek_ins : Form
    {
        NpgsqlConnection Nc;
        public chek_ins()
        {
            InitializeComponent();
        }

        public chek_ins(NpgsqlConnection nc)
        {
            InitializeComponent();
            Nc = nc;

            List<idpolya> list1 = new List<idpolya>();
            string query = "SELECT id, fam FROM Kassir ;";
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

            comboBox1.DataSource = list1;
            comboBox1.DisplayMember = "polya";
            comboBox1.ValueMember = "id";

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            reader.Close();

            List<idpolya> list2 = new List<idpolya>();
            string query2 = "SELECT id, name FROM Product ;";
            npgc = new NpgsqlCommand(query2, Nc);
            reader = npgc.ExecuteReader();
            list2.Clear();

            if (reader.HasRows)//Если пришли результаты
            {
                while (reader.Read())//Пока есть записи
                {
                    idpolya item = new idpolya();
                    item.id = (int)reader[0];
                    item.polya = reader[1].ToString();
                    list2.Add(item);
                }
            }

            comboBox2_prod.DataSource = list2;
            comboBox2_prod.DisplayMember = "polya";
            comboBox2_prod.ValueMember = "id";

            comboBox2_prod.SelectedIndexChanged += comboBox2_prod_SelectedIndexChanged;

            reader.Close();
        }

        private void chek_ins_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_prod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int f = 0;

                if (checkBox1.Checked == true)
                {
                    f = 1;
                }
                int kolvo = (int)numericUpDown1.Value;
                string karta = textBox1.Text;
                int prod_id = (int)comboBox2_prod.SelectedValue;
                int kas_id = (int)comboBox1.SelectedValue;

                //insert_chek(id_kas integer,
                //                 id_product integer, in_kolvo integer, f integer default 0,
                //                in_kard varchar(16) default '')

                string query = $"call insert_chek( {kas_id} , {prod_id} , {kolvo} , {f} , '{karta}');";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //karta
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
