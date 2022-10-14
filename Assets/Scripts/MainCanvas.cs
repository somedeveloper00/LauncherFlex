using LauncherFlex.EditMenu;
using UnityEngine;

namespace LauncherFlex
{
	public class MainCanvas : MonoBehaviour
	{
		[SerializeField] private RawEditMenu _rawEditMenuPrefab;

		public void OpenRawEditMenu()
		{
			var menu = Instantiate(_rawEditMenuPrefab);
			menu.GetComponent<Canvas>().sortingOrder = GetComponent<Canvas>().sortingOrder + 10;
		}
	}
}