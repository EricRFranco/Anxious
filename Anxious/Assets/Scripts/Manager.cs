﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	public void ChangeScene (int sceneIndex) {
		SceneManager.LoadScene (sceneIndex);
	}
}
