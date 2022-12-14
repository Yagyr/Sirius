using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SiriusTest
{

    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;

        private SqlCommandBuilder sqlCommandBuilder = null;

        private SqlDataAdapter sqlDataAdapter = null;

        private DataSet dataset = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mi\source\repos\SiriusTest\SiriusTest\Database1.mdf;Integrated Security=True");
            sqlConnection.Open();

            LoadData();

         }

        private void LoadData()
        {
            try
{
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' as [Delete] FROM personInfo AS Persons", sqlConnection);

                sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlCommandBuilder.GetInsertCommand();

                dataset = new DataSet();
                sqlDataAdapter.Fill(dataset, "Persons");

                dataGridView1.DataSource = dataset.Tables["Persons"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[9, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void ReloadData()
        {
            try
            {
                dataset.Tables["Persons"].Clear();

                sqlDataAdapter.Fill(dataset, "Persons");

                dataGridView1.DataSource = dataset.Tables["Persons"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[9, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                string task = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

                if (task == "Delete")
                {
                    //TODO Удаление
                }
                else if (task == "Insert")
                {
                    //TODO Создание
                }
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }
    }
}
