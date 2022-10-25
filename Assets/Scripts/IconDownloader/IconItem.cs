using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.WebCatcher
{
	public class IconItem : MonoBehaviour
	{
		[SerializeField] private Image[] imagesToSet;
		[SerializeField] private Image highlightingImage;
		[SerializeField] private Color def, highlight;
		
		public bool IsSelected { get; private set; } = false;
		public event Action<IconItem> onSelect;
		public Texture2D GetTexture() => imagesToSet[0].sprite.texture;

		public void Init(Texture2D texture)
		{
			foreach (var image in imagesToSet)
				image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
			
		}

		public void Select()
		{
			if(IsSelected) return;
			IsSelected = true;
			highlightingImage.color = highlight;
			onSelect?.Invoke(this);
		}

		public void DeSelect()
		{
			if(!IsSelected) return;
			IsSelected = false;
			highlightingImage.color = def;
		}
	}
}