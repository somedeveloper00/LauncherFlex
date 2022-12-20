using TMPro;
using UnityEngine;

namespace LauncherFlex
{
	public class GameView : MonoBehaviour
	{
		[SerializeField] Renderer mainPicture;
		[SerializeField] TMP_Text title;

		private string lastIconPath = string.Empty;

		public GameData gameData { get; private set; }

		public Texture GetTexture() => mainPicture.material.mainTexture;

		public void Init(GameData gameData)
		{
			this.gameData = gameData;
			if ( lastIconPath != gameData.iconPath ) {
				if (IOUtils.LoadTexture2DFromPath(this.gameData.iconPath, out var tex))
				{
					mainPicture.material.mainTexture = tex;
					FixPictureRatio();
				}
			}
			title.gameObject.SetActive(gameData.displayTitle);
			if (gameData.displayTitle) title.text = this.gameData.title;
		}

		[ContextMenu("Fix Picture Ratio")]
		public void FixPictureRatio()
		{
			var tex = mainPicture.material.mainTexture;
			// adapt width based on height
			mainPicture.transform.localScale = new Vector3(
				mainPicture.transform.localScale.x,
				mainPicture.transform.localScale.y,
				((float)tex.width / (float)tex.height) * mainPicture.transform.localScale.y );
		}
		
		public void Play()
		{
			
		}

		public void Close()
		{
			
		}

	}
}