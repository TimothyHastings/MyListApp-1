//
// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
// Written by Dr Tim Hastings.
//

using System;
using Xamarin.Forms;

namespace MyListApp
{
	/// <summary>
	/// Item page for updates and new items.
	/// </summary>
	public class ItemPage : ContentPage
	{
		Entry nameEntry = new Entry() { Placeholder = "Name"};
		Entry detailEntry = new Entry() { Placeholder = "Detail"};
		Image icon = new Image() { HeightRequest = 32, WidthRequest = 32 };
		Button saveButton = new Button() { Text = "Save"};

		Item _item = new Item();
		bool _isNew = false;

		public ItemPage(Item item, bool isNew)
		{
			Title = "Item";
			Padding = Helpers.GetPagePadding();
			_item = item;
			_isNew = isNew;

			nameEntry.Text = item.Name;
			detailEntry.Text = item.Detail;
			icon.Source = item.Icon.Source;

			Content = new StackLayout
			{
				Children = {
					nameEntry,
					detailEntry,
					icon,
					saveButton
				}
			};

			saveButton.Clicked += OnSaveClicked;
		}

		/// <summary>
		/// Save the item.
		/// </summary>
		/// <param name="o">O.</param>
		/// <param name="args">Arguments.</param>
		void OnSaveClicked(Object o, EventArgs args)
		{
			
			_item.Name = nameEntry.Text;
			_item.Detail = detailEntry.Text;
			_item.Icon.Source = "avatar.png";

			if (_isNew)
				Model.Add(_item);
			else
				Model.Update(_item);

			//	Go back
			Navigation.PopAsync();
		}
	}
}

