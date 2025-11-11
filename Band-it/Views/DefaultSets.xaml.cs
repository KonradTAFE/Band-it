using System.Collections.ObjectModel;
using Band_it.Modules;
using Band_it.Services;
namespace Band_it.Views;

public partial class DefaultSets : ContentPage
{
	SetPreferences _preferences = new SetPreferences();
	BandPreferences _bandPreferences = new BandPreferences();
	ObservableCollection<Set> _sets = new ObservableCollection<Set>();
	List<string> colors = new List<string>();
	


    public DefaultSets()
	{
		InitializeComponent();
		_sets = _preferences.GetDefault();
		sets_list.ItemsSource = _sets;
		
    }

    private void addSet_Clicked(object sender, EventArgs e)
    {
		int index = _sets.Count + 1;
		int reps = 0;
		string color = null;
		_sets.Add(new Set(index, reps, null));
		_preferences.AddSet(index, reps, color);
    }

    private void save_defaults_Clicked(object sender, EventArgs e)
    {
		_preferences.SaveDefaults(_sets);
		Shell.Current.GoToAsync("//settings");
    }

    private void bin_clicked(object sender, EventArgs e)
    {
		if (_sets.Count > 0)
		{
			_sets.Remove(_sets.Last());
			_preferences.SaveDefaults(_sets);
		}
    }

	private List<string> GetColors()
	{
        
        ObservableCollection<Band> bands = _bandPreferences.GetBands();
		foreach(Band band in bands)
		{
            colors.Add(band.Color);
        }
		return colors;
    }

}