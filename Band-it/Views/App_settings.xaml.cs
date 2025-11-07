using Band_it.Modules;

namespace Band_it.Views;

public partial class App_settings : ContentPage
{
    private List<Band> _bands = new List<Band>();
    public App_settings()
    {
        InitializeComponent();
        bands_list.ItemsSource = _bands;


    }

    private void defaultExerciseSettings_clicked(object sender, EventArgs e)
    {

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadBands();
        
    }

    private void LoadBands()
    {
        _bands.Clear();

        int count = Preferences.Get("BandCount", 0);
        for (int i = 0; i < count; i++)
        {
            string color = Preferences.Get($"Band_{i}_Name", "");
            int resistance = Preferences.Get($"Band_{i}_Resistance", 0);
            if (color != "" && resistance > 0)
            {
                _bands.Add(new Band(color, resistance));
            }
        }

        if (_bands.Count == 0)
        {
            LoadDefaultBands();
        }
    }

    private void LoadDefaultBands()
    {
        List<Band> defaults = new List<Band>
        {
            new Band("Red", 10),
            new Band("Orange", 25),
            new Band("Black", 40),
            new Band("Purple", 55),
            new Band("Green", 70)
        };

        foreach (Band band in defaults)
        {
            _bands.Add(band);
        }
        SaveBands();
    }

    private void SaveBands()
    {
        Preferences.Set("BandCount", _bands.Count);
        for (int i = 0; i < _bands.Count; i++)
        {
            Preferences.Set($"Band_{i}_Name", _bands[i].Color);
            Preferences.Set($"Band_{i}_Resistance", _bands[i].Resistance);
        }
    }

    private void bin_clicked(object sender, EventArgs e)
    {
        if(sender is Button button && button.BindingContext is Band band)
        {
            _bands.Remove(band);
            SaveBands();
        }
    }

    private void addBand_Clicked(object sender, EventArgs e)
    {

    }
}