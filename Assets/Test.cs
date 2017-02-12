using System.Collections;
using System.Collections.Generic;
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

		foreach (var cube in cubes)
			cube.Move(GetRandomPosition(), time, curve: Curves.BackIn);

		yield return new WaitForSeconds(time + 1);

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
