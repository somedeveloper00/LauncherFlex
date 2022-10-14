using System;
using System.Collections.Generic;
using System.ComponentModel;
using AnimFlex.Tweener;

namespace AnimFlex.Sequencer.Clips
{
	[Category("Tweener/Revert Tweeners")]
	[DisplayName("Revert Tweeners")]
	public class CTweenerRevert : Clip
	{
		public CTweenerIndex[] tweenerClipIndeces;

		protected override void OnStart()
		{
			CTweener[] tweenerClips = GetTweenerClips();
			foreach (var tweenerClip in tweenerClips)
			{
				if(tweenerClip.Tweeners == null) continue;

				foreach (var tweener in tweenerClip.Tweeners)
				{
					if(tweener == null) continue;
					tweener.Revert();
				}
			}
			PlayNext();
		}

		private CTweener[] GetTweenerClips()
		{
			var r = new List<CTweener>();
			foreach (var ind in tweenerClipIndeces)
			{
				if (Node.sequence.GetClipAtIndex(ind) is CTweener ctweener)
				{
					r.Add(ctweener);
				}
			}

			return r.ToArray();
		}

		public override void OnForceEnd() { }

		/// <summary>
		/// A class so it can take advantage of Unity's default Array drawer inside the <see cref="CTweenerRevert"/> class
		/// </summary>
		[Serializable]
		public class CTweenerIndex
		{
			public int index;
			public static implicit operator int(CTweenerIndex index) => index.index;
		}

	}
}
