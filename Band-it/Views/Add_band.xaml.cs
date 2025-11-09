using System.Threading.Tasks;
using Band_it.Services;

namespace Band_it.Views;

public partial class Add_band : ContentPage
{
    BandPreferences _preferences = new BandPreferences();
    List<string> colors = new List<string>()
    {
        "red",
        "orange",
        "brown",
        "black",
        "green",
        "yellow",
        "blue",
        "purple",
        "magenta",
        "pink",
        "cyan",

    };
    public Add_band()
	{
		InitializeComponent();
        color_picker.ItemsSource = getAvailableBands();
	}

    private async void back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void save_Clicked(object sender, EventArgs e)
    {
        if (color_picker.SelectedItem != null)
        {

            string color = color_picker.SelectedItem.ToString();
            int resistance = int.Parse(resistance_value.Text);
            _preferences.AddBand(color, resistance);
            await Shell.Current.GoToAsync("//settings");
        }
        else
        {
            await DisplayAlert("Error", "Please select a color and resistance", "OK");
        }

    }

    private List<string> getAvailableBands()
    {
        List<string> available = colors;
        for (int i = 0; i < Preferences.Get("BandCount", 0); i++)
        {
            string color = Preferences.Get($"Band_{i}_Name", "");
            available.Remove(color);
        }
        return available;
    }
}