using UnityEngine;
using System.Collections;

public class MoveableController : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -100, 0.35f));
		
		//Snap to grid
		if (rigidbody.velocity.magnitude < 0.05f) {
			if (transform.position.x < Mathf.Round(transform.position.x)) {
				transform.position = new Vector3(transform.position.x+0.01f, transform.position.y, transform.position.z);
			}
			if (transform.position.x > Mathf.Round(transform.position.x)) {
				transform.position = new Vector3(transform.position.x-0.01f, transform.position.y, transform.position.z);
			}
			if (transform.position.y < Mathf.Round(transform.position.y)) {
				transform.position = new Vector3(transform.position.x, transform.position.y+0.01f, transform.position.z);
			}
			if (transform.position.y > Mathf.Round(transform.position.y)) {
				transform.position = new Vector3(transform.position.x, transform.position.y-0.01f, transform.position.z);
			}
		}
	}	
	
	void OnCollisionExit(Collision collision) {
		rigidbody.velocity = new Vector3(0, 0, rigidbody.velocity.z);
	}
	
	void OnTriggerEnter(Collider collider) {
    	if (collider.gameObject.tag == "Bounds") {
			gameObject.active = false;
		}
	}
}
