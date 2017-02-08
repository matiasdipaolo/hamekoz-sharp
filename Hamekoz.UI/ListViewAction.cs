﻿//
//  ListViewAction.cs
//
//  Author:
//       Claudio Rodrigo Pereyra Diaz <claudiorodrigo@pereyradiaz.com.ar>
//
//  Copyright (c) 2016 Hamekoz - www.hamekoz.com.ar
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using Humanizer;
using Mono.Unix;
using Xwt;

namespace Hamekoz.UI
{
	/// <summary>
	/// List view with action to Add, Modify, Erase.
	/// </summary>
	public class ListViewAction<T> : HBox where T : new()
	{
		#region Properties

		public bool ActionsVisible {
			get { return actions.Visible; }
			set { actions.Visible = value; }
		}

		public bool Editable {
			get {
				return actions.Sensitive;
			}
			set {
				actions.Sensitive = value;
			}
		}

		public IList<T> List {
			get {
				return listView.List;
			}
			set {
				listView.List = value;
			}
		}

		public Type WidgetType {
			get;
			set;
		}

		#endregion

		readonly ListView<T> listView = new ListView<T> ();

		readonly VBox actions = new VBox ();

		readonly Button add = new Button {
			TooltipText = Catalog.GetString ("Add"),
			Image = Icons.ListAdd.WithSize (IconSize.Medium),
			ImagePosition = ContentPosition.Center
		};
		readonly Button edit = new Button {
			TooltipText = Catalog.GetString ("Edit"),
			Image = Icons.Edit.WithSize (IconSize.Medium),
			ImagePosition = ContentPosition.Center
		};
		readonly Button remove = new Button {
			TooltipText = Catalog.GetString ("Remove"),
			Image = Icons.Delete.WithSize (IconSize.Medium),
			ImagePosition = ContentPosition.Center
		};

		public ListViewAction ()
		{
			//TODO ver posibilidad de utilizar la misma instancia del Widget en lugar de instanciar uno nuevo
			//Para poder parametrizar el Widget con valores segun la necesidad
			add.Clicked += delegate {
				var dialogo = new Dialog {
					Title = string.Format (Catalog.GetString ("New {0}"), typeof(T).Name.Humanize ()),
				};

				dialogo.Buttons.Add (Command.Cancel, Command.Add);

				var item = new T ();
				var widget = (IItemUI<T>)Activator.CreateInstance (WidgetType);
				widget.Item = item;
				widget.ValuesRefresh ();
				widget.Editable (true);
				dialogo.Content = (Widget)widget;
				if (dialogo.Run () == Command.Add) {
					widget.ValuesTake ();
					if (Similarity (List, widget.Item))
						MessageDialog.ShowWarning (Catalog.GetString ("A similar element already exists in the list. Try to modify the existing one"));
					else {
						listView.Add (item);
						OnChanged ();	
					}
				}
				dialogo.Hide ();
			};

			edit.Clicked += delegate {
				var dialogo = new Dialog {
					Title = string.Format (Catalog.GetString ("Edit {0}"), typeof(T).Name.Humanize ()),
				};

				dialogo.Buttons.Add (Command.Cancel, Command.Apply);

				var row = listView.SelectedRow;
				if (row == -1) {
					MessageDialog.ShowMessage (string.Format (Catalog.GetString ("Select a {0} to edit"), typeof(T).Name.Humanize ()));
				} else {
					var widget = (IItemUI<T>)Activator.CreateInstance (WidgetType);
					widget.Item = listView.SelectedItem;
					widget.ValuesRefresh ();
					widget.Editable (true);
					dialogo.Content = (Widget)widget;
					if (dialogo.Run () == Command.Apply) {
						widget.ValuesTake ();
						if (Similarity (List, widget.Item))
							MessageDialog.ShowWarning (Catalog.GetString ("A similar element already exists in the list. Try to modify the existing one"));
						else {
							listView.FillRow (row, listView.SelectedItem);
							OnChanged ();
						}
					}
					dialogo.Hide ();
				}
			};

			remove.Clicked += delegate {
				var row = listView.SelectedRow;
				if (row == -1) {
					MessageDialog.ShowMessage (string.Format (Catalog.GetString ("Select a {0} to remove"), typeof(T).Name.Humanize ()));
				} else {
					//TODO revisar si tiene sentido pedir confirmación
					listView.Remove ();
					OnChanged ();
				}
			};

			actions.PackStart (add);
			actions.PackStart (edit);
			actions.PackStart (remove);
			PackStart (listView, true, true);
			PackEnd (actions, false, true);
		}

		public delegate bool SimilarityHandler (IList<T> list, T item);

		public SimilarityHandler OnSimilarity;

		protected bool Similarity (IList<T> list, T item)
		{
			var similarity = OnSimilarity;
			return similarity != null && similarity (list, item);
		}

		public void DisableRemove ()
		{
			remove.Sensitive = false;
		}

		public void RemoveColumnAt (int index)
		{
			listView.RemoveColumnAt (index);
		}

		public event EventHandler Changed;

		protected virtual void OnChanged ()
		{
			var handler = Changed;
			if (handler != null)
				handler (this, null);
		}
	}
}
