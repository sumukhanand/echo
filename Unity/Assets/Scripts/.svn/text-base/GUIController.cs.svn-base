using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour
{

	public GameObject objectType;
	public int counter = -1;
	private GameController game;
	private CameraController camera;
	private GameObject[] ab;
	//public bool isDragging = false;
	public bool isSelected = false;
	private GameObject prevFloor;
	Color startColor;
	public KeyCode key;

	void Start ()
	{
		startColor = guiTexture.color;
		game = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraController> ();
	}

	void Update ()
	{
		if (Input.GetKeyDown(key)) {
			isSelected = true;

			GameObject[] gui = GameObject.FindGameObjectsWithTag ("Gui Base");
			for (int i=0; i<gui.Length; i++) {
				if (gui [i] != gameObject && gui[i].GetComponent<GUIController>() != null) {
					gui [i].GetComponent<GUIController> ().isSelected = false;
				}
			}
		}
		
		if (isSelected) {
			guiTexture.color = Color.green;
		} else if (!isSelected) {
			guiTexture.color = startColor;
		}
		if (counter == 0) {
			Destroy (gameObject);
		}
		/*if (game.mode == GameController.modeTypes.GAME) {
			if (gameObject.guiTexture.enabled) {
				gameObject.guiTexture.enabled = false;
			}
		} else if (game.mode == GameController.modeTypes.RESET || game.mode == GameController.modeTypes.SETUP) {
			if (!gameObject.guiTexture.enabled) {
				gameObject.guiTexture.enabled = true;
			}
		}*/

		if (isSelected) {

			//Move GUI object
			//transform.position = new Vector3(Input.mousePosition.x/Screen.width, Input.mousePosition.y/Screen.height, 0);

			//Highlight floortile via raycast
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit info;
			if (Physics.Raycast (ray, out info)) {
				if (info.transform.gameObject.tag == "Floor" && tag != "Delete" && !info.transform.gameObject.GetComponent<FloorController> ().Occupied () && Input.mousePosition.y > 80) {
					MeshRenderer mesh = info.transform.gameObject.GetComponent<MeshRenderer> ();
					mesh.material.color = Color.green;
					if (prevFloor != null && prevFloor != info.transform.gameObject) {
						mesh = prevFloor.GetComponent<MeshRenderer> ();
						mesh.material.color = Color.cyan;
					}
					prevFloor = info.transform.gameObject;
				} else if (prevFloor != null) {
					MeshRenderer mesh = prevFloor.GetComponent<MeshRenderer> ();
					mesh.material.color = Color.cyan;
					prevFloor = null;
				}
			}

			if (Input.GetMouseButtonUp (0)) {
				//Remove highlights (if any)
				if (prevFloor) {
					MeshRenderer mesh = prevFloor.GetComponent<MeshRenderer> ();
					mesh.material.color = Color.cyan;
					prevFloor = null;
				}

				//Create new object at intersection of raycast is collider object is "Floor" && is not occupied
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out info) && Input.mousePosition.y > 80) {
					if (info.transform.gameObject.tag == "Floor" && tag != "Delete" && !info.transform.gameObject.GetComponent<FloorController> ().Occupied ()) {
						GameObject go = (GameObject)Instantiate (objectType,
							new Vector3 (Mathf.Round (info.transform.position.x), Mathf.Round (info.transform.position.y), 0.0f),
							Quaternion.AngleAxis (90.0f, new Vector3 (1.0f, 0.0f, 0.0f))
						);

						go.AddComponent ("ArrowController");
						counter--;
					}
				}
			}
		}
	}

	void OnMouseDown ()
	{
		if (!isSelected) {
			//isDragging = true;
			isSelected = true;

			GameObject[] gui = GameObject.FindGameObjectsWithTag ("Gui Base");
			for (int i=0; i<gui.Length; i++) {
				if (gui [i] != gameObject) {
					if (gui [i].GetComponent<GUIController> () != null) {
						gui [i].GetComponent<GUIController> ().isSelected = false;
					}
				}
			}
		}
	}

	void OnMouseUp ()
	{
		/*if (isDragging) {

			//Reset
			//isDragging = false;
			transform.position = new Vector3(posX, posY, 0);

			//Remove highlights (if any)
			if (prevFloor) {
				MeshRenderer mesh = prevFloor.GetComponent<MeshRenderer>();
				mesh.material.color = Color.cyan;
				prevFloor = null;
			}

			/*if (prevDir) {
				MeshRenderer mesh = prevDir.GetComponent<MeshRenderer>();
				mesh.material.color = Color.white;
				prevDir = null;
			}*/

		//Create new object at intersection of raycast is collider object is "Floor" && is not occupied
		/*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit info;
			if (Physics.Raycast(ray,out info)) {
				if(info.transform.gameObject.tag=="Floor" && tag!="Delete" && !info.transform.gameObject.GetComponent<FloorController>().Occupied()) {
					GameObject go = (GameObject)Instantiate(objectType,
						new Vector3(Mathf.Round(info.point.x), Mathf.Round(info.point.y), 0.0f),
						Quaternion.AngleAxis(90.0f, new Vector3(1.0f, 0.0f, 0.0f))
					);

					go.AddComponent("ArrowController");
					counter--;
				}

				/*if(info.transform.gameObject.tag.Contains("Directional") && tag=="Delete") {
					Debug.Log("test");
					Destroy(info.transform.gameObject);
				}*/
		/*}
		}*/
	}
}