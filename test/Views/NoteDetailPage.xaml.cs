namespace test.Views;

public partial class NoteDetailPage : ContentPage
{
    public static BindableProperty EditorWidthProperty = BindableProperty.Create(
       nameof(EditorWidth),
       typeof(double),
       typeof(NoteDetailPage),
       null,
       BindingMode.OneWay);
    public double EditorWidth
    {
        get => (double)GetValue(EditorWidthProperty);
        set => SetValue(EditorWidthProperty, value);
    }
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            EditorWidth = width - 60d;
        }
        else
        {
            EditorWidth = width - 66d;

        }
    }
    public NoteDetailPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        AnimatePage();

        await Task.Delay(1000);
        EntryControl.Focus();
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
