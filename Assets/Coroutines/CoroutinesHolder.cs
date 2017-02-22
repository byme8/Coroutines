using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Coroutines
{
	class CoroutineHolder : MonoBehaviour
	{
		List<IEnumerator> superFastCoroutines 
			= new List<IEnumerator>();

		public void AddSuperFastCoroutine(IEnumerator coroutine)
		{
			this.superFastCoroutines.Add(coroutine);
		}

		void Update()
		{
			this.superFastCoroutines.RemoveAll(o => !o.MoveNext());
		}
	}
}