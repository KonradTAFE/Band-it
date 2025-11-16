using System.Collections.ObjectModel;
using Band_it.Modules;
using Band_it.Services;
using Band_it.Themes;

namespace Band_it.Views;

public partial class App_settings : ContentPage
{
    private ObservableCollection<Band> _bands = new ObservableCollection<Band>();
    private ObservableCollection<Set> _sets = new ObservableCollection<Set>();
    BandPreferences _bandPreferences = new BandPreferences();
    SetPreferences _setPreferences = new SetPreferences();
    public App_settings()
    {
        InitializeComponent();
        LoadBands();
    }

    private void defaultExerciseSettings_clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DefaultSets());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadBands();
        LoadSets();
        bands_list.ItemsSource = _bands;
        default_sets.ItemsSource = _sets;
    }

    public void LoadBands()
    {
        _bands.Clear();
        _bands = _bandPreferences.GetBands();
        if (_bands.Count == 0)
        {
            _bandPreferences.LoadDefaultBands();
        }
    }

    public void LoadSets()
    {
        _sets.Clear();
        _sets = _setPreferences.GetDefault();
    }

    private void addSet_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DefaultSets());
    }

    private void bin_clicked(object sender, EventArgs e)
    {
        if(sender is Button button && button.BindingContext is Band band)
        {
            _bands.Remove(band);
            _bandPreferences.SaveBands(_bands);
        }
    }

    private void setBin_clicked(object sender, EventArgs e)
    {
        if (_sets.Count > 0)
        {
            _sets.Remove(_sets.Last());
            _setPreferences.SaveDefaults(_sets);
        }
    }

    private async void addBand_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Add_band());
    }

    public void SwitchTheme_toggled(object sender, ToggledEventArgs e)
    {
        //Application.Current.Resources.MergedDictionaries.Clear();
        //if (e.Value)
        //{
        //    Application.Current.Resources.MergedDictionaries.Add(new LightMode());
        //}
        //else
        //{
        //    Application.Current.Resources.MergedDictionaries.Add(new DarkMode());
        //}
    }
}