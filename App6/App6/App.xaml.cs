using PushNotification.Plugin;
using Rbauto.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Rbauto
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        protected override void OnStart()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                CrossPushNotification.Current.Register();
            }
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                BarBackgroundColor = Const.RbaBlueColor,
                Children =
                {
                    new NavigationPage(new NewsPage())
                    {
                        Title = "Новости",
                        Icon = Device.OnPlatform("tab_feed.png",null,null),
                        BarBackgroundColor = Const.RbaBlueColor
                    },
                    new NavigationPage(new ContactsPage())
                    {
                        Title = "Контакты",
                        Icon = Device.OnPlatform("tab_about.png",null,null),
                        BarBackgroundColor = Const.RbaBlueColor
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "О компании",
                        Icon = Device.OnPlatform("tab_feed.png",null,null),
                        BarBackgroundColor = Const.RbaBlueColor
                    },
                    new NavigationPage(new ManagerPage())
                    {
                        Title = "Менеджер",
                        Icon = Device.OnPlatform("tab_feed.png",null,null),
                        BarBackgroundColor = Const.RbaBlueColor
                    },                    //new NavigationPage(new WebViewDemoPage())
                    //{
                    //    Title = "Сайт"
                    //}
                }
            };
        }
    }
}
