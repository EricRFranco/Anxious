﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public void Spawn (GameObject go, Vector3 spawnPoint) {
		Instantiate (go, spawnPoint, Quaternion.identity);
	}
}
