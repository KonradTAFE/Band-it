using Band_it.Modules;

namespace Band_it.Views;

public partial class App_settings : ContentPage
{
    public App_settings()
    {



        //for(int i = 0; i < bands.Count; i++)
        //{
        //	Band new_band = new Band();
        //	new_band.Color = Preferences.Get($"band{i}color", "");
        //	new_band.Resistance = Preferences.Get($"band{i}resistance", -1);
        //	if (new_band.Color != "" && new_band.Resistance != -1)
        //	{
        //		bands.Add(new_band);
        //	}
        //}
        InitializeComponent();



    }

    private void defaultExerciseSettings_clicked(object sender, EventArgs e)
    {

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        List<Band> bands = new List<Band>
        {
            new Band("Red", 10),
            new Band("Orange", 25),
            new Band("Black", 40),
            new Band("Purple", 55),
            new Band("Green", 70)
        };

        bands_list.ItemsSource = bands;
        
    }
}