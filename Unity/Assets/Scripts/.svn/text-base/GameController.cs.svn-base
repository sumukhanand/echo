using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

	private GameObject currentPlayer;
	private CameraController camera;
	private CloneController clone;
	private AudioSource audioSource;
	//private AudioSource audioAction;
	public bool demoMode = false;
	public GameObject floor;
	private GameObject[] gameObjects;
	private List<Vector3> moveableV3 = new List<Vector3> ();
	private List<GameObject> moveableGO = new List<GameObject> ();
	private Vector3 playerStart;
	public Vector2 xRange;
	public Vector2 yRange;
	//private float sinFlux = 0f;
	private AudioClip menu;
	//private AudioClip action;

	public enum modeTypes
	{
		MENU,
		SETTINGS,
		SETUP,
		GAME,
		RESET,
		LEVELEND
	};
	public modeTypes mode;

	void Start ()
	{
		mode = modeTypes.SETUP;

		currentPlayer = GameObject.FindWithTag ("Player");
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraController> ();
		clone = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CloneController> ();
		
		if(GameObject.FindGameObjectWithTag("AudioManager") != null) {
			audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
			menu = Resources.Load("Music/echo_menu_track") as AudioClip;
			if (audioSource.clip == menu) {
				audioSource.Stop();
				audioSource.clip = Resources.Load("Music/echo_setup_track") as AudioClip;;
				audioSource.Play();
			}
		}
		
		for (int i=0; i<10; i++) {
			GenerateFloor(xRange.x-15, xRange.x-5, yRange.x-10, yRange.y+10);
			GenerateFloor(xRange.y+5, xRange.y+15, yRange.x-10, yRange.y+10);
			GenerateFloor(xRange.x-10, xRange.x+10, yRange.x-15, yRange.x-5);
			GenerateFloor(xRange.x-10, xRange.y+10, yRange.y+5, yRange.y+15);
		}
	}
	
	void Update()
	{
		currentPlayer = GameObject.FindWithTag ("Player");
		//sinFlux = (sinFlux+0.01f)%Mathf.PI;
		//GUI.color = new Color(1f - sinFlux/10f, 1f - sinFlux/10f, 1f - sinFlux/10f, 1f);
		//Debug.Log(GUI.color);
	}
	
	private void GenerateFloor(float minX, float maxX, float minY, float maxY)
	{
		float x = Random.Range(minX, maxX);
		float y = Random.Range(minY, maxY);
		float z = Random.Range(-10, 0);
		GameObject t = (GameObject)Instantiate(floor, new Vector3(x, y, z), Quaternion.AngleAxis(90f, new Vector3(1f, 0, 0)));
		t.gameObject.renderer.material.color = Color.gray;
	}

	public void SetPlayerPosition (Vector3 p)
	{
		playerStart = p;
	}

	public void KillPlayer (GameObject player)
	{
		if (player == currentPlayer) {
			mode = GameController.modeTypes.RESET;
			Transform t = (Transform)Instantiate (clone.clonePrefab, playerStart, Quaternion.identity);
			GameObject currPlayer = t.gameObject;
			currPlayer.tag = "Player";

			mode = GameController.modeTypes.SETUP;
			camera.following = false;
			camera.moveToTarget(t.gameObject);
			ResetLevel ();
		}
		Destroy (player);
	}

	public void RunGame ()
	{
		if (mode == GameController.modeTypes.SETUP) {
			gameObjects = GameObject.FindGameObjectsWithTag ("Moveable");
			foreach (GameObject go in gameObjects) {
				moveableGO.Add (go);
				moveableV3.Add (new Vector3 (go.transform.position.x, go.transform.position.y, go.transform.position.z));
			}
			GameObject[] gui = GameObject.FindGameObjectsWithTag ("Gui Base");
			for (int i=0; i<gui.Length; i++) {
				if (gui [i] != gameObject) {
					if (gui[i].GetComponent<GUIController>() != null) {
						gui [i].GetComponent<GUIController> ().isSelected = false;
					}
					gui[i].guiTexture.enabled = false;
				}
			}
			
			GameObject[] floors = GameObject.FindGameObjectsWithTag ("Floor");
			for (int i=0; i<floors.Length; i++) {
				MeshRenderer mesh = floors[i].transform.gameObject.GetComponent<MeshRenderer> ();
				if(mesh.material.color == Color.green) {
					mesh.material.color = Color.cyan;
				}
			}

			currentPlayer = GameObject.FindWithTag ("Player");
			currentPlayer.GetComponent<PlayerController> ().StartMotion ();
			camera.following = true;
			mode = GameController.modeTypes.GAME;

		}
	}

	public void StopGame ()
	{
		ResetLevel ();
		KillPlayer (currentPlayer);
	}

	public void ResetLevel ()
	{
		GameObject[] clones = GameObject.FindGameObjectsWithTag ("Clone");
			foreach (GameObject clone in clones) {
				Destroy(clone);
			}

		int i = 0;
		foreach (GameObject go in moveableGO) {
			Vector3 temp = moveableV3 [i];
 			go.active = true;
			go.transform.position = new Vector3 (temp.x, temp.y, temp.z);
			i++;
		}
		
		GameObject[] gui = GameObject.FindGameObjectsWithTag ("Gui Base");
		for (int j=0; j<gui.Length; j++) {
			gui[j].guiTexture.enabled = true;
		}
		
		moveableGO.Clear ();
		moveableV3.Clear ();
	}
	public GameObject getCurrentPlayer() {
		if (currentPlayer!=null) {
			return currentPlayer;
		}
		else {
			return null;
		}
	}
}