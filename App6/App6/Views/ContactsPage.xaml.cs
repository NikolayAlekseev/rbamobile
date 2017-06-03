
using System;
using Rbauto.Models;
using Rbauto.ViewModels;
using Xamarin.Forms;

namespace Rbauto.Views
{
    public partial class ContactsPage : ContentPage
    {
        ContactsViewModel viewModel;

        public ContactsPage()
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
