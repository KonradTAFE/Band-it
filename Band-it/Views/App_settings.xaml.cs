using System.Collections.ObjectModel;
using Band_it.Modules;

namespace Band_it.Views;

public partial class App_settings : ContentPage
{
    private ObservableCollection<Band> _bands = new ObservableCollection<Band>();
    public App_settings()
    {
        InitializeComponent();
        LoadBands();
    }

    private void defaultExerciseSettings_clicked(object sender, EventArgs e)
    {

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadBands();
        bands_list.ItemsSource = _bands;

    }

    public void LoadBands()
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
            for (int i = 0; i < Preferences.Get("BandCount", 0); i++)
            {
                if (Preferences.Get($"Band_{i}_Name", "") == band.Color
                    && Preferences.Get($"Band_{i}_Resistance", 0) == band.Resistance)
                {
                    Preferences.Remove($"Band_{i}_Name");
                    Preferences.Remove($"Band_{i}_Resistance");
                }
            }
            _bands.Remove(band);
            SaveBands();
            
        }
        //bands_list.ItemsSource = _bands;


    }

    private async void addBand_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Add_band());
    }

    private void LoadDefaultBands()
    {
        List<Band> defaults = new List<Band>
        {
            new Band("red", 10),
            new Band("orange", 25),
            new Band("black", 40),
            new Band("purple", 55),
            new Band("green", 70)
        };

        foreach (Band band in defaults)
        {
            _bands.Add(band);
        }
        SaveBands();
    }
}