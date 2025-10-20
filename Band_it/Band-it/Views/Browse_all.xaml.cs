using Band_it.Services;
using Band_it.Modules;


namespace Band_it.Views;

public partial class Browse_all : ContentPage
{
    ApiService _service = new ApiService();

    public Browse_all()
	{
		InitializeComponent();

    }

    protected override async void OnAppearing()
    {
        List<string> muscles = new List<string>();
        All_exercises.ItemsSource = null;
        All_exercises.ItemsSource = await _service.GetAllExercises();
        muscles.Add("all");
        foreach(Exercise exercise in All_exercises.ItemsSource)
        {
            if (muscles.Contains(exercise.PrimaryMuscle[0])){
                continue;
            }
            else
            {
                muscles.Add(exercise.PrimaryMuscle[0]);
            }
        }
        MusclePicker.ItemsSource = muscles;
    }

    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        string name = Searchbar.Text;
        All_exercises.ItemsSource = null;
        All_exercises.ItemsSource = await _service.SearchByName(name);
    }

    private async void MusclePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        string muscle = (string)MusclePicker.SelectedItem;
        if (muscle == "all")
        {
            All_exercises.ItemsSource = null;
            All_exercises.ItemsSource = await _service.GetAllExercises();
        }
        else
        {
            All_exercises.ItemsSource = null;
            All_exercises.ItemsSource = await _service.SearchByMuscle(muscle);
        }
    }
}