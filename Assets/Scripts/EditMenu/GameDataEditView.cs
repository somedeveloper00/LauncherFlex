using System;
using System.IO;
using Scripts.WebCatcher;
using SFB;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LauncherFlex.EditMenu
{
	public class GameDataEditView : MonoBehaviour
	{
		[SerializeField] private CoverImageRetriever coverImageRetrieverPrefab;
		
		public TMP_InputField titleInputText;
		public TMP_InputField execPathInputText;
		public TMP_InputField iconPathInputText;
		public RawImage iconPreview;
		public TMP_InputField argvsInputText;
		public Toggle startAsAdmin;
		public Toggle displayTitle;

		public event Action onDelete;
		public event Action onMoveUp, onMoveDown;
		
		private string lastIconPath = "";

		private void Update()
		{
			if (iconPathInputText.text != lastIconPath)
			{
				lastIconPath = iconPathInputText.text;
				UpdateIconPreview();
			}
		}

		public void Delete()
		{
			onDelete?.Invoke();
			Destroy(gameObject);
		}
		
		public GameData ToGameData()
		{
			return new GameData()
			{
				argvs = argvsInputText.text,
				title = titleInputText.text,
				iconPath = iconPathInputText.text,
				execFullPath = execPathInputText.text,
				startAsAdmin = startAsAdmin.isOn,
				displayTitle = displayTitle.isOn
			};
		}

		public void MoveDown() => onMoveDown?.Invoke();
		public void MoveUp() => onMoveUp?.Invoke();

		public void SetData(GameData data)
		{
			titleInputText.text = data.title;
			execPathInputText.text = data.execFullPath;
			iconPathInputText.text = data.iconPath;
			argvsInputText.text = data.argvs;
			startAsAdmin.isOn = data.startAsAdmin;
			displayTitle.isOn = data.displayTitle;
		}

		public void UpdateIconPreview()
		{
			if (IOUtils.LoadTexture2DFromPath(iconPathInputText.text, out var tex))
			{
				if (tex != null)
				{
					iconPreview.texture = tex;
					var w = iconPreview.rectTransform.sizeDelta.x;
					var h = w * ((float)tex.height / tex.width);
					iconPreview.rectTransform.sizeDelta = new Vector2(w, h);
					return;
				}
			}
			
			// set texture to null if not successful
			iconPreview.texture = null;
		}

		public void SelectExecutable()
		{
			var path = StandaloneFileBrowser.OpenFilePanel("Select game's executable file", "", "exe", false);
			Debug.Log(path);
			if (path != null && path.Length > 0 && File.Exists(path[0]))
			{
				execPathInputText.text = path[0];
			}
		}
		
		public void SelectIcon()
		{
			var path = StandaloneFileBrowser.OpenFilePanel("Select game's icon image", "", new ExtensionFilter[]
			{
				new ExtensionFilter("Image Files", "png", "jpg", "jpeg")
			}, false);
			Debug.Log(path);
			if (path.Length > 0 && File.Exists(path[0]))
			{
				iconPathInputText.text = path[0];
			}
		}

		public void OpenIconDownloadPage()
		{
			var cir = Instantiate(coverImageRetrieverPrefab);
			cir.SearchAndShow(titleInputText.text);
			cir.onComplete += value => iconPathInputText.text = value;
		}
	}
}