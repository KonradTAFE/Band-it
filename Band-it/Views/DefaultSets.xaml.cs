using System.Collections.ObjectModel;
using Band_it.Modules;
using Band_it.Services;
namespace Band_it.Views;

public partial class DefaultSets : ContentPage
{
	ObservableCollection<Set> sets = new ObservableCollection<Set>()
	{
		new Set(1,10, null),
		new Set(2, 10, null)

	};

	public DefaultSets()
	{
		InitializeComponent();
		sets_list.ItemsSource = sets;

    }

    private void addSet_Clicked(object sender, EventArgs e)
    {
		int index = sets.Count + 1;
		int reps = 0;
		Band band = null;
		sets.Add(new Set(index, reps, null));

    }


}