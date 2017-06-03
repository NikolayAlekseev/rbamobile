using System;
using Rbauto.Models;
using Rbauto.ViewModels;
using Xamarin.Forms;

namespace Rbauto.Views
{
    public partial class ItemsPage : ContentPage
    {
        ContactsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ContactsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ContactItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new ContactDetailPage(new ContactDetailViewModel(item)));

            // Manually deselect contactItem
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
