using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class global : MonoBehaviour
{
	public int	pov;
	public int	end;
	Scene		scene;
	public int	nbr_scene;

	void Start() {
		scene = SceneManager.GetActiveScene();
	}

    void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			pov = 1;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			pov = 2;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			pov = 3;
		}
		if (Input.GetKeyDown(KeyCode.R))
			SceneManager.LoadScene(scene.buildIndex);
		if (end == 3) {
			Debug.Log("Well played!");
			if (scene.buildIndex + 1 == nbr_scene)
				SceneManager.LoadScene(0);
			else
				SceneManager.LoadScene(scene.buildIndex + 1);
		}
    }
}
