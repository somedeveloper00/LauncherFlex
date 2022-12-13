using System;
using System.Threading.Tasks;
using LauncherFlex.EditMenu;
using UnityEngine;

namespace LauncherFlex
{
	public class MainCanvas : MonoBehaviour
	{
		[SerializeField] private RawEditMenu _rawEditMenu;
		[SerializeField] private Manager _manager;

		public async void OpenRawEditMenu()
		{
			GlobalInput.EnableOverlay();
			await _rawEditMenu.OpenMenu();
			GlobalInput.DisableOverlay();
			_manager.ReloadGamesListView();
		}
	}
}