using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AnimFlex.Sequencer.UserEnd;
using AnimFlex.Tweener;
using SFB;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Scripts.WebCatcher
{
	public class CoverImageRetriever : MonoBehaviour
	{
		[SerializeField] private Transform spawningParent;
		[SerializeField] private IconItem iconItemPrefab;
		[SerializeField] private int searchSubjectCount = 5;
		[SerializeField] private SequenceAnim outAnim;
		[SerializeField] private TMP_Text hint_text;

		private List<IconItem> _iconItems = new List<IconItem>();
		private Texture2D currentTexture;

		public event Action<string> onComplete;
		
		public void SearchAndShow(string gameName)
		{
			StopCoroutine(enumerator());
			StartCoroutine(enumerator());

			IEnumerator enumerator()
			{
				hint_text.text = "finding results...";
				
				var requestUri = $"https://www.mobygames.com/search/quick?q={string.Join("+", gameName.Split())}";

				var readPageAsync = ReadPageAsync(requestUri);
				yield return new WaitUntil(() => readPageAsync.IsCompleted);
				var pageContent = readPageAsync.Result;
				
				// get pages for top games
				const string v = "class=\"searchImage\"><a href=\"";
				var results = FindAllLinksWithinString(pageContent, v, "\"", "/cover-art");

				hint_text.text = $"found {results.Count} game pages. downloading images...";
				
				// read page for each cover store
				var resultPages = new List<string>();
				foreach (var result in results)
				{
					Debug.Log($"opening page: {result}");
					var readTask = ReadPageAsync(result);
					yield return new WaitUntil(() => readTask.IsCompleted);
					resultPages.Add(readTask.Result);
				}

				Debug.Log($"pages saved. downloading images...");

				foreach (var page in resultPages)
				{
					var imageLinks = FindAllLinksWithinString(page,
							"class=\"thumbnail-cover\" style=\"background-image:url(", ");", String.Empty)
						.Select(l => "www.mobygames.com" + l.Replace("/s/", "/l/").Replace("jpg", "png")).ToList();

					foreach (var url in imageLinks)
					{
						Debug.Log($"downloading image {url}");
						var req = UnityWebRequestTexture.GetTexture(url);
						yield return req.SendWebRequest();

						if (req.result != UnityWebRequest.Result.Success)
						{
							Debug.LogError($"error downloading url: {url}");
						}
						else
						{
							Debug.Log("done.");
							var tex = ((DownloadHandlerTexture)req.downloadHandler).texture;

							var iconItem = Instantiate(iconItemPrefab, spawningParent);
							iconItem.Init(tex);
							iconItem.onSelect += OnSelectCoverItem;
							_iconItems.Add(iconItem);
						}


					}
				}
				
				hint_text.text = "done.";
				hint_text.AnimFadeTo(0, duration: 2);
				
				yield break;
			}

			List<string> FindAllLinksWithinString(string pageContent, string beforeLink, string terminator, string addAfter)
			{
				var s = new List<string>();
				int lastIndex = 0;
				for (int i = 0; i < searchSubjectCount; i++)
				{
					var ind = pageContent.IndexOf(beforeLink);
					if(ind == -1) break;
					pageContent = pageContent.Substring(ind + beforeLink.Length);
					string link = pageContent.Substring(0, pageContent.IndexOf(terminator, lastIndex + 1));
					s.Add(link + addAfter);
				}

				return s;
			}
			
			async Task<string> ReadPageAsync(string url)
			{
				Debug.Log($"reading {url}...");
				var req = WebRequest.Create(url);
				var res = await req.GetResponseAsync();
				Debug.Log($"retrieved result");

				var r = string.Empty;
				using (var sr = new StreamReader(res.GetResponseStream()))
				{
					r = sr.ReadToEnd();
				}

				return r;
			}
		}

		public void OnSelectCoverItem(IconItem iconItem)
		{
			foreach (var item in _iconItems)
				if (item != iconItem)
					item.DeSelect();
			currentTexture = iconItem.GetTexture();
		}

		public void ConfirmAndClose()
		{
			var path = StandaloneFileBrowser.SaveFilePanel("Save cover image", "", "icon.png", "png");
			if(string.IsNullOrWhiteSpace(path) || File.Exists(path)) return;
			
			var bytes = currentTexture.EncodeToPNG();
			File.WriteAllBytes(path, bytes);
			onComplete?.Invoke(path);
			outAnim.PlaySequence();
		}

		public void Close()
		{
			Destroy(gameObject);
		}
	}
	
}