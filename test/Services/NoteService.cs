﻿using System;
namespace test.Services
{
    public class NoteService : INoteService
    {
        public List<Note> Notes { get; private set; } = new List<Note>
        {
            new Note{Index = 1, Icon = MaterialIcons.WebAsset, ColorHex = "#C299F5", Title = "Mastering Mindfulness", Description = "In this transformative workshop, we will delve into the art of mindfulness and learn powerful techniques to cultivate inner peace amidst the chaos of daily life. Mindfulness has become a popular practice in recent years due to its numerous benefits for mental, emotional, and physical well-being. Join us as we explore practical strategies to bring mindfulness into every aspect of your life." },
            new Note{Index = 2, Icon = MaterialIcons.Brush, ColorHex = "#90F97D", Title = "The Art of Creative Writing", Description = "Calling all aspiring writers and storytellers! Join us for an inspiring workshop that will ignite your creativity and empower you to become a masterful wordsmith. Whether you dream of writing novels, short stories, poetry, or even screenplays, this workshop is designed to help you unlock your writing potential and bring your ideas to life." },
            new Note{Index = 3, Icon = MaterialIcons.Payments, ColorHex = "#A8D8F3", Title = "Personal Finance", Description = "Take control of your financial destiny and pave the way towards a prosperous future with our comprehensive workshop on personal finance. Whether you're just starting your financial journey or looking to enhance your money management skills, this workshop will provide you with valuable insights and strategies to achieve financial success." },
            new Note{Index = 4, Icon = MaterialIcons.Psychology, ColorHex = "#FED390", Title = "Positive Psychology", Description = "Positive psychology is a scientific approach that focuses on understanding and nurturing positive aspects of human experiences such as joy, gratitude, resilience, and personal strengths. Join us as we delve into the principles and practical applications of positive psychology to create a more fulfilling and meaningful life."},
        };
        public bool AddNote(Note note)
        {
            note.Index = Notes.Count-1;
            Notes.Add(note);
            return true;
        }
        public bool RemoveNote(int index)
        {
            Note toRemove = Notes.Where(x => x.Index == index).FirstOrDefault();
            if (toRemove != null)
            {
                Notes.Remove(toRemove);
                return true;
            }
            return false;
        }
        public Note UpdateNote(Note note)
        {
            Note toUpdate = Notes.Where(x => x.Index == note.Index).FirstOrDefault();
            if (toUpdate != null)
            {
                int index = Notes.IndexOf(toUpdate);
                Notes.Remove(toUpdate);
                Notes.Insert(index, note);
                return note;
            }
            return null;
        }
        public IEnumerable<Note> GetNotes()
        {
            return Notes;
        }
    }
}

