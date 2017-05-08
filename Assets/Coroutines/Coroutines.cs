using System.Collections;
using Coroutines;
using Coroutines.Abstractions;
using UnityEngine;

public static class Delay
{
    public static ICoroutine Create(float delay)
    {
        return CoroutinesFactory.StartSuperFastCoroutine(ProcessDelay(delay));
    }
    
    private static IEnumerator ProcessDelay(float delay)
    {
        var timeSpent = 0.0f;
        while (timeSpent < delay)
        {
            timeSpent += Time.deltaTime;
            yield return null;
        }
    }
}
