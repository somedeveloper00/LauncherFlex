using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LauncherFlex.ListView
{
	public class WideListView3D : MonoBehaviour
	{
#region view settings

		[SerializeField] private float radius = 10;
		[SerializeField] private float paddingInDegree = 1;
		[SerializeField] private float centerMoveForward = 1;
		[SerializeField] private Transform lookAt;

#endregion
		[SerializeField] private List<GameView> _views = new List<GameView>();
		[SerializeField] private int currentIndex = 0;


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

		public void AddItems(IEnumerable<GameView> gameViews)
		{
			_views.AddRange(gameViews);
			UpdateAllViews();
		}
		public void AddItem(GameView gameView)
		{
			_views.Add(gameView);
			UpdateAllViews();
		}

		[ContextMenu("Update View")]
		private void UpdateAllViews()
		{
			for (int i = 0; i < _views.Count; i++)
			{
				UpdateViewAt(i);
			}
		}

		private void UpdateViewAt(int i)
		{
			var angle = (i - currentIndex) * paddingInDegree * Mathf.Deg2Rad;
			_views[i].transform.position = CircleCenter +
			                               (transform.forward * Mathf.Cos(angle) -
			                                transform.right * Mathf.Sin(angle)) * radius;
			_views[i].transform.LookAt(lookAt);
		}
	}
}