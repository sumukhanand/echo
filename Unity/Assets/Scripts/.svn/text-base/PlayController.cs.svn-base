using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayController : MonoBehaviour
{

	private GameController game;
	//public GUISkin skin;
	//private Rect windowRect = new Rect (20, 20, 120, 50);
	//bool popUpActive = false;

	/*void OnGUI ()
	{
		GUI.skin = skin;
		windowRect = new Rect ((Screen.width - 240) / 2, (Screen.height - 120) / 2, 240, 120);
		if (popUpActive) {
			windowRect = GUI.Window (0, windowRect, WindowFunction, "Go to Build Mode?", GUI.skin.GetStyle ("window"));
		}
	}

	void WindowFunction (int windowID)
	{
		// Draw any Controls inside the window here
		GUI.TextArea (new Rect (20, 40, 200, 40), "Are you sure you want go back to build mode?");
		if (GUI.Button (new Rect (30, 80, 80, 20), "Cancel")) {
			popUpActive = false;
		}
		if (GUI.Button (new Rect (130, 80, 80, 20), "Go back")) {
			popUpActive = false;
			BackToSetup ();
		}
	}*/

	void Start ()
	{
		game = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}

	void Update ()
	{
		if (game.mode == GameController.modeTypes.GAME) {
			guiTexture.texture = (Texture)Resources.Load ("Textures/Stop");
		} else if (game.mode == GameController.modeTypes.SETUP) {
			guiTexture.texture = (Texture)Resources.Load ("Textures/Play");
		}
	}

	void OnMouseDown ()
	{
	}

	void OnMouseUp ()
	{
		if (game.mode == GameController.modeTypes.SETUP) {
			game.RunGame ();
			guiTexture.texture = (Texture)Resources.Load ("Textures/Stop");
		} else if (game.mode == GameController.modeTypes.GAME) {
			/*if (game.demoMode) {
				BackToSetup ();
			} else {
				popUpActive = true;
			}*/
			BackToSetup();
		}
	}

	void BackToSetup ()
	{
		game.StopGame ();
		guiTexture.texture = (Texture)Resources.Load ("Textures/Play");
	}
}