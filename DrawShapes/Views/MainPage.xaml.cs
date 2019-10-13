using DrawShapes.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace DrawShapes.Views
{
    public sealed partial class MainPage
    {
        public MainPageViewModel ViewModel;
        public MainPage()
        {
            InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (ViewModel == null)
            {
                ViewModel =new MainPageViewModel();
            }
            DataContext = ViewModel;
        }
        private void MainCommandBar_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((CommandBar)sender).DefaultLabelPosition = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile" ? 
                                                        CommandBarDefaultLabelPosition.Bottom : 
                                                        CommandBarDefaultLabelPosition.Right;
        }
    }
}
