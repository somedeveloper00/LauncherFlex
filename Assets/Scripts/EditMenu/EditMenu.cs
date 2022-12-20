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
							var _gameData = _gameDataEditViews.Select( g => g.ToGameData() ).ToList();
							IOUtils.SaveGameDataAsync( _gameData );
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
							var _gameData = _gameDataEditViews.Select( g => g.ToGameData() ).ToList();
							IOUtils.SaveGameDataAsync( _gameData );
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
							var _gameData = _gameDataEditViews.Select( g => g.ToGameData() ).ToList();
							IOUtils.SaveGameDataAsync( _gameData );
						};
						_gameDataEditViews.Add( editView );
					}
					_theme.UpdateTheme( true );
				});
		}


		public void OpenMenu(Action onClose, Action onChange) {
			_scrollRect.verticalNormalizedPosition = 1;
			this._onClose = onClose;
			_onChange = onChange;
			_opened = true;
			_inAnim.PlaySequence();
		}
		
		public void AddNewGameData() {
			var editView = Instantiate( _editViewPrefab, _editViewParent );
			editView.SetData( new GameData() );
			editView.onDelete += () => _gameDataEditViews.Remove( editView );
			_gameDataEditViews.Add( editView );
		}


		public void CloseMenu() {
			if ( !_opened ) return;
			_opened = false;
			
			// save data
			var _gameData = _gameDataEditViews.Select( g => g.ToGameData() ).ToList();
			IOUtils.SaveGameDataAsync( _gameData );
			
			// out sequence will eventually finish the job
			_outAnim.PlaySequenceAsync();
		}

		public void invokeOnClose() {
			_onClose?.Invoke();
		}
	}
}