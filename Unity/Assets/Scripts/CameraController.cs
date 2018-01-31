using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public float dampTime = 0.3f; 				//offset from the viewport center to fix damping
	public float offsetY;
	public float offsetX;
	public float mouseDelta = 3f;
	public float sensitivity = 40f;
	public float fov = 25f;
	public int fovMax = 50;
	public bool following = false;
	public int minX;
	public int maxX;
	public int minY;
	public int maxY;
	private GameObject target;
	private Vector3 velocity = Vector3.zero;
	private Vector3 start;
	private Vector3 dest;
	private bool moveto = false;
	private float angle = 0f;
	public bool rotating;
	private GameController game;

	void Start ()
	{
		game = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		target = GameObject.FindGameObjectWithTag ("Player");
		moveToTarget(target);
		Vector3 destination = target.transform.position;
		transform.position = Vector3.SmoothDamp (destination, transform.position, ref velocity, 1000.0f);
		transform.position -= transform.rotation * Vector3.forward * 15;
	}
	
	public void moveTo(Vector3 pos)
	{
		dest = pos;
		moveto = true;
	}
	
	public void moveToTarget(GameObject o)
	{
		Vector3 point = camera.WorldToViewportPoint (o.transform.position);
		Vector3 delta = o.transform.position - camera.ViewportToWorldPoint (new Vector3 (offsetX, offsetY, point.z));
		moveTo(transform.position + delta);
		fov = fovMax;
	}
	
	public void Rotate(float a)
	{
		moveto = false;
		target = GameObject.FindGameObjectWithTag ("Player");
		transform.RotateAround(target.transform.position, new Vector3(0f, 0f, 1f), a);
		Vector3 destination = target.transform.position;
		transform.position = Vector3.SmoothDamp (destination, transform.position, ref velocity, 1000.0f);
		transform.position -= transform.rotation * Vector3.forward * 15;
		angle = (angle-a)%360;
	}

	void Update ()
	{
		target = GameObject.FindGameObjectWithTag ("Player");
		if (moveto){
			transform.position = Vector3.SmoothDamp(transform.position, dest, ref velocity, dampTime);
			if (Mathf.Abs(transform.position.x - dest.x)<0.1 && Mathf.Abs(transform.position.y - dest.y)<0.1) {
				moveto = false;
			}
		}
		
		if (camera.fieldOfView < fov) {
			camera.fieldOfView++;
		} else if (camera.fieldOfView > fov) {
			camera.fieldOfView--;
		}
		
		/*if (rotating && game.mode != GameController.modeTypes.LEVELEND && target!=null) {
			transform.RotateAround (target.transform.position, Vector3.forward, 10 * Time.deltaTime);
			Vector3 destination = target.transform.position;
			transform.position = Vector3.SmoothDamp (destination, transform.position, ref velocity, 1000.0f);
			transform.position -= transform.rotation * Vector3.forward * 10;
		}*/
		
		if (following) {

			//Follow camera script
			target = GameObject.FindGameObjectWithTag ("Player");
			fov = 25f;
			if (target) {
				Vector3 point = camera.WorldToViewportPoint (target.transform.position);
				Vector3 delta = target.transform.position - camera.ViewportToWorldPoint (new Vector3 (offsetX, offsetY, point.z));
				Vector3 destination = transform.position + delta;
				transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
			}
		} else {
			
			moveto = false;

			//Move camera at border
			//if (Input.mousePosition.x < sensitivity && Input.mousePosition.x > 0) {
			if (Input.GetKey ("a")){// && transform.position.x < maxX) {
				Vector3 destination = transform.position + Quaternion.AngleAxis(angle, Vector3.back)*new Vector3 (mouseDelta, 0, 0);
				transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
			}
			//if (Input.mousePosition.y < sensitivity  && Input.mousePosition.y > 0) {
			if (Input.GetKey ("s")){// && transform.position.y > minY) {
				Vector3 destination = transform.position + Quaternion.AngleAxis(angle, Vector3.back)*new Vector3 (0, -mouseDelta, 0);
				transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
			}
			//if ((Screen.width - Input.mousePosition.x) < sensitivity && Input.mousePosition.x < Screen.width) {
			if (Input.GetKey ("d")){// && transform.position.x > minX) {
				Vector3 destination = transform.position + Quaternion.AngleAxis(angle, Vector3.back)*new Vector3 (-mouseDelta, 0, 0);
				transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
			}
			//if ((Screen.height - Input.mousePosition.y) < sensitivity && Input.mousePosition.y < Screen.height) {
			if (Input.GetKey ("w")){// && transform.position.y < maxY) {
				Vector3 destination = transform.position + Quaternion.AngleAxis(angle, Vector3.back)*new Vector3 (0, mouseDelta, 0);
				transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
			}

			//Scroll zoom
			if (Input.GetAxis ("Mouse ScrollWheel") > 0 && camera.fieldOfView < fovMax) {
				fov++;
			} else if (Input.GetAxis ("Mouse ScrollWheel") < 0 && camera.fieldOfView > 10) {
				fov--;
			}
		}
	}
}