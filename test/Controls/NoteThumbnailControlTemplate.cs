using System;

namespace test.Controls
{
	public class NoteThumbnailControlTemplate:ContentView
	{
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(NoteThumbnailControlTemplate), string.Empty);
        public static readonly BindableProperty ColProperty = BindableProperty.Create(nameof(Col), typeof(int), typeof(NoteThumbnailControlTemplate), 0);

        public static readonly BindableProperty NoteProperty = BindableProperty.Create(
            nameof(Note), typeof(Note), typeof(NoteThumbnailControlTemplate), null);
        public static readonly BindableProperty NoteArrProperty = BindableProperty.Create(
            nameof(NoteArr), typeof(Note[]), typeof(NoteThumbnailControlTemplate), null,BindingMode.OneWay,propertyChanged: OnNoteArrChanged);
        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string), typeof(NoteThumbnailControlTemplate), string.Empty);
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(NoteThumbnailControlTemplate), Colors.Aqua);

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public int Col
        {
            get => (int)GetValue(ColProperty);
            set => SetValue(ColProperty, value);
        }
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public Note Note
        {
            get => (Note)GetValue(NoteProperty);
            set => SetValue(NoteProperty, value);
        }

        public Note[] NoteArr
        {
            get =>(Note[])GetValue(NoteArrProperty);
            set => SetValue(NoteArrProperty, value);
        }

        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        private static void OnNoteArrChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable != null && bindable is NoteThumbnailControlTemplate entity && newValue != null && ((Note[])newValue).Length > entity.Col)
            {
                var noteArr = (Note[])newValue;
                entity.Title = noteArr[entity.Col].Title;
                entity.Description = noteArr[entity.Col].Description;
                entity.Color = noteArr[entity.Col].Color;
                entity.Note = noteArr.ElementAt(entity.Col);
            }
        }
    }
}

