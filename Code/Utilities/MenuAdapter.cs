using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace ProjectPlannerApp.Code.Utilities
{
	class MenuAdapter : ArrayAdapter
	{
		private readonly Context context;
		private readonly int resLayoutId;

		private  readonly Dictionary<int,View> _viewCollection = new Dictionary<int, View>();

		public MenuAdapter(Context context, int resLayoutId,  IList objects) : 
			base(context, resLayoutId,  objects)
		{
			this.context = context;
			this.resLayoutId = resLayoutId;
			
		}

		

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = (string) GetItem(position);

			if (convertView == null)
			{
				convertView = LayoutInflater.From(context).Inflate(resLayoutId, parent,false);
			}


			if (item != null)
			{
				TextView tv = (TextView)convertView.FindViewById<TextView>(Resource.Id.widgetTextView);
				tv.Text = item;
				convertView.SetTag(Resource.Id.widgetTextView, tv);
				_viewCollection[position] = convertView;
			}

			
			return convertView;
		}

		public View GetViewItem(int position)
		{
			if (position < 0 || position > _viewCollection.Count)
				throw new InvalidOperationException("invalid index");
			return _viewCollection[position];
		}
	}
}