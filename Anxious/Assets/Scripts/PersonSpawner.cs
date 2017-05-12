using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : Spawner {

	[SerializeField]
	private GameObject [] people;
	private float _personSpawnTime;

	void Awake () {
		_personSpawnTime = Random.Range (1f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		int personIndex = Random.Range (0, people.Length);
		_personSpawnTime -= Time.deltaTime;
		if (_personSpawnTime <= 0) {
			Spawn (people [personIndex], transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0));
			_personSpawnTime = Random.Range (1f, 5f);
		}
	}
}
