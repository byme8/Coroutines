using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Coroutines;
using Tweens;
using UnityEngine;

public class Test : MonoBehaviour
{

    IEnumerator Start()
    {
        var time = 5f;
        var count = 10000;
        var wait = new WaitForSeconds(time + 0.1f);

        for (int i = 0; i < count; i++)
            CoroutinesFactory.StartSuperFastCoroutine(this.Coroutine(time));
        yield return wait;
        Debug.Log("1");


        for (int i = 0; i < count; i++)
            CoroutinesFactory.StartCoroutine(this.Coroutine(time));
        yield return wait;
        Debug.Log("2");


        for (int i = 0; i < count; i++)
            this.StartCoroutine(this.Coroutine(time));
        yield return wait;
        Debug.Log("3");
        Application.Quit();
    }

    private IEnumerator Coroutine(float time)
    {
        var tempTime = Time.deltaTime + time;
        while (tempTime > Time.deltaTime)
            yield return null;
    }

    private IEnumerator Coroutine2(float time)
    {
        yield return new WaitWhile(() => Time.time < time);
    }
}
