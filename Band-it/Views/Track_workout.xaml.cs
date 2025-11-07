using Band_it.Modules;

namespace Band_it.Views;

public partial class Track_workout : ContentPage
{
	List<Exercise> exercises = new List<Exercise>();

    public Track_workout()
	{
		InitializeComponent();
        tracking_exercises.ItemsSource = exercises;

    }

	protected async override void OnAppearing()
	{
		exercises.Clear();
	}

    private void saveWorkout_clicked(object sender, EventArgs e)
    {
        Workout workout = new Workout();
        workout.ID = 0;
        workout.WorkoutDate = DateTime.Now;
        foreach (Exercise exercise in exercises)
        {
            //workout.ExerciseList.Add({ exercise.Id, exercise.sets});

        }
    }

    private async void addExercise_clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//track/browse");
        //await Navigation.PushAsync(new Browse_all());
    }
}