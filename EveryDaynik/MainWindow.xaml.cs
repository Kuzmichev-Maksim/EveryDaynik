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
            UpdateListTask();
            Calendare.SelectedDate = selectedDate;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            string title = NameNote.Text;
            string description = DescNote.Text;
            notes.CreateNotes(selectedDate, title, description);
            UpdateListTask();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            string title = NameNote.Text;
            string description = DescNote.Text;
            notes.EditNotes(selectedDate, title, description);
            UpdateListTask();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            notes.DeleteNotes(selectedId: notes.SelectedId);
            UpdateListTask();
        }

        private void Calendar(object sender, SelectionChangedEventArgs e)
        {
            notes.SelectedDate = Convert.ToDateTime(Calendare.Text);
            UpdateListTask();

        }
        public void UpdateListTask()
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
            DescNote.Text = "";
        }

        private void ListNoteSelected(object sender, SelectionChangedEventArgs e)
        {
            if (ListNotes.SelectedIndex != -1)
            {
                selectedDate = notes.SelectedDate;
                notes.SelectedId = ListNotes.SelectedIndex;
                Notes note = notes.TodayNotes[notes.SelectedId];
                NameNote.Text = note.name;
                DescNote.Text = note.description;
            }
        }
    }
}