using System.Linq;
using AnimFlex.Tweener;
using UnityEngine;

namespace AnimFlex.Sequencer.Clips
{
	public abstract class CTweener : Clip
	{
        [Tooltip("If checked, it'll play the next clip right away. otherwise it'll wait for the tween to finish")]
        public bool playNextOnStart = false;

        [Tooltip("If checked, the tween will revert when it's either completed or killed.")]
        public bool revertOnEnd = false;

        protected Tweener.Tweener[] tweeners;

        public Tweener.Tweener[] Tweeners => tweeners;
	}

    public abstract class CTweener<T> : CTweener where T : TweenerGenerator
    {

        public T tweenerGenerator;


        protected override void OnStart()
        {
            if (playNextOnStart)
                PlayNext();

            // get rid of all old tweeners
            if (this.tweeners != null)
            {
	            foreach (var tweener in this.tweeners)
	            {
		            if(tweener?.IsActive() == true)
			            tweener.Kill(true, false);
	            }
            }

            if (tweenerGenerator.TryGenerateTween(out var tweeners))
            {
		        this.tweeners = tweeners;
		        if (revertOnEnd)
		        {
			        // do a Set(0) on all tweeners to revert them all to their initial state
			        tweeners.Last().onKill += () =>
			        {
				        foreach (var t in tweeners) t.Set(0);
			        };
		        }

		        if (!playNextOnStart)
	            {
		            tweeners.Last().onComplete += PlayNext;
	            }
            }
            else
            {
                Debug.LogWarning($"Could not generate tweener! playing the next clip...");
                PlayNext();
            }
        }

        public override void OnForceEnd()
        {
	        foreach (var tweener in tweeners)
	        {
				TweenerController.Instance.KillTweener(tweener, true, false);
	        }

        }

    }
}
