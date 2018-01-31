using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour
{
	
	public Transform target;
	private GameController game;
		private Vector3 velocity = Vector3.zero;
	
	// Use this for initialization
	void Start ()
	{
		game = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(game.mode != GameController.modeTypes.RESET) {
			if (game.getCurrentPlayer()!=null) {
				target = game.getCurrentPlayer ().transform;
				if (target != null) {
					if (game.mode != GameController.modeTypes.LEVELEND) {
						transform.RotateAround (target.transform.position, Vector3.forward, 10 * Time.deltaTime);
						Vector3 destination = target.position;
						transform.position = Vector3.SmoothDamp (destination, transform.position, ref velocity, 1000.0f);
						transform.position -= transform.rotation * Vector3.forward * 10;
					}
				}
			}
		}
	}
}
