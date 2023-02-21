using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace EveryDaynik
{
    public class Notes
    {
        public int id;
        public string name;
        public string description;
        public DateTime date = DateTime.Today;
        public Notes(int id, string name, string description, DateTime date)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.date = date;
        }
    }
    public class Datenotes
    {
        public List<Notes> TodayNotes;
        public List<Notes> AllNotes;
        public DateTime SelectedDate;
        public int SelectedId = -1;

        public Datenotes(DateTime date)
        {
            TodayNotes = DS.Deserialize<Notes>(date);
            AllNotes = DS.Deserialize<Notes>(default);
            SelectedDate = date;
        }
        public void CreateNotes(DateTime date, string title, string description)
        {
            Notes note = new Notes(AllNotes.Count, title, description, SelectedDate);
            AllNotes.Add(note);
            DS.Serialize<Notes>(AllNotes);
            ReadNotes();
        }
        public void DeleteNotes(int selectedId = -1, int id = -1)
        {
            if (selectedId != -1)
            {
                id = TodayNotes[selectedId].id;
            }
            List<Notes> notes = new List<Notes>();
            foreach (Notes note in AllNotes)
            {
                if (note.id != id)
                {
                    notes.Add(note);
                }
            }
            AllNotes = notes;
            ReadNotes();
            ReloadNotes();
        }
        public void ReadNotes(){TodayNotes = DS.Deserialize<Notes>(SelectedDate);}
        public void ReloadNotes(){DS.Serialize<Notes>(AllNotes);}
        public void EditNotes(DateTime date, string title, string description)
        {
            if (SelectedId != -1)
            {
                Notes note = new Notes(TodayNotes[SelectedId].id, title, description, SelectedDate);
                DeleteNotes(TodayNotes[SelectedId].id);
                AllNotes.Add(note);
                ReloadNotes();
                ReloadNotes();
                SelectedId = -1;
            }
        }
        public void Window(DateTime date = default)
        {
            List<Notes> notes = new List<Notes>();
            foreach (Notes note in AllNotes)
            {
                if (note.date == date) notes.Add(note);
            }
        }
    }
    public class DS
    {
        public static List<T> Deserialize<T>(DateTime date = default)
        {
            try
            {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                List<T> notes = new();
                List<T> json = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(desktop + "\\Notes.json"));
                foreach (T note in json)
                {
                    notes.Add(note);
                }
                return notes;
            }
            catch
            {
                List<T> notes = new();
                File.WriteAllText("Notes.json", JsonConvert.SerializeObject(notes));
                return notes;
            }
        }
        public static List<T> Serialize<T>(List<T> notes)
        {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string json = JsonConvert.SerializeObject(notes);
                File.WriteAllText(desktop + "\\Notes.json", json);
                return notes;
        }
    }
}