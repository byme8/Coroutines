using System;
using System.Collections;
using UnityEngine;

namespace Coroutines
{
	public static class Coroutines
	{
		static CoroutineHolder CoroutineHolder;

		static Coroutines()
		{
			var gameObject =  new GameObject("~Coroutines");
			CoroutineHolder = gameObject.AddComponent<CoroutineHolder>();
		}

		public static IEnumerator StartSuperFastCoroutine(Func<IEnumerator> coroutineProvider)
		{
			var enumerator = coroutineProvider();
			CoroutineHolder.AddSuperFastCoroutine(enumerator);
			
			return enumerator;
		}
	}
}