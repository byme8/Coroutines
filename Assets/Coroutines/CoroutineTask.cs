using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Coroutines
{
    public class CoroutineTask : CustomYieldInstruction
	{
		private bool _keepWaiting = true;

		public override bool keepWaiting
		{
			get
			{
				return this._keepWaiting;
			}
		}

		public void Done()
		{
			this._keepWaiting = false;
		}
	}

	public static class CoroutinesExtentions
	{
		public static IEnumerator Wait(this IEnumerable<CoroutineTask> tasks)
		{
			foreach (var task in tasks.ToArray())
				if (task.keepWaiting)
					yield return task;
		}
	}
}
