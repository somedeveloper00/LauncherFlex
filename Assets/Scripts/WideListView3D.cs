﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AnimFlex.Sequencer.UserEnd;
using AnimFlex.Tweening;
using Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LauncherFlex.ListView
{
	public class WideListView3D : MonoBehaviour
	{
		[SerializeField] private EffectsMaanager _effectsMaanager;
		[SerializeField] private Transform lookAt;
		
#region view settings

		[SerializeField] private float radius = 10;
		[SerializeField] private float paddingInDegree = 1;
		[SerializeField] private float centerMoveForward = 1;
		[Header("Anims")] 
		[SerializeField] private float transitionDuration = 0.5f;
		[SerializeField] private float transitionDelay = 0.2f;
		[SerializeField] private Ease transitionEase = Ease.OutCirc;

#endregion

		[SerializeField] private GameView _viewPrefab;
		[SerializeField] private List<GameView> _views = new List<GameView>();
		[SerializeField] private int _activeViewLength = 0; // index of last active view
		[SerializeField] private int currentIndex = 0;

		private List<Tweener> _activeTweeners = new List<Tweener>();


#if UNITY_EDITOR
		private void OnDrawGizmosSelected()
		{
			Handles.color = Color.green;
			var dir = transform.forward * Mathf.Cos(1) -
			         transform.right * Mathf.Sin(1);
			Handles.DrawWireArc(
				CircleCenter, 
				transform.up, 
				dir,
				2 * Mathf.Rad2Deg,
				radius);
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(CircleCenter, 1);
			
			// draw 3 sample positions
			var p = CircleCenter +
			        (transform.forward * Mathf.Cos(paddingInDegree * Mathf.Deg2Rad) - 
			         transform.right * Mathf.Sin(paddingInDegree * Mathf.Deg2Rad)) * radius;
			Gizmos.color = Color.cyan;
			Gizmos.DrawSphere(p, 1);
			p = CircleCenter +
			        (transform.forward * Mathf.Cos(-paddingInDegree * Mathf.Deg2Rad) - 
			         transform.right * Mathf.Sin(-paddingInDegree * Mathf.Deg2Rad)) * radius;
			Gizmos.DrawSphere(p, 1);
			p = CircleCenter +
			        (transform.forward * Mathf.Cos(0 * Mathf.Deg2Rad) - 
			         transform.right * Mathf.Sin(0 * Mathf.Deg2Rad)) * radius;
			Gizmos.DrawSphere(p, 1);
			
			// draw 1st item moving forward - position
			var for_p = p + transform.forward * centerMoveForward;
			Handles.DrawAAPolyLine(new Vector3[]
			{
				p, for_p
			});
			Gizmos.DrawSphere(for_p, 1);
		}
#endif

		private Vector3 CircleCenter => transform.position - transform.forward * radius;

		private void Start()
		{
			GlobalInput.mainNav.Main.Next.performed += input_moveToNext;
			GlobalInput.mainNav.Main.Previous.performed += input_moveToPrevious;
			GlobalInput.mainNav.Main.Select.performed += PlayCurrent;
		}
		private void OnDestroy()
		{
			GlobalInput.mainNav.Main.Next.performed -= input_moveToNext;
			GlobalInput.mainNav.Main.Previous.performed -= input_moveToPrevious;
			GlobalInput.mainNav.Main.Select.performed -= PlayCurrent;
		}

		private void PlayCurrent(InputAction.CallbackContext obj) => PlayCurrent();

		public void PlayCurrent()
		{
			var gameData = _views[currentIndex].gameData;
			var info = new ProcessStartInfo(gameData.execFullPath, gameData.argvs);
			info.WindowStyle = ProcessWindowStyle.Maximized;
			info.WorkingDirectory = Path.GetDirectoryName(gameData.execFullPath);
			info.UseShellExecute = true;
			if (gameData.startAsAdmin)
				info.Verb = "runas";
			Process.Start(info);
			Application.Quit(0);
		}

		public void SetItems(List<GameData> gameDatas) {
			if ( gameDatas.Count > _activeViewLength ) {
				// activate views
				for ( int i = _activeViewLength; i < gameDatas.Count; i++ ) {
					// check if we have enough views
					if ( i >= _views.Count ) {
						var view = Instantiate(_viewPrefab, transform);
						_views.Add(view);
					}
					else {
						_views[i].gameObject.SetActive( true );
					}
				}
			} 
			else if ( gameDatas.Count < _activeViewLength ) {
					// deactivate views
				for ( int i = gameDatas.Count; i < _activeViewLength; i++ ) {
					_views[i].gameObject.SetActive( false );
				}
			}
			_activeViewLength = gameDatas.Count;

			for (int i = 0; i < gameDatas.Count; i++)
			{
				var gameData = gameDatas[i];
				_views[i].Init(gameData);
			}
			UpdateAllViews();
		}

		private void input_moveToNext(InputAction.CallbackContext obj) => MoveToNext();
		public void MoveToNext()
		{
			if(currentIndex >= _activeViewLength - 1) return;
			currentIndex++;
			animateViewsToPosition();
		}

		private void input_moveToPrevious(InputAction.CallbackContext obj) => MoveToPrevious();
		public void MoveToPrevious()
		{
			if(currentIndex == 0) return;
			currentIndex--;
			animateViewsToPosition();
		}
		
		private void animateViewsToPosition()
		{
			foreach (var tweener in _activeTweeners)
			{
				if(tweener != null)
					tweener.Kill(false, false);
			}
			_activeTweeners.Clear();

			for (int i = 0; i < _activeViewLength; i++)
			{
				var tarPos = GetPosFor(i);
				var tarRot = GetRotFor(i);
				_activeTweeners.Add(_views[i].transform
					.AnimPositionTo(tarPos, transitionEase, transitionDuration, transitionDelay));
				_activeTweeners.Add(_views[i].transform
					.AnimRotationTo(tarRot, transitionEase, transitionDuration, transitionDelay));
			}

			_activeTweeners.Last().onComplete += UpdateAllViews;
			_effectsMaanager.SetEffectsBasedOn(_views[currentIndex]);
		}
		
		[ContextMenu("Update View")]
		private void UpdateAllViews()
		{
			for (int i = 0; i < _views.Count; i++)
			{
				UpdateViewAt(i);
			}
			_effectsMaanager.SetEffectsBasedOn(_views[currentIndex]);
		}

		private void UpdateViewAt(int i)
		{
			_views[i].transform.position = GetPosFor(i);
			_views[i].transform.rotation = GetRotFor(i);
		}

		private Quaternion GetRotFor(int i)
		{
			return Quaternion.LookRotation(lookAt.position - GetPosFor(i));
		}

		private Vector3 GetPosFor(int i)
		{
			var angle = (i - currentIndex) * paddingInDegree * Mathf.Deg2Rad;
			var pos = CircleCenter +
			          (transform.forward * Mathf.Cos(angle) -
			           transform.right * Mathf.Sin(angle)) * radius;
			if (i == currentIndex)
			{
				// move forward
				pos += transform.forward * centerMoveForward;
			}

			return pos;
		}

		public void Clear()
		{
			foreach (var view in _views) 
				view.gameObject.SetActive( false );
			_activeViewLength = 0;
		}
	}
}