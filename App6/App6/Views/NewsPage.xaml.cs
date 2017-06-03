using System;
using Rbauto.Models;
using Rbauto.ViewModels;
using Xamarin.Forms;

namespace Rbauto.Views
{
    public partial class NewsPage : ContentPage
    {
        NewsViewModel viewModel;

        public NewsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new NewsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as NewsItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new NewsDetailPage(item));

            // Manually deselect contactItem
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
