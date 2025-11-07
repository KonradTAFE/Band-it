using System.Threading.Tasks;
using Band_it.Services;
using Band_it.Modules;
using Band_it.Views;
using System.Collections.Generic;

namespace Band_it
{
    public partial class MainPage : ContentPage
    {        

        public MainPage()
        {
            InitializeComponent();
            int index = new Random().Next(quotes.Count - 1);
            quote_label.Text = quotes[index];
        }

        private async void Track_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//track");
            //await Navigation.PushAsync(new Track_workout());
        }


        List<string> quotes = new List<string>()
        {"The more knowledge you have, the more you're free to rely on your instincts",
            "If you want to turn a vision into reality, you have to give 100% and never stop believing in your dream",
            "You'll get more from being a peacemaker than a warrior.",
            "Dreams are for dreamers. Goals are for achievers.",
            "You can't climb the ladder of success with your hands in your pockets.",
            "Winners are not people who never fail, but people who never quit.",
            "I don't walk away from things that I think are unfinished.",
            "Help others and give something back.",
            "Have a vision, trust yourself, break some rules, ignore the naysayers, don't be afraid to fail.",
            "You were born to win, but to be a winner, you must plan to win, prepare to win, expect to win.",
            "Life may be full of pain but that's not an excuse to give up.",
            "The mind is the limit.",
            "Go confidently in the direction of your dreams. Live the life you've imagined.",
            "You can have results or excuses, but not both.",
            "If you don't find the time, if you don't do the work, you don't get the results.",
            "Positive thinking can be contagious. Being surrounded by winners helps you develop into a winner."
        };


    }
}
