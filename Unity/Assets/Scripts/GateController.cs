using UnityEngine;
using System.Collections;

public class GateController : MonoBehaviour {
	
	public int totalSwitches = 0;
	
	private int activeSwitches = 0;
	private bool open = false;
	private GameController game;
	//public GUISkin skin;
	//private Rect windowRect = new Rect (20, 20, 120, 50);
	//bool popUpActive = false;

	/*void OnGUI ()
	{
		GUI.skin = skin;
		windowRect = new Rect ((Screen.width - 240) / 2, (Screen.height - 120) / 2, 240, 120);
		if (popUpActive) {
			windowRect = GUI.Window (0, windowRect, WindowFunction, "Level Complete", GUI.skin.GetStyle ("window"));
		}
	}

	void WindowFunction (int windowID)
	{
		// Draw any Controls inside the window here
		GUI.TextArea (new Rect (20, 40, 200, 40), "You beat this level! Onto the next one!");
		if (GUI.Button (new Rect (80, 80, 80, 20), "Okay")) {
			popUpActive = false;
			Application.LoadLevel(Application.loadedLevel+1);
		}
	}*/
	
	void Start () {
		game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	void Update () {
		if (activeSwitches == totalSwitches) {
			open = true;
			renderer.material.color = Color.green;
		}
		else {
			open = false;
			renderer.material.color = Color.red;
		}
	}
	
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag.Equals("Player") && open) {
			game.mode = GameController.modeTypes.LEVELEND;
			//popUpActive = true;
			Application.LoadLevel(Application.loadedLevel+1);
		}
		else if (collision.gameObject.tag.Equals("Player") && !open) {
			game.KillPlayer(collision.gameObject);
		}
		//Destroy(collision.gameObject);
		collision.gameObject.active = false;
	}
	
	public void activateSwitch (int switchNumber) {
		activeSwitches++;
	}
	
	public void deactivateSwitch (int switchNumber) {
		activeSwitches--;
	}
}
