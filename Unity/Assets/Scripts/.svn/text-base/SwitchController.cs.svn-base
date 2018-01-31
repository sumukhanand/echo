using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {
	
	public int switchNumber = -1;
	public GameObject gate;
	
	private bool open = false;
	
	void Start () {
		renderer.material.color = Color.red;
	}
	
	void Update () {
		if (switchNumber>=0 && gate!=null) {
			if (Occupied()) {
				if (!open) {
					open = true;
					renderer.material.color = Color.green;
					gate.GetComponent<GateController>().activateSwitch(switchNumber);
				}
			}
			else if (open) {
				open = false;
				renderer.material.color = Color.red;
				gate.GetComponent<GateController>().deactivateSwitch(switchNumber);
			}
		}
	}
	
	public bool Occupied() {
		Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.1f);
		Ray ray = new Ray(position, new Vector3(0.0f, 0.0f, -1.0f));
		if (Physics.Raycast(ray, 1f)) {
			return true;
		} else {
			return false;
		}
	}
}
