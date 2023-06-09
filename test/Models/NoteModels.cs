using System;
namespace test.Models
{
	public class NoteModels
	{
		public NoteModels()
		{
		}
	}

	public enum NoteType
	{
		Personal,
		Fitness,
		Work
	}
	public class Note
	{
		public NoteType NoteType { get; set; }
		public int Index { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ColorHex { get; set; }
		public Color Color
		{
			get { return Color.FromArgb(ColorHex); }
			private set { }
		}
	}
}

