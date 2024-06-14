using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
	public float		speed;
	public global		pov_player;
	public int			id_player;
	public int			jump;
	float				dist_ray;
	Rigidbody2D			rb;

    void Start()
    {
		dist_ray = 0.05f;
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if (id_player != pov_player.pov)
			return ;
		if (Input.GetKey(KeyCode.A)) {
			transform.position += Vector3.left * speed;
		}
		if (Input.GetKey(KeyCode.D)) {
			transform.position += Vector3.right * speed;
		}
		if (Input.GetKeyDown(KeyCode.Space) && Physics2D.Raycast(transform.position - Vector3.down, Vector2.down, dist_ray)) {
			rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
		}
    }
}
