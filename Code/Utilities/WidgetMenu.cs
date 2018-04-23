using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Threading;
using System.Numerics;
using ProjectPlannerApp.Code.Utilities;

namespace ProjectPlannerApp.Code.Utilities
{
	class WidgetMenu
	{
		private readonly ProjectPlannerTouchListener touchListener;
		private readonly Context context;
		private LayoutInflater _layoutInflater;
		private View _popUp;
		private readonly string[] _widgets = new string[4];
		private MenuAdapter _arrayAdapter;
		private ListView _listView;
		private TextView _menuItem;
		private AlertDialog dialog;


		public RelativeLayout BackgroundLayout { get; set; }

		public WidgetMenu(ProjectPlannerTouchListener touchListener, Context context )
		{
			if (touchListener == null)
				throw new InvalidOperationException("Touch listener is null");
			this.touchListener = touchListener;

			this.context = context;
			_layoutInflater = LayoutInflater.From(context);

			PopulateWidgets();

		}

		void PopulateWidgets()
		{
			_widgets[0] = "People";
			_widgets[1] = "Item2";
			_widgets[2] = "Item3";
			_widgets[3] = "Item4";
		}

		public void PopUp()
		{
			if (_popUp == null)
			{
				AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(context);
				_popUp = _layoutInflater.Inflate(Resource.Layout.popuplayout,null);
				PopulateListView();
				dialogBuilder.SetView(_popUp);
				dialog = dialogBuilder.Create();
				dialog.Show();
				dialog.Window.SetLayout(500, 475);

			} else
			{
				_popUp.Visibility = ViewStates.Visible;
			}
			
			
			if (_popUp == null)
				throw new InvalidOperationException("view menu is null");

		}

		void PopulateListView()
		{
			_arrayAdapter = new MenuAdapter(context,  Resource.Layout.widgettextview,_widgets);
			
			_listView = _popUp.FindViewById<ListView>(Resource.Id.widgetSelector);
			_menuItem = _popUp.FindViewById<TextView>(Resource.Id.widgetTextView);
			

			_listView.Adapter =_arrayAdapter;
			_listView.ItemClick += SelectItem;

		
		}

		void SelectItem(object o, AdapterView.ItemClickEventArgs itemEventArgs)
		{

			var itemSelected = (TextView) _arrayAdapter.GetViewItem(itemEventArgs.Position).
				GetTag(Resource.Id.widgetTextView);
			itemSelected.SetBackgroundColor(Android.Graphics.Color.Green);
			dialog.Dismiss();
			
			switch (itemEventArgs.Position) {
				
				case 0:
					//create people widget
					var dialog = new Dialog(context);
					var widgetDeleteDialog = new WidgetDeleteDialog(dialog);
					var projWidget = new ProjectWidget(context,new Vector2(touchListener.X, 
						touchListener.Y),Resource.Layout.widgetview, BackgroundLayout,
						PeopleWidget.GetColor());
					var peopleWidget = new PeopleWidget(projWidget, new PeopleWidgetPopUp(context),
						widgetDeleteDialog);
					break;
				case 1:
					//create travel widget

					break;
			}
		}

		


	}
}