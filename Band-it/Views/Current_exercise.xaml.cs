using Band_it.Modules;

namespace Band_it.Views;
[QueryProperty(nameof(Exercise), "Exercise")]
public partial class Current_exercise : ContentPage
{
    private Exercise exercise;
    private Set set1 = new Set()
    {
        Id = 1,
        Reps = 12,
        Color = Preferences.Get("set1", "red")
    };

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
    }
   


    public void AddSets()
    {

    }

    public void SaveExerciseToWorkout(Exercise exercise)
    {
        string id = exercise.Id;

    }
}