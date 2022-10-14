using System;

namespace LauncherFlex
{
	[Serializable]
	public class GameData
	{
		public string fullPath;
		public string title;
		public string iconPath;
		public string startArguments;
		public bool startAsAdmin;
	}
}