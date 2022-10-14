using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using LauncherFlex;
using Newtonsoft.Json;
using UnityEngine;

public static class IOUtils
{
	public static readonly string DATA_SAVE_PATH = Path.Combine(Application.persistentDataPath, "games.dat");

	public static bool LoadTexture2DFromPath(string texturePath, out Texture2D texture2D)
	{
		texture2D = null;
		if (!File.Exists(texturePath)) return false;
		var bytes = File.ReadAllBytes(texturePath);
		var tex = new Texture2D(2, 2);
		if (tex.LoadImage(bytes))
		{
			texture2D = tex;
			return true;
		}

		return false;
	}


	public static void SaveGameData(List<GameData> data, Action onFinish)
	{
		CoroutineMaker.DoCoroutine(enumerator());

		IEnumerator enumerator()
		{
			var str_data = JsonConvert.SerializeObject(data);
			Debug.Log($"saving the following data:\n{str_data}");
			var task = File.WriteAllTextAsync(DATA_SAVE_PATH, str_data);
			yield return new WaitUntil(() => task.IsCompleted);
			onFinish?.Invoke();
		}
	}

	public static void LoadGameData(Action<List<GameData>> onComplete, Action onFail)
	{
		CoroutineMaker.DoCoroutine(enumerator());

		IEnumerator enumerator()
		{
			// load games from the file
			var task = File.ReadAllTextAsync(DATA_SAVE_PATH);
			yield return new WaitUntil(() => task.IsCompleted);
			if (task.IsCompletedSuccessfully)
			{
				var gameDats = JsonConvert.DeserializeObject<List<GameData>>(task.Result);
				onComplete?.Invoke(gameDats);
				yield break;
			}
			onFail?.Invoke();
		}
	}
}