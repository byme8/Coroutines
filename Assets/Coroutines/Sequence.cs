using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coroutines.Abstractions;
using UnityEngine;

namespace Coroutines
{
    public static class Sequence
    {
        public static ICoroutine Create(params ICoroutine[] coroutines)
        {
            return CoroutinesFactory.StartSuperFastCoroutine(ProcessSequnce(coroutines));
        }

        private static IEnumerator ProcessSequnce(ICoroutine[] coroutines)
        {
            foreach (var coroutine in coroutines)
                while (coroutine.keepWaiting)
                {
                    if (!coroutine.MoveNext())
                        coroutine.Done();

                    yield return null;
                }
        }
    }
}
