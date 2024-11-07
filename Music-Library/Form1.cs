using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Music_Library
{
    public partial class Form1 : Form
    {
        private List<(string Title, string Author, string Genre, int Year)> musicArray = new List<(string Title, string Author, string Genre, int Year)>();

        public Form1()
        {
            InitializeComponent();
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

            // Додаємо рядок до DataGridView та масиву
            dataGridView1.Rows.Add(title, author, genre, year);
            musicArray.Add((title, author, genre, year));

            // Очищення текстбоксів після додавання
            txtTitle.Clear();
            txtAuthor.Clear();
            txtGenre.Clear();
            txtYear.Clear();
        }

        private void AddDefaultTracks()
        {
            // Список треків за замовчуванням
            var defaultTracks = new[]
            {
                ("Track 1", "Artist A", "Rock", 2001),
                ("Track 2", "Artist B", "Pop", 2003),
                ("Track 3", "Artist C", "Jazz", 1999),
                ("Track 4", "Artist D", "Classical", 2010),
                ("Track 5", "Artist E", "Hip-hop", 2015)
            };

            foreach (var track in defaultTracks)
            {
                dataGridView1.Rows.Add(track.Item1, track.Item2, track.Item3, track.Item4);
                musicArray.Add(track);
            }
        }

        private void записатиУФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("music_library.txt"))
            {
                foreach (var track in musicArray)
                {
                    writer.WriteLine($"{track.Title},{track.Author},{track.Genre},{track.Year}");
                }
            }
            MessageBox.Show("Дані збережено у файл");
        }

        private void прочитатиЗФайлуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            musicArray.Clear();

            if (File.Exists("music_library.txt"))
            {
                using (StreamReader reader = new StreamReader("music_library.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 4 && int.TryParse(parts[3], out int year))
                        {
                            string title = parts[0];
                            string author = parts[1];
                            string genre = parts[2];
                            dataGridView1.Rows.Add(title, author, genre, year);
                            musicArray.Add((title, author, genre, year));
                        }
                    }
                }
                MessageBox.Show("Дані загружені");
            }
            else
            {
                MessageBox.Show("Файл не знайдено");
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

        private void очиститиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void аЯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сортування за назвою від А до Я
            dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void яАToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сортування за назвою від Я до А
            dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Descending);
        }

        private void рікToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сортування за роком зростанням
            dataGridView1.Sort(dataGridView1.Columns[3], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void вивестиЗаЗамовчуваннямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDefaultTracks();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
