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
	public string		ignore_col;
	private int			tp;

    void Start()
    {
		endObject = GameObject.Find(ending);
		endObject.SetActive(false);
		rb = GetComponent<Rigidbody2D>();
		tp = 0;
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
		if (tp != 0)
			tp--;
    }

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.CompareTag("ground")){
			isGrounded = true;
		}
 	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer == 16 && (other.gameObject.CompareTag("white") || other.gameObject.tag == gameObject.tag)) {
			if (pov_player.pov != 4)
				Debug.Log("Game over !");
			pov_player.pov = 4;	
		}
		if (other.gameObject.CompareTag("surface")){
			isSurface = true;
		}
		if (other.gameObject.CompareTag(ending)){
			pov_player.end += 1;
			endObject.SetActive(true);
		}
		if (other.gameObject.layer == 13 && tp == 0) {
			tp = 30;
			tp_ini tmp = other.gameObject.GetComponent<tp_ini>();
			transform.position = tmp.dest;
		}
		if (other.gameObject.CompareTag("platform")) {
			isSurface = true;
			transform.parent = other.transform;
		}
		if (other.gameObject.layer == 14) {
			doors tmp = other.gameObject.GetComponent<doors>();
			if (other.gameObject.CompareTag("white")) {
				other.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
				other.gameObject.tag = gameObject.tag;
			}
			if (tmp.door.CompareTag("platform")) {
				tmp.change_plat(id_player);
			} else if (other.gameObject.tag == gameObject.tag && other.gameObject.tag == tmp.door.gameObject.tag) {
				tmp.open++;
				tmp.door.transform.position += Vector3.forward;
				if (tmp.open == 3)
					tmp.destroy_door();
				if (tmp.open == 5)
					other.gameObject.SetActive(false);
			}
		}
 	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag("surface")) {
			isSurface = true;
		}
		if (other.gameObject.CompareTag("platform")) {
			isSurface = true;
			transform.parent = other.transform;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.CompareTag("surface")){
			isSurface = false;
		}
		if(other.gameObject.CompareTag(ending)){
			pov_player.end -= 1;
			endObject.SetActive(false);
		}
		if(other.gameObject.CompareTag("platform")){
			isSurface = false;
			transform.parent = null;	
		}
 	}
}
