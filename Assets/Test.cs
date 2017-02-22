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
		var time = 1;
		var count = 10000;
		var cubes = new List<GameObject>();
		for (int i = 0; i < count; i++)
			cubes.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

		yield return new WaitForSeconds(1);

		yield return cubes.
			Select(cube => cube.Move(GetRandomPosition(), time)).ToArray().Wait();

		yield return new WaitForSeconds(1);

		foreach (var cube in cubes)
			cube.Move(Vector3.zero, time, curve: Curves.BackIn);

		yield return new WaitForSeconds(time + 1);

		foreach (var cube in cubes)
			GameObject.Destroy(cube);
	}

	Vector3 GetRandomPosition()
	{
		return new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
	}

	void Update()
	{

	}
}
