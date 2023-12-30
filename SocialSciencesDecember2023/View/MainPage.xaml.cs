


namespace SocialSciencesDecember2023;

public partial class MainPage : ContentPage
{
	CarouselView PartI = new CarouselView();
	CarouselView PartII = new CarouselView();
	Button signInButton = new Button();

    public MainPage()
	{
		//сделать CarouselView для доступа к заданиям PartI и PartII


		//сделать кнопку для открытия окна регистрации:
		Button signInButton = new Button()
		{
			Text = "Войти",
            HorizontalOptions = LayoutOptions.Center,
        };
		signInButton.Clicked += OnSignInClicked;


	}

    private void OnSignInClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}

