using System;
using UnityEngine;

namespace AnimFlex.Tweener
{
    public static class Helpers
    {
	    /// <summary>
	    /// <para>checks if the tweener is active or not.</para>
	    /// <para>note: if a tweener is just created, it won't actually be considered Active until it's <see cref="Tweener.onStart"/> is called.</para>
	    /// </summary>
	    public static bool IsActive(this Tweener tweener)
	    {
		    return tweener.flag.HasFlag(TweenerFlag.Active);
	    }

	    /// <summary>
	    /// <para>reverts the tweener.</para>
	    /// <para>note: if the tweener is Active, it'll kill the tweener first, and then reverts it, which could
	    /// happen in the next frame and not instantly</para>
	    /// </summary>
	    public static void Revert(this Tweener tweener)
	    {
		    if (tweener.IsActive())
		    {
			    tweener.onKill += () => tweener.Set(0);
			    tweener.Kill(false, true);
		    }
		    else
		    {
				tweener.Set(0);
		    }
	    }

        /// <summary>
        /// kills the tweener in the next frame
        /// </summary>
        public static void Kill(this Tweener tweener, bool complete, bool onCompleteCallback)
        {
            TweenerController.Instance.KillTweener(tweener, complete, onCompleteCallback);
        }

        public static Tweener<T> SetDuration<T>(this Tweener<T> tweener, float duration)
        {
            tweener.duration = duration;
            return tweener;
        }

        public static Tweener<T> SetDelay<T>(this Tweener<T> tweener, float delay)
        {
            tweener.delay = delay;
            return tweener;
        }

        public static Tweener<T> SetEase<T>(this Tweener<T> tweener, Ease ease)
        {
            tweener.ease = ease;
            return tweener;
        }

        public static Tweener<T> SetEndValue<T>(this Tweener<T> tweener, T endValue)
        {
            tweener.endValue = endValue;
            return tweener;
        }

        public static Tweener<T> AddOnComplete<T>(this Tweener<T> tweener, Action onComplete)
        {
            tweener.onComplete += onComplete;
            return tweener;
        }

        public static Tweener<T> AddOnKill<T>(this Tweener<T> tweener, Action onKill)
        {
            tweener.onKill += onKill;
            return tweener;
        }

        public static Tweener<T> AddOnUpdate<T>(this Tweener<T> tweener, Action onUpdate)
        {
            tweener.onUpdate += onUpdate;
            return tweener;
        }
    }
}
