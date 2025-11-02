using Band_it.Modules;
using Band_it.Views;

namespace Band_it
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("browse", typeof(Browse_all));
            Routing.RegisterRoute("exercise", typeof(Current_exercise));
        }
    }
}
