using UnityEngine;
using System.Collections;

public class ResetController : MonoBehaviour
{
	private GameController game;
	//public GUISkin skin;
	//private Rect windowRect = new Rect (20, 20, 120, 50);
	//bool popUpActive = false;

	void OnGUI ()
	{
		/*GUI.skin = skin;
		windowRect = new Rect ((Screen.width - 240) / 2, (Screen.height - 120) / 2, 240, 120);
		if (popUpActive) {
			windowRect = GUI.Window (0, windowRect, WindowFunction, "Really Delete?", GUI.skin.GetStyle ("window"));
		}*/
	}

	/*void WindowFunction (int windowID)
	{
		// Draw any Controls inside the window here
		GUI.TextArea (new Rect (20, 40, 200, 40), "Are you sure you want to delete all arrows you placed?");
		if (GUI.Button (new Rect (30, 80, 80, 20), "Cancel")) {
			popUpActive = false;
		}
		if (GUI.Button (new Rect (130, 80, 80, 20), "Delete")) {
			popUpActive = false;
			deleteAll ();
		}
	}*/

	void Start ()
	{
		game = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}

	void OnMouseDown ()
	{
		//left click
		if (Input.GetMouseButtonDown (0)) {
			/*if (game.demoMode) {
				deleteAll ();
			} else {
				popUpActive = true;
			}*/
			deleteAll();
			GameObject[] gui = GameObject.FindGameObjectsWithTag ("Gui Base");
			for (int i=0; i<gui.Length; i++) {
				if (gui [i] != gameObject) {
					//gui [i].GetComponent<GUIController> ().isDragging = false;
					gui [i].GetComponent<GUIController> ().isSelected = false;
				}
			}
		}
	}

	void Update ()
	{
		/*if (game.mode == GameController.modeTypes.GAME) {
			if (gameObject.guiTexture.enabled) {
				gameObject.guiTexture.enabled = false;
			}
		} else if (game.mode == GameController.modeTypes.RESET || game.mode == GameController.modeTypes.SETUP) {
			if (!gameObject.guiTexture.enabled) {
				gameObject.guiTexture.enabled = true;
			}
		}*/
	}

	void deleteAll ()
	{
		GameObject[] gos = GameObject.FindGameObjectsWithTag ("Directional Down");
		foreach (GameObject g in gos) {
			Destroy (g);
		}
		gos = GameObject.FindGameObjectsWithTag ("Directional Up");
		foreach (GameObject g in gos) {
			Destroy (g);
		}
		gos = GameObject.FindGameObjectsWithTag ("Directional Left");
		foreach (GameObject g in gos) {
			Destroy (g);
		}
		gos = GameObject.FindGameObjectsWithTag ("Directional Right");
		foreach (GameObject g in gos) {
			Destroy (g);
		}
	}
}