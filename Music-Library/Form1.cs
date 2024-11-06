using System;
using System.Linq;
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
           
        }

        private void AddDefaultTracks()
        {
            // Список треків за замовчуванням
            var defaultTracks = new[]
            {
                new { Name = "Track 1", Author = "Artist A", Genre = "Rock", Year = 2001 },
                new { Name = "Track 2", Author = "Artist B", Genre = "Pop", Year = 2003 },
                new { Name = "Track 3", Author = "Artist C", Genre = "Jazz", Year = 1999 },
                new { Name = "Track 4", Author = "Artist D", Genre = "Classical", Year = 2010 },
                new { Name = "Track 5", Author = "Artist E", Genre = "Hip-hop", Year = 2015 }
            };

            // Додавання треків до DataGridView
            foreach (var track in defaultTracks)
            {
                dataGridView1.Rows.Add(track.Name, track.Author, track.Genre, track.Year);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string genre = txtGenre.Text.Trim();
            string yearText = txtYear.Text.Trim();

            // Перевірка, що всі поля заповнені
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) ||
                string.IsNullOrEmpty(genre) || string.IsNullOrEmpty(yearText))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля: Назва, Виконавець, Жанр, Рік.");
                return;
            }

            // Перевірка, що рік є числом
            if (!int.TryParse(yearText, out int year))
            {
                MessageBox.Show("Будь ласка, введіть коректний рік.");
                return;
            }

            // Додаємо рядок до DataGridView
            dataGridView1.Rows.Add(title, author, genre, year);

            // Очищення текстбоксів після додавання
            txtTitle.Clear();
            txtAuthor.Clear();
            txtGenre.Clear();
            txtYear.Clear();
        }

        private void очиститиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void аЯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сортування за назвою від А до Я
            dataGridView1.Sort(dataGridView1.Columns["Name"], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void яАToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сортування за назвою від Я до А
            dataGridView1.Sort(dataGridView1.Columns["Name"], System.ComponentModel.ListSortDirection.Descending);
        }

        private void рікToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сортування за роком зростанням
            dataGridView1.Sort(dataGridView1.Columns["Year"], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void вивестиЗаЗамовчуваннямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDefaultTracks();
        }

      
    }
}
