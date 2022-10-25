﻿using System;

namespace LauncherFlex
{
	[Serializable]
	public class GameData
	{
		public string execFullPath;
		public string title;
		public bool displayTitle;
		public string iconPath;
		public string argvs;
		public bool startAsAdmin;
	}
}