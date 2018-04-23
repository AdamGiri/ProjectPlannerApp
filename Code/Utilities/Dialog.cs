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
using Android.Util;



namespace ProjectPlannerApp.Code.Utilities
{
	class Dialog : Java.Lang.Object, IDialogInterfaceOnClickListener
	{
	
		public Context Context { get; private set; }


		private  string _message;
		private int _width = MainActivity.GetScreenWidth();
		private int _height = MainActivity.GetScreenHeight()/2 ;
		private int _fontSize = 10;
		public ProjectObject ProjectObject { private get; set; }


		public Dialog(Context context)
		{
			Context = context;
		}

		public Dialog(string message,  int width, int height,
			Context context, int fontSize)
		{
			_message = message;
			_width = width;
			_height = height;
			_fontSize = fontSize;
			Context = context;
		}

		public void OnClick(IDialogInterface dialog, int which)
		{
			switch (which)
			{
				case (int)DialogButtonType.Positive:
					ProjectObject.DeleteObject();
					break;
				case (int)DialogButtonType.Negative:
					break;
			}
		}
		
		public  int GetHeight()
		{
			return _height;
		}

		public  int GetWidth()
		{
			return _width;
		}

		public  string GetMessage()
		{
			return _message;
		}

	

	}
}