using Rbauto.Models;
using Xamarin.Forms;

namespace Rbauto.Views
{
    public class NewsDetailPage : ContentPage
    {
        public NewsDetailPage(NewsItem news)
        {
            Title = news.Name;

            StackLayout layout = new StackLayout()
            {
                Padding = new Thickness(10)
            };

            /* Дата */
            layout.Children.Add(
                new Label
                {
                    Text = news.NewsDate,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    TextColor = Color.Silver
                });

            /* Заголовок */
            layout.Children.Add(
                new Label
                {
                    Text = news.Name,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                });

            /* Главный рисунок */
            if (!string.IsNullOrEmpty(news.MainImageUrl))
            {
                layout.Children.Add(
                    new Image()
                    {
                        Source = news.MainImageUrl,
                        HeightRequest = news.MainImageHeight
                    });
            }

            /* Строки */
            foreach (var row in news.Rows)
            {
                layout.Children.Add(
                    new Label
                    {
                        Text = row,
                        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
                    });
            }

            /* Дополнительные рисунки */
            foreach (var image in news.AdditionalImagesUrl)
            {
                layout.Children.Add(
                    new Image()
                    {
                        Source = image,
                        HeightRequest = 150
                    });
            }

            this.Content = new ScrollView()
            {
                Content = layout
            };
        }
    }
}
