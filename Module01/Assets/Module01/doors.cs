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
		Destroy(door.GetComponent<BoxCollider2D>());
	}
}
