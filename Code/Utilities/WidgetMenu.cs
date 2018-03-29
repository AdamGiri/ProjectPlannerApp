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


		public RelativeLayout BackgroundLayout { get; set; }

		public WidgetMenu(ProjectPlannerApp.Code.Utilities.
			ProjectPlannerTouchListener touchListener, Context context )
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
				_popUp = _layoutInflater.Inflate(Resource.Layout.popuplayout, BackgroundLayout);
				PopulateListView();
			} else
			{
				_popUp.Visibility = ViewStates.Visible;
			}
			
			
			if (_popUp == null)
				throw new InvalidOperationException("view menu is null");

			_popUp.SetX(touchListener.X);
			_popUp.SetY(touchListener.Y);
		}

		void PopulateListView()
		{
			_arrayAdapter = new MenuAdapter(context,  Resource.Layout.widgettextview,_widgets);
			
			_listView = _popUp.FindViewById<ListView>(Resource.Id.widgetSelector);
			_menuItem = _popUp.FindViewById<TextView>(Resource.Id.widgetTextView);

			if (_listView == null)
				throw new InvalidOperationException("Listview is null");

			_listView.SetAdapter(_arrayAdapter);
			_listView.ItemClick += SelectItem;

		
		}

		void SelectItem(object o, AdapterView.ItemClickEventArgs itemEventArgs)
		{

			var itemSelected = (TextView) _arrayAdapter.GetViewItem(itemEventArgs.Position).
				GetTag(Resource.Id.widgetTextView);
			itemSelected.SetBackgroundColor(Android.Graphics.Color.Green);
			//remove the widget menu when closing the popup.

			switch (itemEventArgs.Position) {
				
				case 0:
					//create people widget
					PeopleWidget peopleWidget = new PeopleWidget(new ProjectWidget(context),
						new PeopleWidgetPopUp(context));
					peopleWidget.OnClickWidget();
					break;
			}
		}

		
	}
}