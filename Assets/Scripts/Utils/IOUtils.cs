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


	public static async Task SaveGameDataAsync(List<GameData> data)
	{
		var str_data = JsonConvert.SerializeObject(data);
		Debug.Log($"saving the following data:\n{str_data}");
		await File.WriteAllTextAsync(DATA_SAVE_PATH, str_data);
	}

	public static async void LoadGameData(Action<List<GameData>> onComplete)
	{
		// load games from the file
		var data = await File.ReadAllTextAsync(DATA_SAVE_PATH);
		var gameDats = JsonConvert.DeserializeObject<List<GameData>>(data);
		onComplete?.Invoke(gameDats);
	}
}