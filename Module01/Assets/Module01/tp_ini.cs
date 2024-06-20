using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tp_ini : MonoBehaviour
{
	public Vector3	dest;
	public string	tp;

	void Start() {
		dest = GameObject.FindGameObjectsWithTag(tp)[0].transform.position;
	}

	public Vector3	getter() {
		return (dest);
	}
}
