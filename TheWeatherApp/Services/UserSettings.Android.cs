﻿#if ANDROID
using Android.Content;
using TheWeatherApp.Enums;
using TheWeatherApp.Interfaces;

namespace FTrack4.PlatformServices
{
	public class UserSettings : Java.Lang.Object, IUserSettings
	{
		public void SaveSetting<T>(string name, T value, SettingType type)
		{
			var editor = MainActivity.Prefs.Edit();
			editor.Remove(name);
			editor.Commit();
			switch ((int)type)
			{
				case 0:
					editor.PutBoolean(name, (bool)(object)value);
					break;
				case 1:
					editor.PutFloat(name, (float)(object)value);
					break;
				case 2:
					editor.PutInt(name, (int)(object)value);
					break;
				case 3:
					editor.PutLong(name, (long)(object)value);
					break;
				case 4:
					editor.PutString(name, (string)(object)value);
					break;
			}

            editor.Commit();
		}

		public void SaveSetting(string name, List<string> values)
		{
            var editor = MainActivity.Prefs.Edit();
			editor.Remove(name);
			editor.Commit();
			editor.PutStringSet(name, values);

            editor.Commit();
		}

		public T LoadSetting<T>(string name, SettingType type)
		{
            var nv = new object();
			switch ((int)type)
			{
				case 0:
					nv = MainActivity.Prefs.GetBoolean(name, false);
					break;
				case 1:
					nv = MainActivity.Prefs.GetFloat(name, 0);
					break;
				case 2:
					nv = MainActivity.Prefs.GetInt(name, 0);
					break;
				case 3:
					nv = MainActivity.Prefs.GetLong(name, 0);
					break;
				case 4:
					nv = MainActivity.Prefs.GetString(name, "");
					break;
			}

            return (T)nv;
		}

		public List<string> LoadSetting(string name)
		{
            var strList = MainActivity.Prefs.GetStringSet(name, null);
			var list = new List<string>();
			if (strList == null)
				return list;
			if (strList.Count == 0)
				return list;
			foreach (var i in strList)
				list.Add(i);

            return list;
		}

		public void SetPrefName(string name)
		{
            MainActivity.Prefs = MainActivity.Active.GetSharedPreferences(name, FileCreationMode.Private);
		}

		public void RemoveSetting(string name)
		{
            var editor = MainActivity.Prefs.Edit();
			editor.Remove(name);
			editor.Commit();
		}

		public void RemoveSettings(List<string> names)
		{
            var editor = MainActivity.Prefs.Edit();
			foreach (var n in names)
				editor.Remove(n);
			editor.Commit();
		}

		public void Clear()
		{
            MainActivity.Prefs.Edit().Clear().Commit();
		}
	}
}
#endif