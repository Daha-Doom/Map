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
        int quantity, idTech;
        DataTable dt = new DataTable();

        DBPoint dbPoint = new DBPoint();

        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command;

        public FormAddPoint(double _x = 0, double _y = 0)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            x = _x;
            y = _y;

            textBox2.Text = x.ToString();
            textBox3.Text = y.ToString();

            command = new MySqlCommand("SELECT tech.* FROM tech", dbPoint.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nameTech";
            comboBox1.ValueMember = "idTech";
        }

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
                command.CommandText = ("INSERT INTO coordinates_of_points (coordinateX, coordinateY, quantity, idTech) values(@_x, @_y, @q, @idT)");
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
