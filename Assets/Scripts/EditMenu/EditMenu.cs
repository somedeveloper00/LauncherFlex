using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using System.Threading.Tasks;
using AnimFlex.Sequencer.UserEnd;
using HandyUI.ThemeSystem;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace LauncherFlex.EditMenu
{
	public class EditMenu : MonoBehaviour
	{
		[SerializeField] private GameDataEditView _editViewPrefab;
		[SerializeField] private Transform _editViewParent;
		[SerializeField] private SequenceAnim _inAnim;
		[SerializeField] private SequenceAnim _outAnim;
		[SerializeField] private Theme _theme;
		[SerializeField] private ScrollRect _scrollRect;

		private List<GameDataEditView> _gameDataEditViews = new List<GameDataEditView>();
		private Canvas _canvas;
		private Action _onClose = null;
		private Action _onChange = null;
		private bool _opened = false;

		private void Awake() {
			_canvas = GetComponent<Canvas>();
			_canvas.enabled = false;
		}


		private void Start() {
			IOUtils.LoadGameData(
				(gameData) => {
					// instantiate edits
					for ( var i = 0; i < gameData.Count; i++ ) {
						var data = gameData[i];
						var editView = Instantiate( _editViewPrefab, _editViewParent );
						editView.SetData( data );
						editView.onDelete += () => {
							_gameDataEditViews.Remove( editView );
							SaveGameDataAsync( () => _onChange?.Invoke() );
						};
						editView.onMoveUp += () => {
							int index = editView.transform.GetSiblingIndex();
							if ( index == 0 ) return;

							// set view
							_gameDataEditViews[index].transform
								.SetSiblingIndex( _gameDataEditViews[index].transform.GetSiblingIndex() - 1 );
							// set data
							var temp = _gameDataEditViews[index];
							_gameDataEditViews[index] = _gameDataEditViews[index - 1];
							_gameDataEditViews[index - 1] = temp;
							SaveGameDataAsync( () => _onChange?.Invoke() );
						};
						editView.onMoveDown += () => {
							int index = editView.transform.GetSiblingIndex();
							if ( index == gameData.Count - 1 ) return;

							// set view
							_gameDataEditViews[index].transform
								.SetSiblingIndex( _gameDataEditViews[index].transform.GetSiblingIndex() + 1 );
							// set data
							var tmp = _gameDataEditViews[index];
							_gameDataEditViews[index] = _gameDataEditViews[index + 1];
							_gameDataEditViews[index + 1] = tmp;
							index++;
							SaveGameDataAsync( () => _onChange?.Invoke() );
						};
						_gameDataEditViews.Add( editView );
					}
					_theme.UpdateTheme( true );
				});
		}


		public async Task OpenMenu(Action onClose, Action onChange) {
			_canvas.enabled = true;
			_scrollRect.verticalNormalizedPosition = 1;
			await _inAnim.PlaySequenceAsync();
			this._onClose = onClose;
			_onChange = onChange;
			_opened = true;
		}
		
		public void AddNewGameData() {
			var editView = Instantiate( _editViewPrefab, _editViewParent );
			editView.SetData( new GameData() );
			editView.onDelete += () => _gameDataEditViews.Remove( editView );
			_gameDataEditViews.Add( editView );
		}

		public async Task SaveGameDataAsync(Action onCompleted = null) {
			var _gameData = _gameDataEditViews.Select( g => g.ToGameData() ).ToList();
			await IOUtils.SaveGameDataAsync( _gameData );
			Debug.Log( $"Successfully saved." );
			onCompleted?.Invoke();
		}

		public async void CloseMenu() {
			if ( !_opened ) return;
			_opened = false;
			await SaveGameDataAsync();
			await _outAnim.PlaySequenceAsync();
			_canvas.enabled = false;
			_onClose?.Invoke();
		}
	}
}