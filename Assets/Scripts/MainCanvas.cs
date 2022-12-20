using System;
using System.Threading.Tasks;
using LauncherFlex.EditMenu;
using UnityEngine;

namespace LauncherFlex
{
	public class MainCanvas : MonoBehaviour
	{
		[SerializeField] private EditMenu.EditMenu editMenu;
		[SerializeField] private Manager _manager;

		public void OpenRawEditMenu()
		{
			GlobalInput.EnableOverlay();
			editMenu.OpenMenu(
				onClose: () => {
					_manager.ReloadGamesListView();
					GlobalInput.DisableOverlay();
				},
				onChange: () => {
				} );
		}
	}
}