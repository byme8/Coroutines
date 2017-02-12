using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Coroutines
{
	class CoroutineHolder : MonoBehaviour
	{
		HashSet<IEnumerator> superFastCoroutines 
			= new HashSet<IEnumerator>();

		public void AddSuperFastCoroutine(IEnumerator coroutine)
		{
			this.superFastCoroutines.Add(coroutine);
		}

		void Update()
		{
			foreach(var coroutine in this.superFastCoroutines.ToArray())
				if (!coroutine.MoveNext())
					this.superFastCoroutines.Remove(coroutine);
				else
					if (coroutine.Current != null)
						throw new NotSupportedException("Super fast coroutines must return only null.");
		}
	}
}