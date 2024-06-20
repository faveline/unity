using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doors : MonoBehaviour
{
	public int			open;
	public GameObject	door;
	public int			charac;

    void Start() {
		open = 0;
    }

	public void destroy_door() {

		Destroy(door.gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>());
		Destroy(door.GetComponent<BoxCollider2D>());
	}

	public void change_plat(int id) {
		if (id == 1) {
			door.gameObject.layer = 10;
			door.gameObject.transform.GetChild(0).gameObject.layer = 10;
			door.GetComponent<MeshRenderer>().material = Resources.Load<Material>("blue_t");
		}
		if (id == 2) {
			door.gameObject.layer = 11;
			door.gameObject.transform.GetChild(0).gameObject.layer = 11;
			door.GetComponent<MeshRenderer>().material = Resources.Load<Material>("yellow_t");
		}
		if (id == 3) {
			door.gameObject.layer = 12;
			door.gameObject.transform.GetChild(0).gameObject.layer = 12;
			door.GetComponent<MeshRenderer>().material = Resources.Load<Material>("red_t");
		}
	}
}
