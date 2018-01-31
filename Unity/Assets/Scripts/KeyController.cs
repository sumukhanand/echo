using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour
{
	
	private GameObject currentPlayer;
	private GameController game;
	private CameraController camera;
	private Vector3 camerap;
	private Quaternion camerar;
	private bool bGUI = true;
	//public GUISkin skin;
	//private Rect windowRect = new Rect (20, 20, 120, 50);
	//bool popUpActive = false;

	/*void OnGUI ()
	{
		GUI.skin = skin;
		windowRect = new Rect ((Screen.width - 240) / 2, (Screen.height - 120) / 2, 240, 120);
		//if (popUpActive) {
		//	windowRect = GUI.Window (0, windowRect, WindowFunction, "Really Quit?", GUI.skin.GetStyle ("window"));
		//}
	}*/

	/*void WindowFunction (int windowID)
	{
		// Draw any Controls inside the window here
		GUI.TextArea (new Rect (20, 40, 200, 40), "Are you sure you want to quit the game?");
		if (GUI.Button (new Rect (30, 80, 80, 20), "Cancel")) {
			popUpActive = false;
		}
		if (GUI.Button (new Rect (130, 80, 80, 20), "Quit")) {
			popUpActive = false;
			QuitGame ();
		}
	}*/
	
	// Use this for initialization
	void Start ()
	{
		currentPlayer = GameObject.FindWithTag ("Player"); 
		game = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentPlayer = GameObject.FindWithTag ("Player"); 
		if (currentPlayer) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				/*if (game.demoMode) {
					QuitGame ();
				} else {
					popUpActive = true;
				}*/
				Application.LoadLevel(0);
			}
			if (Input.GetKeyDown (KeyCode.Return) && game.mode == GameController.modeTypes.SETUP) {
				game.RunGame ();
			}
			else if (Input.GetKeyDown (KeyCode.Return) && game.mode == GameController.modeTypes.GAME) {
				game.StopGame ();
			}
			
			if (Input.GetKeyDown (KeyCode.Space) && game.mode == GameController.modeTypes.GAME){
				currentPlayer.GetComponent<PlayerController>().Jump();
			}
			
			/*if (Input.GetKeyDown(KeyCode.Q)) {
				camera.Rotate(90f);
			}
			
			if (Input.GetKeyDown(KeyCode.E)) {
				camera.Rotate(-90f);
			}
			
			if (Input.GetKeyDown(KeyCode.R)) {
				if (!camera.GetComponent<RotateCamera>().enabled) {
					camerap = camera.transform.position;
					camerar = camera.transform.rotation;
					//camera.GetComponent<CameraController>().enabled = false;
					camera.GetComponent<RotateCamera>().enabled = true;
				} else {
					camera.transform.position = camerap;
					camera.transform.rotation = camerar;
					//camera.GetComponent<CameraController>().enabled = true;
					camera.GetComponent<RotateCamera>().enabled = false;
				}
			}
			
			if (Input.GetKeyDown(KeyCode.T)) {
				if (bGUI) {
					GameObject[] gui = GameObject.FindGameObjectsWithTag ("Gui Base");
					for (int i=0; i<gui.Length; i++) {
						gui[i].guiTexture.enabled = false;
					}
					GameObject play = GameObject.FindGameObjectWithTag("PlayController");
					play.guiTexture.enabled = false;
					bGUI = false;
				}
				else {
					GameObject[] gui = GameObject.FindGameObjectsWithTag ("Gui Base");
					for (int i=0; i<gui.Length; i++) {
						gui[i].guiTexture.enabled = true;
					}
					GameObject play = GameObject.FindGameObjectWithTag("PlayController");
					play.guiTexture.enabled = true;
					bGUI = true;
				}
			}*/
		}
	}
	
	void QuitGame ()
	{
		Application.Quit ();
	}
}