using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	int		jump;
	float	speed_h;
	float	speed_v;
	public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        jump = 0;
		speed_h = 0.1f;
		speed_v = 0.05f;
		rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		if (jump == 0 && Input.GetKeyDown(KeyCode.Space))
			jump = 1;
		if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
			rb.velocity += Vector3.forward * speed_h;
		if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			rb.velocity += Vector3.left * speed_h;
		if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
			rb.velocity += Vector3.right * speed_h;
		if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
			rb.velocity += Vector3.back * speed_h;
		if (jump > 0) {
			jump++;
			transform.position += Vector3.up * speed_v;
			if (jump == 30)
				jump = -1;
		}
		else if (jump < 0) {
			jump--;
			if (jump == -30)
				jump = 0;
		}

    }

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor")) {
            Debug.Log("Game over !");
			Destroy(gameObject);
		}
        else if (other.gameObject.CompareTag("Ending"))
            Debug.Log("Well played !");
	}
}
