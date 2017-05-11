using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : Spawner {

	[SerializeField]
	private GameObject [] cars;
	private float carSpawnTime = 3f;

	// Update is called once per frame
	void Update () {
		int carIndex = Random.Range (0, cars.Length - 1);
		carSpawnTime -= Time.deltaTime;
		if (carSpawnTime <= 0) {
			Spawn (cars [carIndex], transform.position);
			carSpawnTime = Random.Range (2f, 5f);
		}
	}
}
