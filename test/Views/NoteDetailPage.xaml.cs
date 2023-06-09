namespace test.Views;

public partial class NoteDetailPage : ContentPage
{
	public NoteDetailPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        AnimatePage();
    }
    private void AnimatePage()
    {
        var pageAnimation = new Animation();

        //Your Note Label, and Add Note imagebutton Animation
        pageAnimation.Add(0, 1, new Animation(v => EntryControl.Opacity = v, 0, 1, Easing.Linear));
        pageAnimation.Add(0.2, 1, new Animation(v => LabelControl.Opacity = v, 0, 1, Easing.Linear));
        pageAnimation.Add(0.4, 1, new Animation(v => EditorControl.Opacity = v, 0, 1, Easing.Linear));

        pageAnimation.Add(0, 1, new Animation(v => EntryControl.TranslationX = v, 50, 0, Easing.Linear));
        pageAnimation.Add(0.2, 1, new Animation(v => LabelControl.TranslationX = v, 50, 0, Easing.Linear));
        pageAnimation.Add(0.4, 1, new Animation(v => EditorControl.TranslationX = v, 50, 0, Easing.Linear));

        
        //Commit the animation
        pageAnimation.Commit(this, "TransitionAnimation", 16, 1000, null,
        (v, c) =>
        {
            //Action to perform on completion (if any)
        });
    }
}
