using System.Collections.ObjectModel;
using Band_it.Modules;
using Band_it.Services;

namespace Band_it.Views;

public partial class App_settings : ContentPage
{
    private ObservableCollection<Band> _bands = new ObservableCollection<Band>();
    BandPreferences _preferences = new BandPreferences();
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
        _bands = _preferences.GetBands();
        if (_bands.Count == 0)
        {
            _preferences.LoadDefaultBands();
        }
    }

    private void bin_clicked(object sender, EventArgs e)
    {
        if(sender is Button button && button.BindingContext is Band band)
        {
            _bands.Remove(band);
            _preferences.SaveBands(_bands);
        }
    }

    private async void addBand_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Add_band());
    }

}