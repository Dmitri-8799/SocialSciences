namespace SocialSciencesEF2024.TableRb3;
using System.Windows;

public partial class TableRB3View : ContentPage
{
	public TableRB3View()
	{
		InitializeComponent();
        BindingContext = new MainViewModel();
    }

    void RadioButton_CheckedChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
    }
}
