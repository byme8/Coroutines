using System.Collections;
using Coroutines;
using Coroutines.Abstractions;
using Tweens.Data;
using UnityEngine;

namespace Tweens
{
    public static class MoveTween
	{
		public static ICoroutine Move(this GameObject gameObject,
				Vector3 position,
				float time,
				float delay = 0,
				Curve curve = null)
		{
			var transform = gameObject.transform;

            return CoroutinesFactory.StartSuperFastCoroutine(ProcessTween(
				transform,
				position,
				time,
				delay,
				curve));
		}

		private static IEnumerator ProcessTween(
			Transform transform,
			Vector3 position,
			float time,
			float delay,
			Curve curve)
		{
			if (curve == null)
				curve = Curves.BackIn;

			var timeSpent = 0.0f;
			while (timeSpent < delay)
			{
				timeSpent += UnityEngine.Time.deltaTime;
				yield return null;
			}

			timeSpent = 0.0f;
			var start = transform.position;
			var delta = position - start;
			while (timeSpent < time)
			{
				var shift = curve.Caclculate(timeSpent / time);
				var currentValue = start + delta * shift;
				transform.position = currentValue;
				timeSpent += UnityEngine.Time.deltaTime;
				yield return null;
			}
		}
	}
}