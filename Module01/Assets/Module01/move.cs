using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
	public float		speed;
	public global		pov_player;
	public int			id_player;
	public int			jump;
	Rigidbody2D			rb;
	private bool		isGrounded;
	private bool		isSurface;
	public GameObject	endObject;
	public string		ending;

    void Start()
    {
		endObject = GameObject.Find(ending);
		endObject.SetActive(false);
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
		if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || isSurface)) {
			rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
			isGrounded = false;
			isSurface = false;
		}
    }

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.CompareTag("ground")){
			isGrounded = true;
		}
 	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("surface")){
			isSurface = true;
		}
		if(other.gameObject.CompareTag(ending)){
			pov_player.end += 1;
			endObject.SetActive(true);
		}
 	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.CompareTag("surface") && id_player == pov_player.pov){
			isSurface = false;
		}
		if(other.gameObject.CompareTag(ending)){
			pov_player.end -= 1;
			endObject.SetActive(false);
		}
 	}
}
