using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace LauncherFlex.EditMenu
{
	public class EditMenu : MonoBehaviour
	{
		private List<GameData> _gameData = new List<GameData>();

		private IEnumerator Start()
		{
			var task = Task.Run(async () => _gameData = await IOUtils.LoadGameDatasAsync());
			yield return new WaitUntil(() => task.IsCompleted);
			
		}
	}
}