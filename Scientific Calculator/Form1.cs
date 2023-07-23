using System;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;
using System.Data;

namespace Scientific_Calculator
{
    public partial class Form1 : Form
    {
        string val1, val2,address;
        char sign;
        int s;
        double Pi, Ans;
        public Form1()
        {
            InitializeComponent();
            Pi = 3.1415926535897931;
            comboBox1.SelectedIndex = 0;
             address = "Data Source=DESKTOP-BTIF83O\\SQLEXPRESS;Initial Catalog=Calculator;Integrated Security=True";
            //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BTIF83O\SQLEXPRESS;Initial Catalog=Calculator;Integrated Security=True");
        }
        public int Facto2(string value)
        {
            int count = Convert.ToInt32(value);
            int fact = 1;
            for (int i = count; i > 0; i--)
            {
                fact *= i;
            }
            return fact;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            val1 = textBox1.Text;
            textBox2.Text = $"{val1}!";
            sign = '!';
        }

        private void button31_Click(object sender, EventArgs e)
        {

            equalbtn();
        }
        private void equalbtn()
        {
            if (sign == '!')
            {
                int count = Convert.ToInt32(val1);
                int fact = 1;
                for (int i = count; i > 0; i--)
                {
                    fact *= i;
                }
                Ans = fact;
                textBox1.Text = fact.ToString();
                querie();
            }
            else if (sign == 'C')
            {
                val2 = textBox1.Text;
                textBox2.Text = $"{val1}C{val2}";
                textBox1.Text = "";
                int n = Facto2(val1);
                int r = Facto2(val2);
                int minus = (int)(Convert.ToDouble(val1) - Convert.ToDouble(val2));
                s = Facto2(minus.ToString());
                int final = r * s;
                final = n / final;
                Ans = final;
                textBox1.Text = final.ToString();
                querie();
            }
            else if (sign == '%')
            {
                val2 = textBox1.Text;
                float n = Convert.ToInt32(val1);
                float x = Convert.ToInt32(val2);
                n = n % x;
                Ans = n;
                textBox1.Text = n.ToString();
                querie();
            }
            else if (sign == 'P')
            {
                val2 = textBox1.Text;
                textBox2.Text = $"{val1}P{val2}";
                textBox1.Text = "";
                int n = Facto2(val1);
                int minus = (int)(Convert.ToDouble(val1) - Convert.ToDouble(val2));
                s = Facto2(minus.ToString());
                int final = n / s;
                Ans = final;
                textBox1.Text = final.ToString();
                querie();
            }
            else if (sign == 's')
            {
                val1 = textBox1.Text;
                textBox2.Text = $"√{val1}";
                double Square_root = Convert.ToDouble(val1);
                Square_root = Math.Sqrt(Square_root);
                Ans = Square_root;
                textBox1.Text = Square_root.ToString();
                querie();
            }
            else if (sign == 'p')
            {
                val1 = textBox1.Text;
                textBox2.Text = $"𝜋";
                Ans = Pi;
                textBox1.Text = Pi.ToString();
                querie();
            }
            else if (sign == '2')
            {
                int square = Convert.ToInt32(val1);
                square *= square;
                Ans = square;
                textBox1.Text = square.ToString();
                querie();
            }
            else if (sign == '^')
            {
                val2 = textBox1.Text;
                textBox2.Text = $"{val1}^{val2}";
                long power = (long)Math.Pow(Convert.ToInt64(val1), Convert.ToInt64(val2));
                Ans = power;
                textBox1.Text = power.ToString();
                querie();
            }
            else if (sign == '`')
            {
                val1 = textBox1.Text;
                double degree = Convert.ToDouble(val1);
                double radian = degree * Pi / 180;
                Ans = Math.Sin(radian);
                textBox1.Text = Ans.ToString();
                textBox2.Text = $"Sin {val1}";
                querie();
            }
            else if (sign == 'c')
            {
                val1 = textBox1.Text;
                double degree = Convert.ToDouble(val1);
                double radian = degree * Pi / 180;
                Ans = Math.Cos(radian);
                textBox1.Text = Ans.ToString();
                textBox2.Text = $"Cos {val1}";
                querie();
            }
            else if (sign == 't')
            {
                val1 = textBox1.Text;
                double degree = Convert.ToDouble(val1);
                double radian = degree * Pi / 180;
                Ans = Math.Tan(radian);
                textBox1.Text = Ans.ToString();
                textBox2.Text = $"Tan {val1}";
                querie();
            }
            else if (sign == 'l')
            {
                val1 = textBox1.Text;
                double d = Convert.ToDouble(val1);
                Ans = Math.Log(d);
                textBox1.Text = Ans.ToString();
                textBox2.Text = $"Log({val1})";
                querie();
            }
            else if (sign == 'e')
            {
                val1 = textBox1.Text;
                double d = Convert.ToDouble(val1);
                Ans = Math.Exp(d);
                textBox1.Text = Ans.ToString();
                textBox2.Text = $"EXP({val1})";
                querie();
            }
            else if (sign == 'v')
            {
                float x = Convert.ToSingle(val1);
                if (x % 2 == 0)
                {
                    textBox1.Text = "Even";
                    textBox2.Text = $"{x} is Even";
                }
                else
                {
                    textBox1.Text = "Odd";
                    textBox2.Text = $"{x} is Odd";
                }
            }
            else if (sign == '+')
            {

                val2 = textBox1.Text;
                double x = Convert.ToDouble(val1) + Convert.ToDouble(val2);
                textBox1.Text = x.ToString();
                Ans = x;
                textBox2.Text = $"{val1}+{val2}";
                querie();
            }
            else if (sign == '-')
            {
                val2 = textBox1.Text;
                double x = Convert.ToDouble(val1) - Convert.ToDouble(val2);
                textBox1.Text = x.ToString();
                Ans = x;
                textBox2.Text = $"{val1}-{val2}";
                querie();
            }
            else if (sign == '*')
            {
                val2 = textBox1.Text;
                double x = Convert.ToDouble(val1) * Convert.ToDouble(val2);
                textBox1.Text = x.ToString();
                Ans = x;
                textBox2.Text = $"{val1}*{val2}";
                querie();
            }
            else if (sign == 'd')
            {
                val2 = textBox1.Text;
                double x = Convert.ToDouble(val1) / Convert.ToDouble(val2);
                textBox1.Text = x.ToString();
                Ans = x;
                textBox2.Text = $"{val1}÷{val2}";
                querie();
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            val1 = "";
            sign = '\0';
            textBox1.Focus();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "Hafiz Farhan & Saud";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            val1 = textBox1.Text;
            sign = '%';
            textBox1.Text = "";
            //textBox1.Text = $"{val1}%{val2}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            val1 = textBox1.Text;
            textBox1.Text = "";
            sign = 'P';
            textBox2.Text = $"{val1}P";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "√ ";
            sign = 's';
        }

        private void button27_Click(object sender, EventArgs e)
        {
            textBox1.Text = Ans.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            val1 = textBox1.Text;
            sign = '2';
            textBox2.Text = $"{val1}^2";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            val1 = textBox1.Text;
            textBox1.Text = "";
            sign = '^';
            textBox2.Text = $"{val1}^";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            val1 = textBox1.Text;
            sign = 'v';
            textBox2.Text = "Even/Odd";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = "EXP(";
            sign = 'e';
        }

        private void button9_Click(object sender, EventArgs e)
        {
            sign = '`';
            textBox2.Text = "Sin";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            sign = 'c';
            textBox2.Text = "Cos";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            sign = 't';
            textBox2.Text = "Tan";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sign = 'l';
            textBox2.Text = "Log(";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            sign = '+';
            val1 = textBox1.Text;
            textBox1.Text = "";
            textBox2.Text = $"{val1}+";
            textBox1.Focus();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            sign = '-';
            val1 = textBox1.Text;
            textBox1.Text = "";
            textBox2.Text = $"{val1}-";
            textBox1.Focus();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            sign = '*';
            val1 = textBox1.Text;
            textBox1.Text = "";
            textBox2.Text = $"{val1}*";
            textBox1.Focus();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            sign = 'd';
            val1 = textBox1.Text;
            textBox1.Text = "";
            textBox2.Text = $"{val1}÷";
            textBox1.Focus();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button30_Click(object sender, EventArgs e)
        {


        }

        private void button30_Click_1(object sender, EventArgs e)
        {
            val1 = textBox1.Text;
            textBox2.Text = "DEL.....";
            int x = Convert.ToInt32(val1);
            x = x / 10;
            textBox1.Text = x.ToString();
            
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 1)
            {
                textBox2.Text = "char = 1byte = 8bit";
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                textBox2.Text = "";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                textBox2.Text = "int = 4byte = 32bit";
            }
            else if(comboBox1.SelectedIndex == 3)
            {
                textBox2.Text = "double = 8byte = 64bit";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                textBox2.Text = "bool = 1byte = 8bit";
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                textBox2.Text = "float = 4byte = 32bit";
            }
        }
        private void querie()
        {
            //string address = "Data Source=DESKTOP-BTIF83O\\SQLEXPRESS;Initial Catalog=Calculator;Integrated Security=True";
            SqlConnection conn = new SqlConnection(address);

            conn.Open();

            string data = textBox1.Text;
            string query = "INSERT INTO Calculat(History) VALUES('" + @data + "')";

            SqlCommand cmdi = new SqlCommand(query, conn);
            cmdi.ExecuteNonQuery();
            conn.Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string x = dataGridView1.SelectedCells.ToString();
            
        }

        private void button31_KeyDown(object sender, KeyEventArgs e)
        {
            
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                equalbtn();
                textBox1.Focus();
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(address);
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT History FROM Calculat", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            textBox2.Text = "𝜋";
            sign = 'p';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            val1 = textBox1.Text;
            textBox1.Text = "";
            sign = 'C';
            textBox2.Text = $"{val1}C";
        }
    }
}
