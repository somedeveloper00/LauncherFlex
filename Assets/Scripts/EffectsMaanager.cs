using System.Collections.Generic;
using System.Linq;
using AnimFlex;
using AnimFlex.Tweening;
using LauncherFlex;
using UnityEngine;

namespace Scripts
{
	public class EffectsMaanager : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] private Light directLight, pointLight;
		[SerializeField] private MeshRenderer backgroundCircle;
		[SerializeField] private ParticleSystem softFx, hardFx;
		
		[Header("Color Calcs")]
		[Range(0, 1)]
		[SerializeField] private float add_vibrancy = 0.5f;
		[Range(0, 1)]
		[SerializeField] private float add_saturation = 0;
		[Range(0, 1)]
		[SerializeField] private float threshold;
		
		[Header("Transition")]
		[SerializeField] private Ease ease;
		[SerializeField] private float duration;
		[SerializeField] private float delay;

		private Color[] colors;
		private Color[] colorsFreq;
		private List<Tweener> _currentTweeners = new List<Tweener>();

		public void SetEffectsBasedOn(GameView gameView)
		{
			// get most used colors
			var rt = RenderTexture.GetTemporary(3, 3);
			Graphics.Blit(gameView.GetTexture(), rt);
			RenderTexture.active = rt;
			var tex = new Texture2D(rt.width, rt.height);
			tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
			colors = tex.GetPixels().Select(c =>
			{
				Color.RGBToHSV(c, out var h, out var s, out var v);
				v += add_vibrancy;
				s += add_saturation;
				return Color.HSVToRGB(h, s, v);
			}).ToArray();
			
			
			colorsFreq = GetMostFrequentColors(colors, threshold);
			var col1 = colorsFreq[0];
			var col2 = colorsFreq[Mathf.Min(colorsFreq.Length - 1, 1)];

			foreach (var tweener in _currentTweeners)
            {
                if (tweener != null)
					tweener.Kill(false, false);
            }

            // set point light
            _currentTweeners.Add(
				pointLight.AnimLightColorTo(col1, ease, duration, delay)
			);
			
			// set background light
			_currentTweeners.Add(
				backgroundCircle.AnimColorTo(col2, ease, duration, delay)
			);
			
			// set hard particles
			var hardFxMain = hardFx.main;
			_currentTweeners.Add(
				Tweener.Generate(
					() => hardFxMain.startColor.color,
					(color) => hardFxMain.startColor = (Color)color,
					col1,
					ease, duration, delay)
			);
			
			// set soft particles
			var softFxMain = softFx.main;
			_currentTweeners.Add(
				Tweener.Generate(
					() => softFxMain.startColor.color,
					(color) => softFxMain.startColor = (Color)color,
					col1,
					ease, duration, delay)
			);
		}

		public Color[] GetMostFrequentColors(Color[] colors, float threshold)
		{
			var colVals = new List<(Color col, Vector3 v)>();
			foreach (var color in colors) colVals.Add(new(color, new Vector3(color.r, color.g, color.b)));

			var results = new List<(Vector3 vec, int count)>();

			threshold *= threshold;
			foreach (var colVal in colVals)
			{
				for (var i = 0; i < results.Count; i++)
				{
					if (Vector3.SqrMagnitude(colVal.v - results[i].vec) <= threshold)
					{
						results[i] = new((results[i].vec + colVal.v) / 2f, results[i].count + 1);
						goto nextColVal;
					}
				}
				
				// if reached here, no result group has been found
				results.Add(new (colVal.v, 1));
				
				nextColVal:
				continue;
			}

			return results
				.OrderBy(r => -r.count)
				.Select(r => new Color(r.vec.x, r.vec.y, r.vec.z))
				.ToArray();
		}
	}
}