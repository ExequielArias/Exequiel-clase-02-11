using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Exequiel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"
                        SELECT P.ProductID, P.ProductName, C.Description
                        FROM Product P
                        INNER JOIN Categories C ON P.CategoryID=C.CategoryID
                        ORDER BY P.ProductName
                        ";
            string cadena = "Data Source=perrito.db";
            SQLiteDataAdapter adaptador = new SQLiteDataAdapter(sql, cadena);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            //dataGridView1.DataSource = tabla;
            dataGridView1.Rows.Clear();
            foreach (DataRow fila in tabla.Rows)
            {
                dataGridView1.Rows.Add(fila["productID"], fila["ProductName"].ToString());
            }
        }
    }
    }
