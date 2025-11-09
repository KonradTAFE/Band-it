using System.Threading.Tasks;

namespace Band_it.Views;

public partial class Add_band : ContentPage
{
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
        color_picker.ItemsSource = colors;
	}

    private async void back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void save_Clicked(object sender, EventArgs e)
    {
        if (color_picker.SelectedItem != null)
        {
            int index = Preferences.Get("BandCount", 0);
            Preferences.Set("BandCount", index + 1);
            string color = color_picker.SelectedItem.ToString();
            int resistance = int.Parse(resistance_value.Text);
            Preferences.Set($"Band_{index}_Name", color);
            Preferences.Set($"Band_{index}_Resistance", resistance);
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