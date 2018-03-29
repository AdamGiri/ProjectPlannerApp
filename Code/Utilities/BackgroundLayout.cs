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

namespace ProjectPlannerApp.Code.Utilities
{
	class BackgroundLayout : RelativeLayout, IMenu
	{
		public BackgroundLayout(Context context) : base(context)
		{
		}

		public bool HasVisibleItems => throw new NotImplementedException();

		public IMenuItem Add(int titleRes)
		{
			throw new NotImplementedException();
		}

		public IMenuItem Add(int groupId, int itemId, int order, int titleRes)
		{
			throw new NotImplementedException();
		}

		public IMenuItem Add(int groupId, int itemId, int order, ICharSequence title)
		{
			throw new NotImplementedException();
		}

		public IMenuItem Add(ICharSequence title)
		{
			throw new NotImplementedException();
		}

		public int AddIntentOptions(int groupId, int itemId, int order, ComponentName caller, Intent[] specifics, Intent intent, [GeneratedEnum] MenuAppendFlags flags, IMenuItem[] outSpecificItems)
		{
			throw new NotImplementedException();
		}

		public ISubMenu AddSubMenu(int titleRes)
		{
			throw new NotImplementedException();
		}

		public ISubMenu AddSubMenu(int groupId, int itemId, int order, int titleRes)
		{
			throw new NotImplementedException();
		}

		public ISubMenu AddSubMenu(int groupId, int itemId, int order, ICharSequence title)
		{
			throw new NotImplementedException();
		}

		public ISubMenu AddSubMenu(ICharSequence title)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public void Close()
		{
			throw new NotImplementedException();
		}

		public IMenuItem FindItem(int id)
		{
			throw new NotImplementedException();
		}

		public IMenuItem GetItem(int index)
		{
			throw new NotImplementedException();
		}

		public bool IsShortcutKey([GeneratedEnum] Keycode keyCode, KeyEvent e)
		{
			throw new NotImplementedException();
		}

		public bool PerformIdentifierAction(int id, [GeneratedEnum] MenuPerformFlags flags)
		{
			throw new NotImplementedException();
		}

		public bool PerformShortcut([GeneratedEnum] Keycode keyCode, KeyEvent e, [GeneratedEnum] MenuPerformFlags flags)
		{
			throw new NotImplementedException();
		}

		public void RemoveGroup(int groupId)
		{
			throw new NotImplementedException();
		}

		public void RemoveItem(int id)
		{
			throw new NotImplementedException();
		}

		public void SetGroupCheckable(int group, bool checkable, bool exclusive)
		{
			throw new NotImplementedException();
		}

		public void SetGroupEnabled(int group, bool enabled)
		{
			throw new NotImplementedException();
		}

		public void SetGroupVisible(int group, bool visible)
		{
			throw new NotImplementedException();
		}

		public void SetQwertyMode(bool isQwerty)
		{
			throw new NotImplementedException();
		}

		public int Size()
		{
			throw new NotImplementedException();
		}
	}
}