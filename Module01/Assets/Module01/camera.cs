using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
	public GameObject	player1;
	public GameObject	player2;
	public GameObject	player3;
	Vector3				vect;
	public global		pov_camera;

    // Start is called before the first frame update
    void Start() {
		player1 = GameObject.Find("Claire");
		player2 = GameObject.Find("John");
		player3 = GameObject.Find("Thomas");
		vect = new Vector3(0, 2, -10);
    }

    // Update is called once per frame
    void LateUpdate() {
		if (pov_camera.pov == 1) {
			transform.position = player1.transform.position + vect;
		} else if (pov_camera.pov == 2) {
			transform.position = player2.transform.position + vect;
		} else if (pov_camera.pov == 3) {
			transform.position = player3.transform.position + vect;
		}
    }
}
