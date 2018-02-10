//
// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
// Written by Dr Tim Hastings.
//

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyListApp
{
	/// <summary>
	/// The Model.
	/// </summary>
	public static class Model
	{
		/// <summary>
		/// The items are an observable source.
		/// </summary>
		public static ObservableCollection<Item> Items = new ObservableCollection<Item>();

		/// <summary>
		/// The next identifier.
		/// </summary>
		private static int nextID = 10;
		private static int GetNextID()
		{
			return nextID++;
		}

		/// <summary>
		/// Gets the data.
		/// </summary>
		public static void GetData()
		{
			for (int i = 0; i < 10; i++)
			{
				var item = new Item()
				{
					id = i,
					Name = "Name " + i.ToString(),
					Detail = "Detail " + i.ToString(),
				};
				item.Icon.Source = "avatar.png";

				Items.Add(item);
			}
		}

		/// <summary>
		/// Add the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		public static void Add(Item item)
		{
			item.id = GetNextID();
			Items.Add(item);
		}

		/// <summary>
		/// Update the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		public static void Update(Item item)
		{
			foreach (var i in Items)
			{
				if (i.id == item.id)
				{
					i.Name = item.Name;
					i.Detail = item.Detail;
					i.Icon = item.Icon;
				}
			}
		}

		/// <summary>
		/// Delete the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		public static void Delete(Item item)
		{
			Items.Remove(item);
		}
	}
}
