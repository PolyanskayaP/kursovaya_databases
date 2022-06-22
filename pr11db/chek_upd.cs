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
    public partial class chek_upd : Form
    {
        NpgsqlConnection Nc;
        int Id;
        
        public chek_upd(NpgsqlConnection nc, int id)
        {
            InitializeComponent();
            Nc = nc;
            Id = id;

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

            string que = "select id_kassir from Chek where id=" + Id + ";";
            npgc = new NpgsqlCommand(que, Nc);
            int id_p = (int)npgc.ExecuteScalar();
            comboBox1.SelectedValue = id_p;


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
            //comboBox2_prod
            que = "select id_prod from Chek where id=" + Id + ";";
            npgc = new NpgsqlCommand(que, Nc);
            id_p = (int)npgc.ExecuteScalar();
            comboBox2_prod.SelectedValue = id_p;

            List<idpolya> list3 = new List<idpolya>();
            string query3 = "SELECT distinct id_chek FROM Chek ;";
            npgc = new NpgsqlCommand(query3, Nc);
            reader = npgc.ExecuteReader();
            list3.Clear();

            if (reader.HasRows)//Если пришли результаты
            {
                while (reader.Read())//Пока есть записи
                {
                    idpolya item = new idpolya();
                    item.id = (int)reader[0];
                    item.polya = item.id.ToString();
                    list3.Add(item);
                }
            }

            comboBox2.DataSource = list3;
            comboBox2.DisplayMember = "polya";
            comboBox2.ValueMember = "id";

            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

            reader.Close();

            que = "select id_chek from Chek where id=" + Id + ";";
            npgc = new NpgsqlCommand(que, Nc);
            id_p = (int)npgc.ExecuteScalar();
            comboBox2.SelectedValue = id_p;

            string query1 = "SELECT kard FROM Chek WHERE id = " + id + ";";
            npgc = new NpgsqlCommand(query1, Nc);
            string k = npgc.ExecuteScalar().ToString();
            if (k == null)
                textBox1.Text = " ";
            else
                textBox1.Text = k;

            string query11 = "SELECT kolvo FROM Chek WHERE id = " + id + ";";
            npgc = new NpgsqlCommand(query11, Nc);
            numericUpDown1.Value = (int)npgc.ExecuteScalar();
            /////////////////////
            string query0 = "SELECT dat FROM Chek WHERE id = " + id + ";";
            npgc = new NpgsqlCommand(query0, Nc);
            DateTime date1 = (DateTime)npgc.ExecuteScalar();
            denb.Value = date1.Day;
            mes.Value = date1.Month;
            year.Value = date1.Year;
            chas.Value = date1.Hour;
            minut.Value = date1.Minute;
            sec.Value = date1.Second;
        }
        public chek_upd()
        {
            InitializeComponent();
        }
        //update_chek(up_id integer, up_id_kass integer, up_id_prod integer, 
        //up_id_chek integer, up_kolvo integer, up_kard varchar(16) ) 

        private void chek_upd_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_prod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int kassir_id = (int)comboBox1.SelectedValue;
                    int prod_id = (int)comboBox2_prod.SelectedValue;
                    int chek_id = (int)comboBox2.SelectedValue;
                    string kard = " ";
                    kard = textBox1.Text;
                    int kolvo = (int)numericUpDown1.Value;
                    DateTime date1 = new DateTime((int)year.Value, (int)mes.Value, (int)denb.Value, (int)chas.Value, (int)minut.Value, (int)sec.Value);
                    string dat2 = date1.ToString("yyyy-MM-dd HH:mm:ss");
                string query = $"call update_chek({Id} , {kassir_id} , {prod_id}  , {chek_id}, {kolvo} , '{dat2}' , '{kard}');";
                
                NpgsqlCommand npgc = new NpgsqlCommand(query, Nc);
                npgc.ExecuteNonQuery();

                MessageBox.Show(
                    "Обновление прошло успешно, нажмите select"
                    );
            }
            catch(Npgsql.PostgresException)
            {
                MessageBox.Show(
                    "У вас недостаточно прав для обновления."
                    );
            }
            catch(System.ArgumentOutOfRangeException)
            {
                MessageBox.Show(
                    "Неправильная дата."
                    );
            }            
        }
    }
}
