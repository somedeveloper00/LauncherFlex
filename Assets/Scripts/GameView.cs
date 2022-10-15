using TMPro;
using UnityEngine;

namespace LauncherFlex
{
	public class GameView : MonoBehaviour
	{
		[SerializeField] Renderer mainPicture;
		[SerializeField] TMP_Text title;
		

		public GameData gameData { get; private set; }

		public Texture GetTexture() => mainPicture.material.mainTexture;

		public void Init(GameData gameData)
		{
			this.gameData = gameData;
			if (IOUtils.LoadTexture2DFromPath(this.gameData.iconPath, out var tex))
			{
				mainPicture.material.mainTexture = tex;
				
				title.text = this.gameData.title;
			}
		}

		[ContextMenu("Fix Picture Ratio")]
		public void FixPictureRatio()
		{
			var tex = mainPicture.material.mainTexture;
			var (w, h) = ((float)tex.width, (float)tex.height);
			var defSize = Mathf.Max(mainPicture.transform.localScale.x, mainPicture.transform.localScale.y);
			if (w > h)
			{
				// downscale on Y
				mainPicture.transform.localScale = new Vector3(
					defSize,
					defSize * h / w, 1);
			}
			else
			{
				// downscale on X
				mainPicture.transform.localScale = new Vector3(
					defSize * w / h,
					defSize, 1);
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