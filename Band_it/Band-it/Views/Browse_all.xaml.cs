using Band_it.Services;

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
        All_exercises.ItemsSource = null;
        All_exercises.ItemsSource = await _service.GetExercises();
    }
}