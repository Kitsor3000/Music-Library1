
﻿using System;
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



        private void вивестиЗаЗамовчуваннямToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddDefaultTracks();

        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
