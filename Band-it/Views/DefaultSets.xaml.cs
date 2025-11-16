using System.Collections.ObjectModel;
using Band_it.Modules;
using Band_it.Services;
namespace Band_it.Views;

public partial class DefaultSets : ContentPage
{
	SetPreferences _preferences = new SetPreferences();
	ObservableCollection<Set> _sets = new ObservableCollection<Set>();

	


    public DefaultSets()
	{
		InitializeComponent();
		_sets = _preferences.GetDefault();
        setId.Text = (_sets.Count + 1).ToString();
        band_picker.ItemsSource = ActiveColors();
        band_picker.SelectedIndex = 0;
    }



    private void save_defaults_Clicked(object sender, EventArgs e)
    {
		int id = int.Parse(setId.Text);
		int reps = int.Parse(repetitions.Text);
		string color = band_picker.SelectedItem.ToString();
		_sets.Add(new Set(id, reps, color));
        _preferences.SaveDefaults(_sets);
        Shell.Current.GoToAsync("//settings");
		
    }

    public List<string> ActiveColors()
    {
        BandPreferences bands = new BandPreferences();
        List<string> colors = new List<string>();
        ObservableCollection<Band> AllBands = bands.GetBands();
        foreach (Band band in AllBands)
        {
            colors.Add(band.Color);
        }
        return colors;
    }

}