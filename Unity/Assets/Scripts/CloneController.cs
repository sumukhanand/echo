using UnityEngine;
using System.Collections;

public class CloneController : MonoBehaviour {
	
	public Transform clonePrefab;
	public Vector2 clonePoint;
	
	private GameObject currentPlayer;
	private GameController game;
	private float endTime;
	private int timeLeft = 0;
	
	void Start () {
		currentPlayer = GameObject.FindGameObjectWithTag("Player");
		game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.C) && clonePrefab && game.mode == GameController.modeTypes.GAME && timeLeft == 0) {
			currentPlayer = GameObject.FindGameObjectWithTag("Player");
			endTime = Time.time + 1;
			currentPlayer.tag = "Clone";
			
			Transform t = (Transform) Instantiate(clonePrefab, new Vector3(clonePoint.x, clonePoint.y, 0.45f), Quaternion.identity);
			currentPlayer = t.gameObject;
			currentPlayer.tag = "Player";
			currentPlayer.GetComponent<PlayerController>().StartMotion();
		}
		
		timeLeft = (int)endTime - (int)Time.time;
    	if (timeLeft < 0) {
			timeLeft = 0;
		}
	}
}
