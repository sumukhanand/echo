using UnityEngine;
using System.Collections;

public class QuitButtonController : MonoBehaviour
{

	//public GUISkin skin;
	//private Rect windowRect = new Rect (20, 20, 120, 50);
	//bool popUpActive = false;

	/*void OnGUI ()
	{
		GUI.skin = skin;
		windowRect = new Rect ((Screen.width - 240) / 2, (Screen.height - 120) / 2, 240, 120);
		if (popUpActive) {
			windowRect = GUI.Window (0, windowRect, WindowFunction, "Really Quit?", GUI.skin.GetStyle ("window"));
		}
	}

	void WindowFunction (int windowID)
	{
		// Draw any Controls inside the window here
		GUI.TextArea (new Rect (20, 40, 200, 40), "Are you sure you want to quit the game?");
		if (GUI.Button (new Rect (30, 80, 80, 20), "Cancel")) {
			popUpActive = false;
		}
		if (GUI.Button (new Rect (130, 80, 80, 20), "Quit Game")) {
			popUpActive = false;
			QuitGame ();
		}
	}*/
	 
	void OnMouseDown ()
	{
		//left click
	//	if (Input.GetMouseButtonDown (0)) {
	//		popUpActive = true;
	//	}
		QuitGame();
	}

	void QuitGame ()
	{
		Application.Quit ();
	}
}