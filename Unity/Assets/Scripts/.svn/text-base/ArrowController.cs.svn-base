using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour
{
	
	private Camera camera;
	
	void Start() {
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
	}
	
	void Update() {
		if (Input.GetMouseButtonDown (1)) {
			Debug.Log(Input.mousePosition);
			Debug.Log(camera.WorldToScreenPoint(transform.position));
			if (Mathf.Abs(camera.WorldToScreenPoint(transform.position).x - Input.mousePosition.x) < 5f
					|| Mathf.Abs(camera.WorldToScreenPoint(transform.position).y - Input.mousePosition.y) < 5f) {
				Destroy(gameObject);
			}
				
		}
	}
}