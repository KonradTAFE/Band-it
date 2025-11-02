using Band_it.Modules;

namespace Band_it.Views;

public partial class Current_exercise : ContentPage
{
    
    public Current_exercise(Exercise exercise)
    {
        InitializeComponent();
        BindingContext = exercise;
        string instructions = "";
        foreach (string step in exercise.Description)
        {
            instructions += $"{step}\n";
        }
        Description.Text = instructions;

    }

    public void AddSets()
    {

    }

    public void SaveExerciseToWorkout(Exercise exercise)
    {
        string id = exercise.Id;

    }
}