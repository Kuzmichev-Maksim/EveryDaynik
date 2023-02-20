using EveryDaynik;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace EveryDaynik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Datenotes notes;
        public static DateTime selectedDate = DateTime.Today;
        public MainWindow()
        {
            InitializeComponent();
            notes = new Datenotes(selectedDate);
            UpdateListDel();
            Calendare.SelectedDate = selectedDate;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string title = NameNote.Text;
            string description = DescriptionNote.Text;
            notes.CreateNotes(selectedDate, title, description);
            UpdateListDel();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string title = NameNote.Text;
            string description = DescriptionNote.Text;
            notes.EditNotes(selectedDate, title, description);
            UpdateListDel();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            notes.DeleteNotes(selectedId: notes.SelectedId);
            UpdateListDel();
        }

        private void Calendare_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            notes.SelectedDate = Convert.ToDateTime(Calendare.Text);
            UpdateListDel();

        }
        public void UpdateListDel()
        {
            selectedDate = notes.SelectedDate;
            notes.ReadNotes();
            ListNotes.Items.Clear();
            foreach (Notes note in notes.TodayNotes)
            {
                if (note.date == selectedDate)
                {
                    ListNotes.Items.Add(note.name);
                    notes.Window(selectedDate);
                }
            }
            NameNote.Text = "";
            DescriptionNote.Text = "";
        }

        private void ListNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListNotes.SelectedIndex != -1)
            {
                selectedDate = notes.SelectedDate;
                notes.SelectedId = ListNotes.SelectedIndex;
                Notes note = notes.TodayNotes[notes.SelectedId];
                NameNote.Text = note.name;
                DescriptionNote.Text = note.description;
            }
        }
    }
}