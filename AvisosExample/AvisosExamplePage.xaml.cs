using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AvisosExample.Database;
using AvisosExample.Model;
using Xamarin.Forms;
namespace AvisosExample
{
    public partial class AvisosExamplePage : ContentPage
    {
        
		DBFire db = new DBFire();
		protected override async void OnAppearing()
		{
			base.OnAppearing();
			var list = await db.getRoomList();
			_lstx.BindingContext = list;
		}

		public AvisosExamplePage()
		{
			InitializeComponent();



		}

		async void Handle_Refreshing(object sender, System.EventArgs e)
		{
			_lstx.BindingContext = await db.getRoomList();
			_lstx.IsRefreshing = false;
		}





		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{


			if (_lstx.SelectedItem != null)
			{
				var selectRoom = (Avisos)_lstx.SelectedItem;

                Navigation.PushAsync(new AvisosExamplePage());




			}

		}
    }
}
