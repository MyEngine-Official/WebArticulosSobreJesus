namespace QuienEsJesus.Maui
{
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// The URL of the Blazor WebAssembly app to display.
        /// For development, use the localhost URL (e.g., "https://localhost:5000").
        /// For production, replace with the deployed web app URL.
        /// </summary>
        private const string BlazorAppUrl = "https://localhost:5000";

        public MainPage()
        {
            InitializeComponent();
            blazorWebView.Source = BlazorAppUrl;
        }
    }
}
