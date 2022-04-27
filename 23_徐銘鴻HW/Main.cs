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
using _23_徐銘鴻HW.Properties;

namespace _23_徐銘鴻HW
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            LoadCategoriesToComboBox();
            
            //LoadAWToComboBox4();
           // LoadAWToComboBox5();

            
            listView1.View = View.Details;
            LoadNWToComboBox4();
            GetSchema();
        }

        private void GetSchema()
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();                    
                    SqlCommand com = new SqlCommand("select * from Customers", conn);
                    SqlDataReader dataReader = com.ExecuteReader();
                    DataTable dataTable = dataReader.GetSchemaTable();                    
                    for (int row = 0; row < dataTable.Rows.Count - 1; row++)
                    {
                        listView1.Columns.Add(dataTable.Rows[row][0].ToString());
                        //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadNWToComboBox4()
        {
            
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();                    
                    SqlCommand com = new SqlCommand("select distinct Country from Customers", conn);
                    SqlDataReader dataReader = com.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string s = $"{dataReader["Country"]}";
                        
                        comboBox4.Items.Add(s);
                    }
                    comboBox4.SelectedIndex =0;
                }
                //MessageBox.Show(conn.State.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadAWToComboBox5()
        {
            

        }

        private void LoadAWToComboBox4()
        {
            
        }

        private void LoadAWToComboBox3()
        {
            try
            {
                //連線至SQL並查詢
                using (SqlConnection conn = new SqlConnection(Settings.Default.AdventureWorks2019ConnectionString))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand("select Year(ModifiedDate) from Production.ProductPhoto group by Year(ModifiedDate) order by Year(ModifiedDate) asc", conn);
                    SqlDataReader dataReader = com.ExecuteReader();
                    int ccic = 0;
                    //每當讀取 執行
                    while (dataReader.Read())
                    {
                        ccic += 1;
                        string s = $"{dataReader[""]}";
                        comboBox3.Items.Add(s);
                        
                    }
                    comboBox3.SelectedIndex = 0;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }      

        //MainUI
        #region

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            LoadAWToComboBox3();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(6);
        }

        #endregion
        //tap1
        #region
        private void LoadCategoriesToComboBox()
        {
            try
            {
                //連線至SQL並查詢
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand("select CategoryName from Categories", conn);
                    SqlDataReader dataReader = com.ExecuteReader();
                    int ccic = 0;
                    //每當讀取 執行
                    while (dataReader.Read())
                    {
                        ccic += 1; 
                        string s = $"{dataReader["CategoryName"]}";
                        comboBox1.Items.Add(s);
                        comboBox2.Items.Add(ccic+"-"+s);
                    }
                    comboBox2.SelectedIndex = 0;
                    comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "select CategoryName,ProductID,UnitPrice,UnitsInStock " +
                        "from Products as p " +
                        "join Categories as c on p.CategoryID = c.CategoryID " +
                        "where CategoryName = "+"'"+comboBox1.Text+"'";
                    com.Connection = conn;
                    SqlDataReader dataReader = com.ExecuteReader();
                    lvCategories.Items.Clear();
                    string itemA = "";
                    while (dataReader.Read())
                    {
                        string s = $"{dataReader[0]}";
                        while (dataReader.Read())
                        {
                            itemA = $"{dataReader["CategoryName"],20} {dataReader["ProductID"],5}  {dataReader["UnitPrice"],10} {dataReader["UnitsInStock"],10}";
                            lvCategories.Items.Add(itemA);
                            lvCategories.Items.Add("\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "select CategoryName,ProductID,UnitPrice,UnitsInStock " +
                        "from Products as p " +
                        "join Categories as c on p.CategoryID = c.CategoryID " +
                        "where CategoryName = " + "'" + comboBox1.Text + "'";
                    com.Connection = conn;
                    SqlDataReader dataReader = com.ExecuteReader();
                    lvCategories.Items.Clear();
                    string itemA = "";
                    while (dataReader.Read())
                    {
                        string s = $"{dataReader[0]}";
                        while (dataReader.Read())
                        {
                            itemA = $"{dataReader["CategoryName"],20} {dataReader["ProductID"],5}  {dataReader["UnitPrice"],10} {dataReader["UnitsInStock"],10}";
                            lvCategories.Items.Add(itemA);
                            lvCategories.Items.Add("\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void productPhotoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productPhotoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetAW2019);

        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'dataSetAW2019.ProductPhoto' 資料表。您可以視需要進行移動或移除。
            this.productPhotoTableAdapter.FillAW(this.dataSetAW2019.ProductPhoto);

        }

        private void btndataset_Click(object sender, EventArgs e)
        {
            this.categoriesTableAdapter1.Fill(dataSetNW1.Categories);
            this.dataGridView1.DataSource = dataSetNW1.Categories;
            this.productsTableAdapter1.Fill(dataSetNW1.Products);
            this.dataGridView2.DataSource = dataSetNW1.Products;
            this.customersTableAdapter1.Fill(dataSetNW1.Customers);
            this.dataGridView3.DataSource = dataSetNW1.Customers;

            for (int i = 0; i <= dataSetNW1.Tables.Count - 1; i++)
            {
                DataTable dataTable = dataSetNW1.Tables[i];
                this.lbDataSet.Items.Add(dataTable.TableName);
                string tablecolumn = "";
                string tablerow = "";

                for (int column = 0; column <= dataTable.Columns.Count - 1; column++)
                {
                    tablecolumn += dataTable.Columns[column] + "    ";

                }
                lbDataSet.Items.Add(tablecolumn);

                for (int column = 0; column <= dataTable.Columns.Count - 1; column++)
                {
                    for (int row = 0; row <= dataTable.Rows.Count - 1; row++)
                    {
                        tablerow += (dataTable.Rows[row][column]);
                    }
                    lbDataSet.Items.Add(tablerow);
                    tablerow = "";
                    lbDataSet.Items.Add("\r");

                }

                lbDataSet.Items.Add("_________________________");
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ctName = Convert.ToString(comboBox4.SelectedItem);
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();

                    //MessageBox.Show("Open");
                    SqlCommand com = new SqlCommand();
                    //"select * from Customers where country='USA'", conn
                    com.CommandText = $"select * from Customers where country ='{comboBox4.Text}'";
                    com.Connection = conn;
                    SqlDataReader dataReader = com.ExecuteReader();
                    listView1.Items.Clear();
                    Random r = new Random();
                    while (dataReader.Read())
                    {
                        string s = $"{dataReader[0]}";

                        ListViewItem lvi = this.listView1.Items.Add(s);
                        lvi.ImageIndex = r.Next(0, this.ImageList1.Images.Count);
                        if (lvi.Index % 2 == 0)
                        {
                            lvi.BackColor = Color.Aqua;
                        }
                        else
                        {
                            lvi.BackColor = Color.BlueViolet;
                        }
                        for (int i = 1; i <= dataReader.FieldCount - 1; i++)
                        {
                            if (dataReader.IsDBNull(i))
                            {
                                lvi.SubItems.Add("Null");
                            }
                            else
                            {
                                lvi.SubItems.Add(dataReader[i].ToString());
                            }


                        }
                    }


                }
                //MessageBox.Show(conn.State.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
