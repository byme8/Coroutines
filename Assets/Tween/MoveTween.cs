using System;
using System.Collections;
using Tweens.Data;
using UnityEngine;

namespace Tweens
{
	public static class MoveTween
	{
		public static CoroutineTask Move(this GameObject gameObject,
				Vector3 position,
				float time,
				float delay = 0,
				Curve curve = null)
		{
			var awaiter = new CoroutineTask();
			var transform = gameObject.transform;
			var start = transform.position;
			var delta = position - start;
			Coroutines.Coroutines.StartSuperFastCoroutine(() => ProcessTween<Vector3>(
				() => transform.position,
				(o) => transform.position = o,
				(shift) => start + delta * shift,
				position,
				time,
				delay,
				curve,
				awaiter));
			return awaiter;
		}

		private static IEnumerator ProcessTween<TValue>(
			Func<TValue> getValue,
			Action<TValue> setValue,
			Func<float, TValue> calculateValue,
			TValue resultValue,
			float time,
			float delay,
			Curve curve,
			CoroutineTask awaiter)
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
			var startValue = getValue();
			while (timeSpent < time)
			{
				var shift = curve.Caclculate(timeSpent / time);
				var currentValue = calculateValue(shift);
				setValue(currentValue);
				timeSpent += UnityEngine.Time.deltaTime;

				yield return null;
			}

			if (awaiter != null)
				awaiter.Done();
		}
	}
}