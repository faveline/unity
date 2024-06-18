using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_obstacle : MonoBehaviour
{
	public Vector3	startPos;
	public Vector3	endPos;
	public float	speed;

	private Vector3	targetPos;

	void Start() {
		targetPos = endPos;
	}

	void Update() {
		Vector3 currentPos = transform.position;

		if (Vector3.Distance(currentPos, startPos) < 0.1) {
			targetPos = endPos;
		}
		else if (Vector3.Distance(currentPos, endPos) < 0.1) {
			targetPos = startPos;
		}
		Vector3 targetDirection = (targetPos - currentPos).normalized;
		transform.position += targetDirection * speed;
	}
}
