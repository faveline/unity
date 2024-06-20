using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
	public int			speed;
	public float		dist;
	private int			i_speed;
	public Rigidbody2D	bullet;

    void Start()
    {
        i_speed = speed;
    }

    void Update()
    {
		i_speed--;
        if (i_speed == 0) {
			shoot();
			i_speed = speed;
		}
    }

	void shoot() {
		Rigidbody2D	copy;

		copy = Instantiate(bullet, transform.position, transform.rotation);
		copy.AddForce(transform.rotation.eulerAngles * dist, ForceMode2D.Impulse);
	}
}
