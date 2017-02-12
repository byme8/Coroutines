using System;
using System.Collections;
using Tweens.Data;
using UnityEngine;

namespace Tweens
{
	public static class MoveTween
	{
		public static void Move(this GameObject gameObject,
			Vector3 position,
			float time,
			float delay = 0,
			Curve curve = null)
		{
			var transform = gameObject.transform;
			Coroutines.Coroutines.StartSuperFastCoroutine(() => ProcessTween<Vector3>(
				() => transform.position,
				(o) => transform.position = o,
				(start, to, shift) => start + (to - start) * shift,
				position,
				time,
				delay,
				curve,
				null));
		}

		public static TweenAwaiter MoveAwaiter(this GameObject gameObject,
				Vector3 position,
				float time,
				float delay = 0,
				Curve curve = null)
		{
			var awaiter = new TweenAwaiter();
			var transform = gameObject.transform;
			Coroutines.Coroutines.StartSuperFastCoroutine(() => ProcessTween<Vector3>(
				() => transform.position,
				(o) => transform.position = o,
				(start, to, shift) => start + (to - start) * shift,
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
			Func<TValue, TValue, float, TValue> calculateValue,
			TValue resultValue,
			float time,
			float delay,
			Curve curve,
			TweenAwaiter awaiter)
		{
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
				var currentValue = calculateValue(startValue, resultValue, shift);
				setValue(currentValue);
				timeSpent += UnityEngine.Time.deltaTime;

				yield return null;
			}

			if (awaiter != null)
				awaiter.Done();
		}
	}
}