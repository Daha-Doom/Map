using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace Map
{
    public partial class FormAddPoint : Form
    {
        double x, y;
        int quantity, idTech, id;
        DataTable dt = new DataTable();

        DBPoint dbPoint = new DBPoint();

        MySqlDataAdapter adapter = new MySqlDataAdapter();

        MySqlCommand command;



        //Ограничения TextBox
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }



        //Инициализация формы
        public FormAddPoint(string nameForm, double _x = 0, double _y = 0, int quant = 0, string cBName = "Викинг", int _id = 1)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            x = _x;
            y = _y;
            this.Text = nameForm;
            quantity = quant;
            comboBox1.Text = cBName;
            id = _id;

            comboBox1.SelectedItem = cBName;
            textBox1.Text = quant.ToString();
            textBox2.Text = x.ToString();
            textBox3.Text = y.ToString();

            command = new MySqlCommand("SELECT tech.* FROM tech", dbPoint.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nameTech";
            comboBox1.ValueMember = "idTech";
        }



        //Внесение данных
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                idTech = Convert.ToInt32(comboBox1.SelectedValue);
                quantity = Convert.ToInt32(textBox1.Text);
                x = Convert.ToDouble(textBox2.Text);
                y = Convert.ToDouble(textBox3.Text);

                command = new MySqlCommand();
                command.CommandType = CommandType.Text;

                //Добавление новой метки
                if (this.Text == "Добавить новую метку")
                    command.CommandText = ("INSERT INTO coordinates_of_points (coordinateX, coordinateY, quantity, idTech) values(@_x, @_y, @q, @idT)");

                //Изменение метки
                else
                { 
                    command.CommandText = ("UPDATE coordinates_of_points SET idPoint = @_id, coordinateX = @_x, coordinateY = @_y, quantity = @q, idTech = @idT WHERE idPoint = @_id");
                    command.Parameters.Add("@_id", MySqlDbType.Int32).Value = id;
                }

                command.Parameters.Add("@_x", MySqlDbType.Double).Value = x;
                command.Parameters.Add("@_y", MySqlDbType.Double).Value = y;
                command.Parameters.Add("@q", MySqlDbType.Int64).Value = quantity;
                command.Parameters.Add("@idT", MySqlDbType.Int64).Value = idTech;
                command.Connection = dbPoint.getConnection();


                dbPoint.openConnection();
                command.ExecuteNonQuery();
                dbPoint.closeConnection();

                Close();
            }
            else
                MessageBox.Show("Заполните все поля");
            
        }
    }
}
