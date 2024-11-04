using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music_Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Title";
            dataGridView1.Columns[1].Name = "Author";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();

            // Перевірка, що поля не порожні
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
            {
                MessageBox.Show("Please enter both Title and Author.");
                return;
            }

            // Додаємо рядок до DataGridView
            dataGridView1.Rows.Add(title, author);

            // Очищення текстбоксів після додавання
            txtTitle.Clear();
            txtAuthor.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
