//
// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
// Written by Dr Tim Hastings.
//

using Xamarin.Forms;

namespace MyListApp
{
	/// <summary>
	/// My list page.
	/// </summary>
	public class MyListPage : ContentPage
	{
		ToolbarItem addTBI = new ToolbarItem()
		{
			Text = "Add",
			Icon = "",
			Order = ToolbarItemOrder.Primary,
		};

		ListView listView = new ListView();

		/// <summary>
		/// Refresh the list.
		/// </summary>
		private void Refresh()
		{
			if (listView == null)
				return;

			//	Force a listview refresh.
			if (listView.SelectedItem != null)
				listView.SelectedItem = null;
			listView.ItemsSource = null;
			listView.ItemsSource = Model.Items;
		}

		public MyListPage()
		{
			Title = "My List";
			Padding = Helpers.GetPagePadding();

			//	Set up a template
			listView.ItemsSource = Model.Items;
			listView.ItemTemplate = new DataTemplate(typeof(ImageListCell));

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = {
						listView,
					}
			};

			Model.GetData();
			Refresh();

			// Events
			addTBI.Command = new Command(() => OnAddTBI());
			ToolbarItems.Add(addTBI);
			listView.ItemSelected += OnItemSelected;
		}

		/// <summary>
		/// On the item selected.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		async private void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			//	Stop false events.
			if (args.SelectedItem == null)
				return;

			//	Get the list item 
			var item = (Item)args.SelectedItem;

			var action = await DisplayActionSheet(item.Name, "Cancel", "Delete", "Update");
			switch (action)
			{
				case "Cancel":
					break;
				case "Delete":
					Model.Delete(item);
					break;
				case "Update":
					await Navigation.PushAsync(new ItemPage(item, false));
					break;
				default:
					break;
			}

			//	Deselect if you like
			listView.SelectedItem = null;
		}

		/// <summary>
		/// Add a new Item.
		/// </summary>
		private void OnAddTBI()
		{
			Navigation.PushAsync(new ItemPage(new Item(), true));
		}

		// Good practice
		protected override void OnAppearing()
		{
			base.OnAppearing();
			Refresh();
		}
	}
}

