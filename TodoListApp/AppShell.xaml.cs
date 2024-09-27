namespace TodoListApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //네비게이션
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        }
    }
}
