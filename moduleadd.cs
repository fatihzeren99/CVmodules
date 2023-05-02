using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyDesktopApp
{
    public partial class MainForm : Form
    {
        private readonly string connectionString = "Data Source=(local);Initial Catalog=MyDatabase;Integrated Security=True";
        private SqlDataAdapter dataAdapter;
        private DataTable table;

        public MainForm()
        {
            InitializeComponent();

            table = new DataTable();
            dataGridView1.DataSource = table;

            GetData();
        }

        private void GetData()
        {
            dataAdapter = new SqlDataAdapter("SELECT * FROM Customers", connectionString);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
        }

        private void SaveData()
        {
            dataAdapter.Update(table);
        }
    }
}