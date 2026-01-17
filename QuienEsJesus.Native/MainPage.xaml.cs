namespace QuienEsJesus.Native
{
    public partial class MainPage : ContentPage
    {

        private const string BlazorAppUrl = "https://localhost:7066";

        public MainPage()
        {
            InitializeComponent();
            blazorWebView.Source = BlazorAppUrl;
        }
    }
}
