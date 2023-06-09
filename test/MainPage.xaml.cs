
namespace test;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        AnimatePage();

    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        YourNote.Opacity = 0;
        YourNote.TranslationX = -150;
        AddNote.Opacity = 0;
        AddNote.TranslationX = 150;

        (NoteTypes.Children[0] as Button).TranslationX = 50;
        (NoteTypes.Children[0] as Button).Opacity = 0;

        foreach (var item in (NoteTypes.Children[1] as StackLayout).Children)
        {
            (item as Button).TranslationX = 50;
            (item as Button).Opacity = 0;
            count++;

            //Animate only the 
            if (count == 4)
            {
                break;
            }

        }
    }

    private void AnimatePage()
    {
        var pageAnimation = new Animation();

        //Your Note Label, and Add Note imagebutton Animation
        pageAnimation.Add(0.15, 0.6, new Animation(v => YourNote.Opacity = v, 0, 1, Easing.CubicIn));
        pageAnimation.Add(0.15, 0.6, new Animation(v => AddNote.Opacity = v, 0, 1, Easing.CubicIn));

        pageAnimation.Add(0, 0.6, new Animation(v => YourNote.TranslationX = v, -150, 0, Easing.CubicIn));
        pageAnimation.Add(0, 0.6, new Animation(v => AddNote.TranslationX = v, 150, 0, Easing.CubicIn));

        //Animate Collection of Note types
        double count = 0;
        pageAnimation.Add(0.2, 0.5, new Animation(v => (NoteTypes.Children[0] as Button).TranslationX = v, 50, 0, Easing.Linear));
        pageAnimation.Add(0.2, 0.5, new Animation(v => (NoteTypes.Children[0] as Button).Opacity = v, 0, 1, Easing.Linear));
        foreach (var item in (NoteTypes.Children[1] as StackLayout).Children)
        {
            pageAnimation.Add(0.2, 0.6 + count / 10, new Animation(v => (item as Button).TranslationX = v, 50, 0, Easing.Linear));
            pageAnimation.Add(0.2, 0.6 + count / 10, new Animation(v => (item as Button).Opacity = v, 0, 1, Easing.Linear));
            count++;

            //Animate only the 
            if (count == 4)
            {
                break;
            }

        }

        //Commit the animation
        pageAnimation.Commit(this, "TransitionAnimation", 16, 1500, null,
        (v, c) =>
        {
            //Action to perform on completion (if any)
        });
    }

    void LoginBtn_Clicked(System.Object sender, System.EventArgs e)
    {

    }
}


