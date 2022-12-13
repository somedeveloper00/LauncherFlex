using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using System.Threading.Tasks;
using HandyUI.ThemeSystem;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace LauncherFlex.EditMenu
{
	public class RawEditMenu : MonoBehaviour
	{
		[SerializeField] private GameDataEditView _editViewPrefab;
		[SerializeField] private Transform _editViewParent;
		[SerializeField] private ThemedElementAnimPlayer _player;
		[SerializeField] private ScrollRect _scrollRect;

		public event Action onDestroy;
		private List<GameDataEditView> _gameDataEditViews = new List<GameDataEditView>();
		private Canvas _canvas;

		private void Awake() {
			_canvas = GetComponent<Canvas>();
			_canvas.enabled = false;
		}


		private void Start() {
			IOUtils.LoadGameData(
				(gameData) => {
					// instantiate edits
					for ( var i = 0; i < gameData.Count; i++ ) {
						int index = i;
						var data = gameData[i];
						var editView = Instantiate( _editViewPrefab, _editViewParent );
						editView.SetData( data );
						editView.onDelete += () => _gameDataEditViews.Remove( editView );
						editView.onMoveUp += () => {
							if ( index == 0 ) return;

							// set view
							_gameDataEditViews[index].transform
								.SetSiblingIndex( _gameDataEditViews[index].transform.GetSiblingIndex() - 1 );
							// set data
							var tmp = _gameDataEditViews[index];
							_gameDataEditViews[index] = _gameDataEditViews[index - 1];
							_gameDataEditViews[index - 1] = tmp;
						};
						editView.onMoveDown += () => {
							if ( index == gameData.Count - 1 ) return;

							// set view
							_gameDataEditViews[index].transform
								.SetSiblingIndex( _gameDataEditViews[index].transform.GetSiblingIndex() + 1 );
							// set data
							var tmp = _gameDataEditViews[index];
							_gameDataEditViews[index] = _gameDataEditViews[index + 1];
							_gameDataEditViews[index + 1] = tmp;
						};
						_gameDataEditViews.Add( editView );
					}
				},
				() => { Debug.LogError( $"Could not load game data" ); } );
		}


		public async Task OpenMenu() {
			_canvas.enabled = true;
			_scrollRect.verticalNormalizedPosition = 1;
			await _player.PlayInAnimAsync();
		}
		
		public void AddNewGameData() {
			var editView = Instantiate( _editViewPrefab, _editViewParent );
			editView.SetData( new GameData() );
			editView.onDelete += () => _gameDataEditViews.Remove( editView );
			_gameDataEditViews.Add( editView );
		}

		public void SaveGameData() {
			var _gameData = _gameDataEditViews.Select( g => g.ToGameData() ).ToList();
			IOUtils.SaveGameData( _gameData, () => { Debug.Log( $"Successfully saved." ); } );
		}

		public async void CloseMenu() {
			await _player.PlayOutAnimAsync();
			_canvas.enabled = false;
		}
	}
}