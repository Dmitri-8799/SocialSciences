using SocialSciencesDecember2023.Resources.Styles;

namespace SocialSciencesDecember2023;

public partial class PropertiesPage : ContentPage
{
	StyleWinter styleWinter = new StyleWinter();

	public PropertiesPage()
	{
		ImageButton winterStyle = new ImageButton
		{
			Source = "winter.jpeg",
			BorderColor = Colors.Blue,
            BackgroundColor = Colors.Blue,
            
			Margin = 5
		};
		Content = winterStyle;
        winterStyle.Clicked += WinterStyle_Clicked;


        Button backToMenu = new Button()
        {
            Text = "назад",
            TextColor = Color.FromArgb("#9400D3"),
            BackgroundColor = Colors.Aquamarine
        };
        backToMenu.Clicked += OnBackToMenuClicked;

        Content = winterStyle;

	}

    private async void OnBackToMenuClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    static async void WinterStyle_Clicked(object sender, EventArgs e)
	{
          Style buttonWinter = new Style(typeof(Button))
        {
            Setters =
                {
                    new Setter
                    {
                        Property = Button.TextColorProperty,
                        Value = Color.FromArgb("#004D40")
                    },
                    new Setter
                    {
                        Property = Button.BackgroundColorProperty,
                        Value = Color.FromArgb("#80CBC4")
                    },
                    new Setter
                    {
                        Property = Button.MarginProperty,
                        Value = 10
                    }
                }
        };

        Style labelWinter = new Style(typeof(Label))
        {
            Setters =
                {
                    new Setter
                    {
                        Property = Label.TextColorProperty,
                        Value = Color.FromArgb("#004D40")
                    },
                    new Setter
                    {
                        Property = Label.BackgroundColorProperty,
                        Value = Color.FromArgb("#80CBC4")
                    },
                    new Setter
                    {
                        Property = Label.MarginProperty,
                        Value = 10
                    }
                }
        };

        Style backgroundWinter = new Style(typeof(Image))
        {
            Setters =
                {
                    new Setter
                    {
                        Property = Image.SourceProperty,
                        Value = "imagebckgd.jpeg"
                    },
                    new Setter
                    {
                        Property = Image.AspectProperty,
                        Value = Aspect.AspectFill
                    }
                    
                }
        };

        Style imageBtn = new Style(typeof(ImageButton))
        {
            Setters =
                {
                    new Setter
                    {
                        Property = ImageButton.SourceProperty,
                        Value = "imageBckgd.png"
                    }
                    

                }

        };
       

      

    }
}



