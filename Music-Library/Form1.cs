using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Music_Library
{
    public partial class Form1 : Form
    {
        private List<(string Title, string Author, string Genre, int Year)> musicArray = new List<(string Title, string Author, string Genre, int Year)>();


        public Form1()
        {
            InitializeComponent();
        }





        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }


        private void записатиУФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("music_library.txt"))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string title = row.Cells[0].Value?.ToString() ?? "";
                        string author = row.Cells[1].Value?.ToString() ?? "";
                        writer.WriteLine($"{title},{author}");
                    }
                }
            }

            MessageBox.Show("Дані збережено у файл");
        }

        private void прочитатиЗФайлуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            if (File.Exists("music_library.txt"))
            {
                using (StreamReader reader = new StreamReader("music_library.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            string title = parts[0];
                            string author = parts[1];
                            dataGridView1.Rows.Add(title, author);
                        }
                    }
                }

                MessageBox.Show("Дані загружені");
            }
            else
            {
                MessageBox.Show("Файл не знайдено(");
            }
        }

        private void прочитатиЗМасивууToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();


            if (musicArray.Count == 0)
            {
                MessageBox.Show("Масив пустий");
                return;
            }

            foreach (var item in musicArray)
            {
                dataGridView1.Rows.Add(item.Title, item.Author, item.Genre, item.Year);
            }

        }


        private void очиститиМасивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musicArray.Clear();

            MessageBox.Show("Масив очищено");
        }
    }
}
