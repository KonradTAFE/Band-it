using System.Threading.Tasks;
using Band_it.Services;
using Band_it.Modules;
using Band_it.Views;

namespace Band_it
{
    public partial class MainPage : ContentPage
    {
        ApiService _service = new ApiService();
        QuotesAPI _quotesAPI = new QuotesAPI();


        public MainPage()
        {
            InitializeComponent();
        }

        private void Track_Clicked(object sender, EventArgs e)
        {
            
        }

        private void History_Clicked(object sender, EventArgs e)
        {

        }

        private async void All_Exercise_Clicked(object sender, EventArgs e)
        {
            Browse_all _All = new Browse_all();
            await Navigation.PushModalAsync(_All);

        }
        private void Settings_Clicked(object sender, EventArgs e)
        {

        }

        private void Profile_Clicked(object sender, EventArgs e)
        {

        }

        private async void About_Clicked(object sender, EventArgs e)
        {
            //List<string> quotes = await _quotesAPI.GetQuotes();
            //quotesList.ItemsSource = quotes;
        }

    }
}
