using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LauncherFlex
{
	public class GameView : MonoBehaviour
	{
		[SerializeField] Image mainPicture;
		[SerializeField] TMP_Text title;

		private GameData gameData;

		public void Init(GameData gameData)
		{
			this.gameData = gameData;
			if (IOUtils.LoadTexture2DFromPath(this.gameData.iconPath, out var tex))
			{
				mainPicture.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
				title.text = this.gameData.title;
			}
		}
		
		public void Play()
		{
			
		}

		public void Close()
		{
			
		}

	}
}