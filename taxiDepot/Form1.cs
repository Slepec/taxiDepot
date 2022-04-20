using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taxiDepot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "taxiDepotDataSet6.Driver". При необходимости она может быть перемещена или удалена.
            this.driverTableAdapter.Fill(this.taxiDepotDataSet.Driver);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "taxiDepotDataSet5.Driver". При необходимости она может быть перемещена или удалена.

            // TODO: данная строка кода позволяет загрузить данные в таблицу "taxiDepotDataSet3.Trip". При необходимости она может быть перемещена или удалена.
            this.tripTableAdapter1.Fill(this.taxiDepotDataSet.Trip);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "taxiDepotDataSet2.Car". При необходимости она может быть перемещена или удалена.
            this.carTableAdapter.Fill(this.taxiDepotDataSet.Car);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "taxiDepotDataSet.Trip". При необходимости она может быть перемещена или удалена.
            this.tripTableAdapter.Fill(this.taxiDepotDataSet.Trip);
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            
                dataGridView1.AutoGenerateColumns = true;

                bindingSource1.DataSource = GetData("SELECT Trip.tripID, Driver.fullName, Car.name, distance FROM dbo.Trip join dbo.Car on Trip.carID=Car.carID join Driver on Driver.driverID=Trip.driverID");
                dataGridView1.DataSource = bindingSource1;
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        }
        static SqlDataAdapter adapter;
        private static DataTable GetData(string sqlCommand)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TaxiDepot.mdf;Integrated Security=True";

            SqlConnection northwindConnection = new SqlConnection(connectionString);
            Console.WriteLine(northwindConnection);
            SqlCommand command = new SqlCommand(sqlCommand, northwindConnection);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);

            return table;
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tripTableAdapter.FillBy(this.taxiDepotDataSet.Trip);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            driverTableAdapter.Update(taxiDepotDataSet);
            tripTableAdapter.Update(taxiDepotDataSet);
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }
    }
}
