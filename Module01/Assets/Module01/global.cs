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
	public int	wait_death;

	void Start() {
		scene = SceneManager.GetActiveScene();
	}

    void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha1) && pov != 4) {
			pov = 1;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2) && pov != 4) {
			pov = 2;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3) && pov != 4) {
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
		if (pov == 4) {
			wait_death--;
			if (wait_death == 0)
				SceneManager.LoadScene(scene.buildIndex);	
		}
		if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }
}
