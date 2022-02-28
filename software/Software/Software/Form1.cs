using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Software
{
    public partial class Form1 : Form
    {
        SqlConnection sqlCon = new SqlConnection (@"Data Source=(LocalDB)\MSSQLLocalDB; Initial Catalog = DB_Software; Integrated Security=True;");

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoad1_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Software", sqlCon);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);

            dataGridView1.DataSource = dtbl;
            sqlCon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                if (button1.Text == "Save")
                {
                    SqlCommand sqlCmd = new SqlCommand("AddData", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Add");
                    sqlCmd.Parameters.AddWithValue("@ID", 0);
                    sqlCmd.Parameters.AddWithValue("@Name", textBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Provider", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Version", numericUpDown2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@ReleaseDate", dateTimePicker1.Value.ToString());
                    sqlCmd.Parameters.AddWithValue("@LicenseID", numericUpDown1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@License", textBox6.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Saved successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("DeleteData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", numericUpDown3.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                if (button3.Text == "Edit")
                {
                    SqlCommand sqlCmd = new SqlCommand("AddData", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                    sqlCmd.Parameters.AddWithValue("@ID", numericUpDown3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Name", textBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Provider", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Version", numericUpDown2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@ReleaseDate", dateTimePicker1.Value.ToString());
                    sqlCmd.Parameters.AddWithValue("@LicenseID", numericUpDown1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@License", textBox6.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Saved successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
