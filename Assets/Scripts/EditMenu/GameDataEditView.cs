using System;
using System.IO;
using SFB;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LauncherFlex.EditMenu
{
	public class GameDataEditView : MonoBehaviour
	{
		public TMP_InputField titleInputText;
		public TMP_InputField execPathInputText;
		public TMP_InputField iconPathInputText;
		public RawImage iconPreview;
		public TMP_InputField argvsInputText;
		public Toggle startAsAdmin;

		public event Action onDelete;
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
				startAsAdmin = startAsAdmin.isOn
			};
		}

		public void SetData(GameData data)
		{
			titleInputText.text = data.title;
			execPathInputText.text = data.execFullPath;
			iconPathInputText.text = data.iconPath;
			argvsInputText.text = data.argvs;
			startAsAdmin.isOn = data.startAsAdmin;
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
					Debug.Log((w, h));
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
	}
}