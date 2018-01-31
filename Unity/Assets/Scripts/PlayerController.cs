using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float jumpForce;
	public float moveForce;
	public float terminalX;
	public float terminalY;
	public float floorZ;
	
	private GameController game;
	private bool inAir = false;
		private bool collided = false;
	
	void Start () {
		floorZ = transform.position.z;
		game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		game.SetPlayerPosition(transform.position);
	}
	
	void Update () {
		if (rigidbody.velocity.x > terminalX) {
			rigidbody.velocity = new Vector3(terminalX, rigidbody.velocity.y, rigidbody.velocity.z);
		}
		if (rigidbody.velocity.x < -terminalX) {
			rigidbody.velocity = new Vector3(-terminalX, rigidbody.velocity.y, rigidbody.velocity.z);
		}
		
		if (rigidbody.velocity.y > terminalY) {
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, terminalY, rigidbody.velocity.z);
		}
		if (rigidbody.velocity.y < -terminalY) {
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, -terminalY, rigidbody.velocity.z);
		}
		
		if (transform.position.x > Mathf.Round(transform.position.x) && rigidbody.velocity.x == 0) {
			transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
		}
		if (transform.position.x > Mathf.Round(transform.position.x) && rigidbody.velocity.x == 0) {
			transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
		}
		if (transform.position.y > Mathf.Round(transform.position.y) && rigidbody.velocity.y == 0) {
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
		}
		if (transform.position.y < Mathf.Round(transform.position.y) && rigidbody.velocity.y == 0) {
			transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
		}
	}
	
	public void Jump(){
		if (!inAir && transform.position.z >=0) {
			rigidbody.AddForce(new Vector3(0, 0, jumpForce));
			inAir = true;
		}
	}
	
	public void StartMotion(){
		constantForce.force = new Vector3(0, moveForce, 0);
	}
	
	void OnTriggerStay(Collider collider) {
		if (game.mode == GameController.modeTypes.GAME && !inAir
				&& Mathf.Abs(transform.position.x - Mathf.Round(transform.position.x)) < 0.1f
				&& Mathf.Abs(transform.position.y - Mathf.Round(transform.position.y)) < 0.1f) {
	    	if (collider.gameObject.tag == "Directional Down") {
				rigidbody.angularVelocity = new Vector3(0, 0, 0);
			
				rigidbody.velocity = new Vector3(0, -terminalX, 0);
				//transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), transform.position.z);
				constantForce.force = new Vector3(0, -moveForce, 0);
	    	}
			if (collider.gameObject.tag == "Directional Right") {
				rigidbody.angularVelocity = new Vector3(0, 0, 0);
				rigidbody.velocity = new Vector3(-terminalX, 0, 0);
				//transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), transform.position.z);
				constantForce.force = new Vector3(-moveForce, 0, 0);
	    	}
			if (collider.gameObject.tag == "Directional Up") {
				if(!inAir ) {
				rigidbody.angularVelocity = new Vector3(0, 0, 0);
				}
				rigidbody.velocity = new Vector3(0, terminalX, 0);
				//transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), transform.position.z);
				constantForce.force = new Vector3(0, moveForce, 0);
	    	}
			if (collider.gameObject.tag == "Directional Left") {
				rigidbody.angularVelocity = new Vector3(0, 0, 0);
				rigidbody.velocity = new Vector3(terminalX, 0, 0);
				//transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), transform.position.z);
				constantForce.force = new Vector3(moveForce, 0, 0);
	    	}
		}
	}
	
	void OnTriggerEnter(Collider collider) {	
		if (collider.gameObject.tag == "Bounds") {
			game.KillPlayer(gameObject);
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		if (inAir && collision.gameObject.tag=="Floor"){
			inAir = false;
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
		}
	}
}
