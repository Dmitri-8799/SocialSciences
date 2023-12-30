using Microsoft.Maui.Controls;

namespace SocialSciencesDecember2023.Resources.Styles;

public partial class StyleWinter : ResourceDictionary
{
    public StyleWinter()
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
        

        

    }
   
}
