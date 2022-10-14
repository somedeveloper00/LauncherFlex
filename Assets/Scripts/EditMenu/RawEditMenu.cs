using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LauncherFlex.EditMenu
{
	public class RawEditMenu : MonoBehaviour
	{
		[SerializeField] private GameDataEditView _editViewPrefab;
		[SerializeField] private Transform _editViewParent;
		
		private List<GameDataEditView> _gameDataEditViews = new List<GameDataEditView>();

		private void Start()
		{
			IOUtils.LoadGameData(
				(gameData) =>
				{
					// instantiate edits
					foreach (var data in gameData)
					{
						var editView = Instantiate(_editViewPrefab, _editViewParent);
						editView.SetData(data);
						editView.onDelete += () => _gameDataEditViews.Remove(editView);
						_gameDataEditViews.Add(editView);
					}
				},
				() =>
				{
					Debug.LogError($"Could not load game data");
				});
		}

		public void AddNewGameData()
		{
			var editView = Instantiate(_editViewPrefab, _editViewParent);
			editView.SetData(new GameData());
			editView.onDelete += () => _gameDataEditViews.Remove(editView);
			_gameDataEditViews.Add(editView);
		}

		public void SaveGameData()
		{
			var _gameData = _gameDataEditViews.Select(g => g.ToGameData()).ToList();
			IOUtils.SaveGameData(_gameData, () =>
			{
				Debug.Log($"Successfully saved.");
			});
		}

		public void CloseMenu()
		{
			Destroy(gameObject);
		}
	}
}