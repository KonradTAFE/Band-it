using Band_it.Modules;
using Band_it.Services;

namespace Band_it.Views;
[QueryProperty(nameof(Exercise), "Exercise")]
public partial class Current_exercise : ContentPage
{
    private Exercise exercise;
    SetPreferences _preferences = new SetPreferences();


    public Exercise Exercise
    {
        get { return exercise; }
        set { exercise = value;
            Called();
        }
    }


    public Current_exercise()
    {
        InitializeComponent();
    }

    public void Called()
    {
        BindingContext = exercise;
        string instructions = "";
        foreach (string step in exercise.Description)
        {
            instructions += $"{step}\n\n";
        }
        Description.Text = instructions;
        ExerciseSets.ItemsSource = _preferences.GetDefault();
    }


    public void AddSets()
    {

    }

    public void SaveExerciseToWorkout(Exercise exercise)
    {
        string id = exercise.Id;

    }
}