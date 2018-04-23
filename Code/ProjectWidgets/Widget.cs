using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using ProjectPlannerApp.Code.Utilities;


namespace ProjectPlannerApp.Code.ProjectWidgets
{
	class Widget
	{
		private ProjectObject _projectWidget;
		private IPopUp _widgetPopUp;
		private readonly IDialog dialog;

		private static string _title;
		private static Color _color;

		public Widget(ProjectObject projectWidget, IPopUp widgetPopUp, IDialog dialog)
		{
			_projectWidget = projectWidget ?? throw new
				NullReferenceException("ProjectWidget is null");
			this._widgetPopUp = widgetPopUp;
			this.dialog = dialog ?? throw new NullReferenceException("Dialog is null");
			this.dialog.SetProjectObject(_projectWidget);
			DesignWidget();
		}

		public void OnClickWidget(object o, EventArgs e)
		{
			if (_widgetPopUp == null)
				throw new NullReferenceException("Popup  is null");

			_widgetPopUp.PopUp();
		}

		public static Color GetColor()
		{
			return _color;
		}

		public static string GetTitle()
		{
			return _title;
		}

		public virtual void DesignWidget()
		{
			TextView tv = (TextView)_projectWidget.View.
				FindViewById<TextView>(Resource.Id.widget);


			if (tv == null)
				throw new NullReferenceException("textview is null");

			tv.SetBackgroundColor(_color);
			tv.Text = _title;
			tv.Click += OnClickWidget;
			tv.LongClick += OnLongClickWidget;


		}

		public void OnLongClickWidget(object o, EventArgs e)
		{

			dialog.ShowDialog();
		}
	}
}