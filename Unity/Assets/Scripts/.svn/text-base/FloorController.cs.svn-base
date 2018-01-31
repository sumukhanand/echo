using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour {
	
	public int switchNumber = -1;
	public GameObject gate;
	
	private bool activated = false;
	
	void Start () {
		if (switchNumber>0) {
			tag = "Switch";
		}
	}
	
	void Update () {
		if (switchNumber>0) {
			if (Occupied()) {
				if (!activated) {
					activated = true;
					gate.GetComponent<GateController>().activateSwitch(switchNumber);
				}
			}
			else if (activated) {
				activated = false;
				gate.GetComponent<GateController>().deactivateSwitch(switchNumber);
			}
		}
		//Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.01f);
		//Debug.DrawRay(position, new Vector3(0.0f, 0.0f, -1.0f));
	}
	
	public bool Occupied() {
		Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.01f);
		Ray ray = new Ray(position, new Vector3(0.0f, 0.0f, -1.0f));
		if (Physics.Raycast(ray, 1f)) {
			return true;
		} else {
			return false;
		}
	}
}
