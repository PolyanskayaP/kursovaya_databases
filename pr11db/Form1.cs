using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

//66 Информационно-кассовая
//система
//Учет покупок на кассе (цены,
//списание со склада),
//формирование чеков.Информация
//о кассире
//1 1

namespace pr11db
{
    public partial class Form1 : Form
    {
        //подключение к postgres
        //string connString = "Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase";
        //static string connString = "Host=127.0.0.1;Username=postgres;Password=mysecretpassword;Database=kursovaya";
        static string connString = "";

        private NpgsqlConnection nc;
        

        public Form1()
        {
            InitializeComponent();
        //    button1_Click(null, null);
            comboBox1.Items.Add("Provider");
            comboBox1.Items.Add("Product");
            comboBox1.Items.Add("Chek");
            comboBox1.Items.Add("Kassir");

            comboBox1.Items.Add("view2");

            comboBox1.SelectedItem = "Provider";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int id = (int)listBox1.SelectedValue;
        }

        private void select1_Click(object sender, EventArgs e)
        {
            try
            {
                List<idpolya> list1 = new List<idpolya>();
                List<textpolya> list2 = new List<textpolya>();
                //idpolya item = new idpolya();
                string table = comboBox1.SelectedItem.ToString();

                string query = "SELECT * FROM " + table + " ;";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                //listBox1.Items.Clear();
                list1.Clear();
                list2.Clear();
                listBox3.Items.Clear();
                if (table == "Provider")
                {
                    string vLB3 = "имя                            телефон           город";
                    listBox3.Items.Add(vLB3);
                }
                else
                if (table == "Product")
                {
                    string vLB3 = "id поставщика    имя                    цена      количество";
                    listBox3.Items.Add(vLB3);
                }
                else
                if (table == "Kassir")
                {
                    string vLB3 = "фамилия         имя           отчество          магазин";
                    listBox3.Items.Add(vLB3);
                }
                else
                if (table == "Chek")
                {
                    string vLB3 = "id_kass id_prod id_chek kard             kolvo  date";
                    listBox3.Items.Add(vLB3);
                }
                else
                if (table == "view2")
                {
                    string vLB3 = "товар                          цена       поставщик";
                    listBox3.Items.Add(vLB3);
                }

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {

                        // выводим данные столбцов текущей строки в listBox1
                        if (table == "Provider")
                        {
                            idpolya item = new idpolya();
                            item.id = (int)reader[0];
                            string R1 = reader[1].ToString();
                            string R2 = reader[2].ToString();
                            string R3 = reader[3].ToString();

                            int L1 = R1.Length;
                            int N1 = 30 - L1;
                            for (int i = 0; i < N1; i++)
                                R1 = R1 + " ";

                            int L2 = R2.Length;
                            int N2 = 17 - L2;
                            for (int i = 0; i < N2; i++)
                                R2 = R2 + " ";

                            int L3 = R3.Length;
                            int N3 = 20 - L3;
                            for (int i = 0; i < N3; i++)
                                R3 = R3 + " ";

                            item.polya = R1 + " " + R2 + " " + R3;
                            list1.Add(item);
                        }
                        else
                            if (table == "Product")
                        {
                            idpolya item = new idpolya();
                            item.id = (int)reader[0];
                            string R1 = reader[1].ToString();
                            string R2 = reader[2].ToString();
                            string R3 = reader[3].ToString();
                            string R4 = reader[4].ToString();

                            int L1 = R1.Length;
                            int N1 = 16 - L1;
                            for (int i = 0; i < N1; i++)
                                R1 = R1 + " ";

                            int L2 = R2.Length;
                            int N2 = 22 - L2;
                            for (int i = 0; i < N2; i++)
                                R2 = R2 + " ";

                            int L3 = R3.Length;
                            int N3 = 10 - L3;
                            for (int i = 0; i < N3; i++)
                                R3 = R3 + " ";

                            int L4 = R4.Length;
                            int N4 = 10 - L4;
                            for (int i = 0; i < N4; i++)
                                R4 = R4 + " ";

                            item.polya = R1 + " " + R2 + " " + R3 + " " + R4;
                            list1.Add(item);
                            //listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString()); 
                        }
                        else
                            if (table == "Kassir")
                        {
                            idpolya item = new idpolya();
                            item.id = (int)reader[0];

                            string R1 = reader[1].ToString();
                            string R2 = reader[2].ToString();
                            string R3 = reader[3].ToString();
                            string R4 = reader[4].ToString();

                            int L1 = R1.Length;
                            int N1 = 15 - L1;
                            for (int i = 0; i < N1; i++)
                                R1 = R1 + " ";

                            int L2 = R2.Length;
                            int N2 = 13 - L2;
                            for (int i = 0; i < N2; i++)
                                R2 = R2 + " ";

                            int L3 = R3.Length;
                            int N3 = 17 - L3;
                            for (int i = 0; i < N3; i++)
                                R3 = R3 + " ";

                            int L4 = R4.Length;
                            int N4 = 50 - L4;
                            for (int i = 0; i < N4; i++)
                                R4 = R4 + " ";

                            item.polya = R1 + " " + R2 + " " + R3 + " " + R4;
                            list1.Add(item);
                            //listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString()); 
                        }
                        else
                            if (table == "Chek")
                        {
                            idpolya item = new idpolya();
                            item.id = (int)reader[0];

                            string R1 = reader[1].ToString();
                            string R2 = reader[2].ToString();
                            string R3 = reader[3].ToString();
                            string R4 = reader[4].ToString();
                            string R5 = reader[5].ToString();
                            string R6 = reader[6].ToString();

                            int L1 = R1.Length;
                            int N1 = 7 - L1;
                            for (int i = 0; i < N1; i++)
                                R1 = R1 + " ";

                            int L2 = R2.Length;
                            int N2 = 7 - L2;
                            for (int i = 0; i < N2; i++)
                                R2 = R2 + " ";

                            int L3 = R3.Length;
                            int N3 = 7 - L3;
                            for (int i = 0; i < N3; i++)
                                R3 = R3 + " ";

                            int L4 = R4.Length;
                            int N4 = 16 - L4;
                            for (int i = 0; i < N4; i++)
                                R4 = R4 + " ";

                            int L5 = R5.Length;
                            int N5 = 6 - L5;
                            for (int i = 0; i < N5; i++)
                                R5 = R5 + " ";

                            int L6 = R6.Length;
                            int N6 = 19 - L6;
                            for (int i = 0; i < N6; i++)
                                R6 = R6 + " ";

                            item.polya = R1 + " " + R2 + " " + R3 + " " + R4 + " " + R5 + " " + R6;
                            list1.Add(item);
                            //listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() + " " + reader[5].ToString() + " " + reader[6].ToString());
                        }
                        else
                            if (table == "view2")
                        {
                            textpolya item = new textpolya();
                            item.text = reader[0].ToString();

                            string R1 = reader[0].ToString();
                            string R2 = reader[1].ToString();
                            string R3 = reader[2].ToString();

                            int L1 = R1.Length;
                            int N1 = 30 - L1;
                            for (int i = 0; i < N1; i++)
                                R1 = R1 + " ";

                            int L2 = R2.Length;
                            int N2 = 10 - L2;
                            for (int i = 0; i < N2; i++)
                                R2 = R2 + " ";

                            int L3 = R3.Length;
                            int N3 = 30 - L3;
                            for (int i = 0; i < N3; i++)
                                R3 = R3 + " ";

                            item.polya = R1 + " " + R2 + " " + R3;
                            list2.Add(item);
                            //listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() + " " + reader[5].ToString() + " " + reader[6].ToString());
                        }
                    }
                    if (table != "view2")
                    {
                        listBox1.DataSource = list1;
                        listBox1.DisplayMember = "polya";
                        listBox1.ValueMember = "id";
                    }
                    else
                    {
                        listBox1.DataSource = list2;
                        listBox1.DisplayMember = "polya";
                        listBox1.ValueMember = "text";
                    }

                    listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch(System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }




        private void select2_Click(object sender, EventArgs e)
        {
            string query = "SELECT catname, id FROM cats ORDER BY catName";
            NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
            NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
            // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

            listBox1.Items.Clear();

            if (reader.HasRows)//Если пришли результаты
            {
                while (reader.Read())//Пока есть записи
                {
                    // выводим данные столбцов текущей строки в listBox1
                    listBox1.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " );
                }
            }

            // закрываем OleDbDataReader
            reader.Close();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            //string query = "INSERT INTO cats (catname, id) VALUES ('Мари', 14)";
            //NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
            //npgc.ExecuteNonQuery();
            string table = comboBox1.SelectedItem.ToString();
            if (table == "Provider")
            {
                provider_ins newForm = new provider_ins(nc);
                newForm.Show();
            }
            else
                        if (table == "Product")
            {
                product_ins newForm = new product_ins(nc);
                newForm.Show();
            }
            else
                        if (table == "Kassir")
            {
                kassir_ins newForm = new kassir_ins(nc);
                newForm.Show();
            }
            else
                        if (table == "Chek")
            {
                chek_ins newForm = new chek_ins(nc);
                newForm.Show();
            }
            else
                        if (table == "view2")
            {
                MessageBox.Show(
                        "Нельзя добавить данные в представление"
                        );
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            //string query = "UPDATE cats SET catname = 'Klubnika' WHERE id = 1";
            //NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
            //npgc.ExecuteNonQuery();
            //provider_upd newForm = new provider_upd(nc);
            //newForm.Show();            
            string table = comboBox1.SelectedItem.ToString();
            if (table == "view2")
            {
                string text = listBox1.SelectedValue.ToString();
                view2_upd newForm = new view2_upd(nc, text);
                newForm.Show();
            }
            else
            {
                int id = (int)listBox1.SelectedValue;
                if (table == "Provider")
                {
                    provider_upd newForm = new provider_upd(nc, id);
                    newForm.Show();
                }
                else
                            if (table == "Product")
                {
                    product_upd newForm = new product_upd(nc, id);
                    newForm.Show();
                }
                else
                            if (table == "Kassir")
                {
                    kassir_upd newForm = new kassir_upd(nc, id);
                    newForm.Show();
                }
                else
                            if (table == "Chek")
                {
                    chek_upd newForm = new chek_upd(nc, id);
                    newForm.Show();
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                string table = comboBox1.SelectedItem.ToString();
                if (table == "view2")
                {
                    MessageBox.Show(
                            "Нельзя удалить данные из представления"
                            );
                }
                else
                {
                    try
                    {
                        
                        int id = (int)listBox1.SelectedValue;                     
                        string query = "-";
                        if (table == "Provider")
                        {
                            query = "CALL delete_provider(" + id + ");";
                        }
                        else
                            if (table == "Product")
                        {
                            query = "CALL delete_product(" + id + ");";
                        }
                        else
                            if (table == "Chek")
                        {
                            query = "CALL delete_chek(" + id + ");";
                        }
                        else
                            if (table == "Kassir")
                        {
                            query = "CALL delete_kassir(" + id + ");";
                        }


                        NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                        npgc.ExecuteNonQuery();

                        select1.PerformClick();
                        MessageBox.Show(
                            "Удаление прошло успешно"
                            );
                    }
                    catch (System.NullReferenceException)
                    {
                        MessageBox.Show(
                            "Сначала надо войти."
                            );
                    }

                }
            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show(
                    "У вас недостаточно прав для удаления."
                    );
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        // обработчик события закрытия формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // заркываем соединение с БД
            
                //nc.Close();
            
                connString = "Host=127.0.0.1;Username=postgres;Password=mysecretpassword;Database=kursovaya";
                nc = new NpgsqlConnection(connString);
                nc.Open();
                nc.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connString = "Host=127.0.0.1;Username=" + LoginTB.Text + ";Password=" + PasswordTB.Text + ";Database=kursovaya";
                nc = new NpgsqlConnection(connString);
                nc.Open();

                MessageBox.Show(
                "Вы успешно авторизованы ;)"
                );
                ///
                insert.Visible = true;
                update.Visible = true;
                delete.Visible = true;
                button14.Visible = true;
                button15.Visible = true;
                button16.Visible = true;
                button17.Visible = true;
                button18.Visible = true;

                select1.PerformClick();

                List<textpolya> list2 = new List<textpolya>();
                string query2 = "SELECT name FROM Product ;";
                NpgsqlCommand npgc = new NpgsqlCommand(query2, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();
                list2.Clear();

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        textpolya item = new textpolya();
                        item.text = reader[0].ToString();
                        item.polya = item.text;
                        list2.Add(item);
                    }
                }

                comboBox2.DataSource = list2;
                comboBox2.DisplayMember = "polya";
                comboBox2.ValueMember = "text";

                comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

                reader.Close();

                List<textpolya> list3 = new List<textpolya>();
                string query3 = "SELECT DISTINCT city FROM Provider ;";
                npgc = new NpgsqlCommand(query3, nc);
                reader = npgc.ExecuteReader();
                list3.Clear();

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        textpolya item = new textpolya();
                        item.text = reader[0].ToString();
                        item.polya = item.text;
                        list3.Add(item);
                    }
                }

                comboBox4.DataSource = list3;
                comboBox4.DisplayMember = "polya";
                comboBox4.ValueMember = "text";

                comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;

                reader.Close();

                List<textpolya> list33 = new List<textpolya>();
                string query33 = "SELECT fam FROM Kassir ;";
                npgc = new NpgsqlCommand(query33, nc);
                reader = npgc.ExecuteReader();
                list33.Clear();

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        textpolya item = new textpolya();
                        item.text = reader[0].ToString();
                        item.polya = item.text;
                        list33.Add(item);
                    }
                }

                comboBox3.DataSource = list33;
                comboBox3.DisplayMember = "polya";
                comboBox3.ValueMember = "text";

                comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;

                reader.Close();
            }
            catch
            {
                MessageBox.Show(
                "Что-то пошло не так. Авторизуйтесь заново."
                );
            }                        
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT Product.name, Product.price, Product.kolvo, Provider.name, Provider.city, case WHEN Product.price > 400 then Product.price * 0.2 when Product.price <= 400 then Product.price * 0.1 end as b_amount FROM Product JOIN Provider ON Provider.id = Product.id_prov;";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                listBox2.Items.Clear();
                listBox4.Items.Clear();
                string vLB3 = "продукт         цена   кол-во поставщик город      благот.";
                listBox4.Items.Add(vLB3);

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        string R0 = reader[0].ToString();
                        string R1 = reader[1].ToString();
                        string R2 = reader[2].ToString();
                        string R3 = reader[3].ToString();
                        string R4 = reader[4].ToString();
                        string R5 = reader[5].ToString();

                        int L0 = R0.Length;
                        int N0 = 15 - L0;
                        for (int i = 0; i < N0; i++)
                            R0 = R0 + " ";

                        int L1 = R1.Length;
                        int N1 = 6 - L1;
                        for (int i = 0; i < N1; i++)
                            R1 = R1 + " ";

                        int L2 = R2.Length;
                        int N2 = 6 - L2;
                        for (int i = 0; i < N2; i++)
                            R2 = R2 + " ";

                        int L3 = R3.Length;
                        int N3 = 9 - L3;
                        for (int i = 0; i < N3; i++)
                            R3 = R3 + " ";

                        int L4 = R4.Length;
                        int N4 = 10 - L4;
                        for (int i = 0; i < N4; i++)
                            R4 = R4 + " ";

                        int L5 = R5.Length;
                        int N5 = 5 - L5;
                        for (int i = 0; i < N5; i++)
                            R5 = R5 + " ";

                        listBox2.Items.Add(R0 + " " + R1 + " " + R2 + " " + R3 + " " + R4 + " " + R5 + " ");
                    }
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select name, price, kolvo from (select * from product where price > 100) as abc where kolvo> 3";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                listBox2.Items.Clear();
                listBox4.Items.Clear();
                string vLB3 = "имя                  цена   количество";
                listBox4.Items.Add(vLB3);

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        string R0 = reader[0].ToString();
                        string R1 = reader[1].ToString();
                        string R2 = reader[2].ToString();

                        int L0 = R0.Length;
                        int N0 = 20 - L0;
                        for (int i = 0; i < N0; i++)
                            R0 = R0 + " ";

                        int L1 = R1.Length;
                        int N1 = 6 - L1;
                        for (int i = 0; i < N1; i++)
                            R1 = R1 + " ";

                        int L2 = R2.Length;
                        int N2 = 4 - L2;
                        for (int i = 0; i < N2; i++)
                            R2 = R2 + " ";

                        listBox2.Items.Add(R0 + " " + R1 + " " + R2);
                    }
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select (select floor(avg(kolvo)) from product) as srednee, name, price, kolvo from product where kolvo > 3";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                listBox2.Items.Clear();
                listBox4.Items.Clear();
                string vLB3 = "среднее кол-во имя                  цена   количество";
                listBox4.Items.Add(vLB3);

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        string R0 = reader[0].ToString();
                        string R1 = reader[1].ToString();
                        string R2 = reader[2].ToString();
                        string R3 = reader[3].ToString();

                        int L0 = R0.Length;
                        int N0 = 14 - L0;
                        for (int i = 0; i < N0; i++)
                            R0 = R0 + " ";

                        int L1 = R1.Length;
                        int N1 = 20 - L1;
                        for (int i = 0; i < N1; i++)
                            R1 = R1 + " ";

                        int L2 = R2.Length;
                        int N2 = 6 - L2;
                        for (int i = 0; i < N2; i++)
                            R2 = R2 + " ";

                        int L3 = R3.Length;
                        int N3 = 4 - L3;
                        for (int i = 0; i < N3; i++)
                            R3 = R3 + " ";
                        listBox2.Items.Add(R0 + " " + R1 + " " + R2 + " " + R3);
                    }
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select name, price, kolvo from product where kolvo > (select floor(avg(kolvo)) from product)";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                listBox2.Items.Clear();
                listBox4.Items.Clear();
                string vLB3 = "имя                  цена   количество";
                listBox4.Items.Add(vLB3);

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        string R0 = reader[0].ToString();
                        string R1 = reader[1].ToString();
                        string R2 = reader[2].ToString();

                        int L0 = R0.Length;
                        int N0 = 20 - L0;
                        for (int i = 0; i < N0; i++)
                            R0 = R0 + " ";

                        int L1 = R1.Length;
                        int N1 = 6 - L1;
                        for (int i = 0; i < N1; i++)
                            R1 = R1 + " ";

                        int L2 = R2.Length;
                        int N2 = 4 - L2;
                        for (int i = 0; i < N2; i++)
                            R2 = R2 + " ";

                        listBox2.Items.Add(R0 + " " + R1 + " " + R2);

                    }
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"SELECT  (select name from product where product.id=chek.id_prod), kolvo,
        (SELECT shop FROM Kassir
        WHERE Kassir.id = Chek.id_kassir) AS Shop
FROM Chek;
            ";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                listBox2.Items.Clear();
                listBox4.Items.Clear();
                string vLB3 = "имя                  кол-во магазин";
                listBox4.Items.Add(vLB3);

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        string R0 = reader[0].ToString();
                        string R1 = reader[1].ToString();
                        string R2 = reader[2].ToString();

                        int L0 = R0.Length;
                        int N0 = 20 - L0;
                        for (int i = 0; i < N0; i++)
                            R0 = R0 + " ";

                        int L1 = R1.Length;
                        int N1 = 6 - L1;
                        for (int i = 0; i < N1; i++)
                            R1 = R1 + " ";

                        int L2 = R2.Length;
                        int N2 = 50 - L2;
                        for (int i = 0; i < N2; i++)
                            R2 = R2 + " ";

                        listBox2.Items.Add(R0 + " " + R1 + " " + R2);
                    }
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"SELECT  name, 
        (SELECT name FROM Provider
        WHERE Provider.id = Product.id_prov) AS Provider
FROM Product;
            ";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                listBox2.Items.Clear();
                listBox4.Items.Clear();
                string vLB3 = "продукт              поставщик";
                listBox4.Items.Add(vLB3);

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        string R0 = reader[0].ToString();
                        string R1 = reader[1].ToString();

                        int L0 = R0.Length;
                        int N0 = 20 - L0;
                        for (int i = 0; i < N0; i++)
                            R0 = R0 + " ";

                        int L1 = R1.Length;
                        int N1 = 20 - L1;
                        for (int i = 0; i < N1; i++)
                            R1 = R1 + " ";

                        listBox2.Items.Add(R0 + " " + R1);
                    }
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"SELECT name,
	   price,
        (SELECT floor(AVG(Price)) FROM Product AS SredProd 
         WHERE SredProd.id_prov=Prod.id_prov)  AS AvgPrice,
		 (select city from provider where id=id_prov)
FROM Product AS Prod;
            ";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                listBox2.Items.Clear();
                listBox4.Items.Clear();
                string vLB3 = "имя                  цена   сред.  город";
                listBox4.Items.Add(vLB3);

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        string R0 = reader[0].ToString();
                        string R1 = reader[1].ToString();
                        string R2 = reader[2].ToString();
                        string R3 = reader[3].ToString();

                        int L0 = R0.Length;
                        int N0 = 20 - L0;
                        for (int i = 0; i < N0; i++)
                            R0 = R0 + " ";

                        int L1 = R1.Length;
                        int N1 = 6 - L1;
                        for (int i = 0; i < N1; i++)
                            R1 = R1 + " ";

                        int L2 = R2.Length;
                        int N2 = 6 - L2;
                        for (int i = 0; i < N2; i++)
                            R2 = R2 + " ";

                        listBox2.Items.Add(R0 + " " + R1 + " " + R2 + " " + R3);
                    }
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int su = (int)numericUpDown2.Value;
                string query = @"SELECT Chek.id_chek, STRING_AGG((select Product.name from Product where Product.id = Chek.id_prod), ', ') 
AS products,
SUM(Chek.kolvo * (select Product.price from Product where Product.id = Chek.id_prod)) 
AS Summa
FROM Chek
GROUP BY Chek.id_chek
HAVING SUM(Chek.kolvo * (select Product.price from Product where Product.id = Chek.id_prod)) > " + su + " ;";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                listBox2.Items.Clear();
                listBox4.Items.Clear();
                string vLB3 = "id чека товары                                   сумма";
                listBox4.Items.Add(vLB3);

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        string R0 = reader[0].ToString();
                        string R1 = reader[1].ToString();
                        string R2 = reader[2].ToString();

                        int L0 = R0.Length;
                        int N0 = 7 - L0;
                        for (int i = 0; i < N0; i++)
                            R0 = R0 + " ";

                        int L1 = R1.Length;
                        int N1 = 40 - L1;
                        for (int i = 0; i < N1; i++)
                            R1 = R1 + " ";

                        int L2 = R2.Length;
                        int N2 = 6 - L2;
                        for (int i = 0; i < N2; i++)
                            R2 = R2 + " ";

                        listBox2.Items.Add(R0 + " " + R1 + " " + R2);
                    }
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"SELECT name,price,kolvo FROM Product
WHERE Product.id_prov = ANY
(SELECT Provider.id FROM Provider WHERE Provider.city = 'Moscow');
            ";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                listBox2.Items.Clear();
                listBox4.Items.Clear();
                string vLB3 = "имя                  цена   количество";
                listBox4.Items.Add(vLB3);

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        string R0 = reader[0].ToString();
                        string R1 = reader[1].ToString();
                        string R2 = reader[2].ToString();

                        int L0 = R0.Length;
                        int N0 = 20 - L0;
                        for (int i = 0; i < N0; i++)
                            R0 = R0 + " ";

                        int L1 = R1.Length;
                        int N1 = 6 - L1;
                        for (int i = 0; i < N1; i++)
                            R1 = R1 + " ";

                        int L2 = R2.Length;
                        int N2 = 6 - L2;
                        for (int i = 0; i < N2; i++)
                            R2 = R2 + " ";

                        listBox2.Items.Add(R0 + " " + R1 + " " + R2);
                    }
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"select name, price from Product where 
price < all(select price from product join chek on product.id = chek.id_prod )
";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                listBox2.Items.Clear();
                listBox4.Items.Clear();
                string vLB3 = "имя                  цена";
                listBox4.Items.Add(vLB3);

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        string R0 = reader[0].ToString();
                        string R1 = reader[1].ToString();

                        int L0 = R0.Length;
                        int N0 = 20 - L0;
                        for (int i = 0; i < N0; i++)
                            R0 = R0 + " ";

                        int L1 = R1.Length;
                        int N1 = 6 - L1;
                        for (int i = 0; i < N1; i++)
                            R1 = R1 + " ";

                        listBox2.Items.Add(R0 + " " + R1);
                    }
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"select name, price, (select floor(price*0.9)) as with_sale
from product where floor(price * 0.9) < 300;
            ";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                listBox2.Items.Clear();
                listBox4.Items.Clear();
                string vLB3 = "имя                  цена   со_скидкой";
                listBox4.Items.Add(vLB3);

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        string R0 = reader[0].ToString();
                        string R1 = reader[1].ToString();
                        string R2 = reader[2].ToString();

                        int L0 = R0.Length;
                        int N0 = 20 - L0;
                        for (int i = 0; i < N0; i++)
                            R0 = R0 + " ";

                        int L1 = R1.Length;
                        int N1 = 6 - L1;
                        for (int i = 0; i < N1; i++)
                            R1 = R1 + " ";

                        int L2 = R2.Length;
                        int N2 = 6 - L2;
                        for (int i = 0; i < N2; i++)
                            R2 = R2 + " ";

                        listBox2.Items.Add(R0 + " " + R1 + " " + R2);
                    }
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from provider where (city='Tolyatti' OR city='Moscow');";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                listBox2.Items.Clear();
                listBox4.Items.Clear();
                string vLB3 = "имя                  телефон     город";
                listBox4.Items.Add(vLB3);

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        string R0 = reader[1].ToString();
                        string R1 = reader[2].ToString();
                        string R2 = reader[3].ToString();

                        int L0 = R0.Length;
                        int N0 = 20 - L0;
                        for (int i = 0; i < N0; i++)
                            R0 = R0 + " ";

                        int L1 = R1.Length;
                        int N1 = 11 - L1;
                        for (int i = 0; i < N1; i++)
                            R1 = R1 + " ";

                        int L2 = R2.Length;
                        int N2 = 20 - L2;
                        for (int i = 0; i < N2; i++)
                            R2 = R2 + " ";

                        listBox2.Items.Add(R0 + " " + R1 + " " + R2);
                    }
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                string ffam = comboBox3.SelectedValue.ToString();
                string query = $"SELECT fam, name FROM Kassir WHERE fam='{ffam}';";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                listBox2.Items.Clear();
                listBox4.Items.Clear();

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        // выводим данные столбцов текущей строки в listBox1
                        listBox2.Items.Add(reader[0].ToString() + " " + reader[1].ToString());
                    }
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                string prod = comboBox2.SelectedValue.ToString();
                string query = $"call down_price_kol('{prod}');";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                npgc.ExecuteScalar();
                MessageBox.Show(
                    "функция down_price_kol применена"
                    );
            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show(
                    "У вас недостаточно прав для использования функции down_price_kol."
                    );
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                int ko = (int)numericUpDown1.Value;
                string query = $"call cur_prod_zakaz({ko});";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                npgc.ExecuteScalar();
                MessageBox.Show(
                    "функция cur_prod_zakaz применена"
                    );
            }
            catch
            {
                MessageBox.Show(
                    "У вас недостаточно прав для использования функции cur_prod_zakaz."
                    );
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                string gorod = comboBox4.SelectedValue.ToString();
                string query = $"select * from prod_from_city('{gorod}');";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                NpgsqlDataReader reader = npgc.ExecuteReader();//Если запрос возвращает таблицу
                                                               // получаем объект NpgsqlDataReader для чтения табличного результата запроса SELECT

                listBox2.Items.Clear();
                listBox4.Items.Clear();
                string vLB3 = "имя                  цена   город";
                listBox4.Items.Add(vLB3);

                if (reader.HasRows)//Если пришли результаты
                {
                    while (reader.Read())//Пока есть записи
                    {
                        string R0 = reader[0].ToString();
                        string R1 = reader[1].ToString();
                        string R2 = reader[2].ToString();

                        int L0 = R0.Length;
                        int N0 = 20 - L0;
                        for (int i = 0; i < N0; i++)
                            R0 = R0 + " ";

                        int L1 = R1.Length;
                        int N1 = 6 - L1;
                        for (int i = 0; i < N1; i++)
                            R1 = R1 + " ";

                        int L2 = R2.Length;
                        int N2 = 20 - L2;
                        for (int i = 0; i < N2; i++)
                            R2 = R2 + " ";

                        listBox2.Items.Add(R0 + " " + R1 + " " + R2);
                    }
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                listBox4.Items.Clear();
                string vLB3 = "продукт";
                listBox4.Items.Add(vLB3);

                string gorod = comboBox4.SelectedValue.ToString();
                string query = $"select * from prod_min_from_city('{gorod}');";
                NpgsqlCommand npgc = new NpgsqlCommand(query, nc);
                listBox2.Items.Add(npgc.ExecuteScalar().ToString());
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(
                    "Сначала надо войти."
                    );
            }
        }      

        private void button20_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox4.Items.Clear();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    } 
}
 