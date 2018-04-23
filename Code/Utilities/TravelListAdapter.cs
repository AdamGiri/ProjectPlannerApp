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
using Java.Lang;
using Android.Views.InputMethods;

namespace ProjectPlannerApp.Code.Utilities
{
	class TravelListAdapter : BaseAdapter, View.IOnKeyListener
	{
		private IListModifier _widgetPopUp = Utility.GetUtility().WidgetPopUp;
		private Context context;
		private InputMethodManager imm;
		private int _keyCounter = 0;

		public TravelListAdapter(Context context)
		{
			this.context = context;
			imm = (InputMethodManager)context.GetSystemService(Context.InputMethodService);
		}

		public override int Count
		{
			get
			{
				return _widgetPopUp.GetListCount();
			}
		}

		public override Java.Lang.Object GetItem(int position)
		{
			throw new NotImplementedException();
		}

		public override long GetItemId(int position)
		{
			throw new NotImplementedException();
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			TravelListItem travelListItem = (TravelListItem)_widgetPopUp.GetListItem(position);
			var view = convertView;
			TravelListAdapterViewHolder holder = null;

			if (view != null)
				holder = view.Tag as TravelListAdapterViewHolder;

			if (holder == null)
			{
				holder = new TravelListAdapterViewHolder();
				var inflater = context.GetSystemService(Context.LayoutInflaterService).
					JavaCast<LayoutInflater>();
				//replace with your item and your holder items
				//comment back in
				view = inflater.Inflate(Resource.Layout.peoplelistitem, parent, false);
				holder.LocationName = (EditText)view.FindViewById<EditText>(Resource.Id.location);
				holder.PostCode = (EditText)view.FindViewById<EditText>(Resource.Id.postcode);
				holder.Reason = (EditText)view.FindViewById<EditText>(Resource.Id.reason);
				holder.TeleNo = (EditText)view.FindViewById<EditText>(Resource.Id.teleNo);
				view.Tag = holder;
				SetViewFunctionality(holder, position);
			}


			//fill in your items
			//holder.Title.Text = "new text here";

			if (travelListItem != null)
			{
				holder.LocationName.Text = travelListItem.Location;
				holder.PostCode.Text = travelListItem.Postcode;
				holder.Reason.Text = travelListItem.Reason;
				holder.TeleNo.Text = travelListItem.TeleNumber.ToString();
			}
			


			return view;
		}

		private void SetViewFunctionality(TravelListAdapterViewHolder holder, int position)
		{

			holder.LocationName.SetOnKeyListener(this);
			holder.PostCode.SetOnKeyListener(this);
			holder.Reason.SetOnKeyListener(this);
			holder.TeleNo.SetOnKeyListener(this);


			holder.LocationName.SetTag(Resource.Id.button1, (Java.Lang.Object)"location");
			holder.PostCode.SetTag(Resource.Id.button1, (Java.Lang.Object)"postcode");
			holder.Reason.SetTag(Resource.Id.button1, (Java.Lang.Object)"telephone");
			holder.TeleNo.SetTag(Resource.Id.button1, (Java.Lang.Object)"reason");


			holder.LocationName.SetTag(Resource.Id.item1, position);
			holder.PostCode.SetTag(Resource.Id.item1, position);
			holder.Reason.SetTag(Resource.Id.item1, position);
			holder.TeleNo.SetTag(Resource.Id.item1, position);
		}

		class TravelListAdapterViewHolder : Java.Lang.Object
		{
			public EditText LocationName { get; set; }
			public EditText PostCode { get; set; }
			public EditText Reason { get; set; }
			public EditText TeleNo { get; set; }
		}

		public bool OnKey(View v, [GeneratedEnum] Keycode keyCode, KeyEvent e)
		{
			_keyCounter++;


			if (keyCode == Keycode.Enter && _keyCounter % 2 != 0)
			{
				EditText et = (EditText)v;
				CheckTag(et);
				imm.HideSoftInputFromWindow(v.WindowToken, 0);
			}

			return false;

		}

		private void CheckTag(EditText et)
		{
			TravelListItem travelListItem = (TravelListItem)_widgetPopUp.
						GetListItem((int)et.GetTag(Resource.Id.backgroundLayout));
			string textInput = et.Text.ToString();

			switch ((string)et.GetTag(Resource.Id.addPerson))
			{
				case "location":
					travelListItem.Location = textInput;
					break;
				case "postcode":
					travelListItem.Postcode = textInput;
					break;
				case "telephone":
					travelListItem.TeleNumber = textInput;
					break;
				case "reason":
					travelListItem.Reason = textInput;
					break;


			}
		}
	}

}