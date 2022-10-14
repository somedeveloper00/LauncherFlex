using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace LauncherFlex
{
	public static class IOUtils
	{
		public static readonly string DATA_SAVE_PATH = Path.Combine(Application.persistentDataPath, "games.dat");
		
		public static Texture2D LoadTexture2DFromPath(string texturePath)
		{
			if (!File.Exists(texturePath)) throw new FileNotFoundException(texturePath);
			var bytes = File.ReadAllBytes(texturePath);
			var tex = new Texture2D(2, 2);
			if (tex.LoadImage(bytes))
			{
				return tex;
			}

			throw new InvalidDataException(texturePath);
		}


		public static async Task<List<GameData>> LoadGameDatasAsync()
		{ 
			// load games from the file
			var source = new CancellationTokenSource();
			var data = await File.ReadAllTextAsync(IOUtils.DATA_SAVE_PATH, source.Token);
			var gameDats = JsonConvert.DeserializeObject<List<GameData>>(data);
			return gameDats;
		}
	}
}