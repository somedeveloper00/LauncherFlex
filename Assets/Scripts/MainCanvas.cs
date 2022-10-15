using LauncherFlex.EditMenu;
using UnityEngine;

namespace LauncherFlex
{
	public class MainCanvas : MonoBehaviour
	{
		[SerializeField] private RawEditMenu _rawEditMenuPrefab;
		[SerializeField] private Manager _manager;

		public void OpenRawEditMenu()
		{
			GlobalInput.EnableOverlay();
			var menu = Instantiate(_rawEditMenuPrefab);
			menu.onDestroy += () =>
			{
				GlobalInput.DisableOverlay();
				_manager.ReloadGamesListView();
			};
			menu.GetComponent<Canvas>().sortingOrder = GetComponent<Canvas>().sortingOrder + 10;
		}
	}
}