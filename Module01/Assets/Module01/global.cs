using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global : MonoBehaviour
{
	public int	pov;
	public int	end;

    // Update is called once per frame
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
		if (end == 3) {
			Debug.Log("Game Over.");
		}
    }
}
