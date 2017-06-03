using System;
using Rbauto.Models;
using Xamarin.Forms;

namespace Rbauto.Views
{
    public partial class NewItemPage : ContentPage
    {
        public ContactItem ContactItem { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            ContactItem = new ContactItem
            {
                Name = "ContactItem name",
                Phones = "This is a nice description"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", ContactItem);
            await Navigation.PopToRootAsync();
        }
    }
}