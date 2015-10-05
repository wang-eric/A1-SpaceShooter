using UnityEngine;
using System.Collections;

public class CrateCollider: MonoBehaviour {
	public int scoreValue=50;
	private GameController gameController;
	public GameObject audio;
    void Start (){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Hit");
		if (other.tag == "Boundary") {
			return;
		}

		if (other.tag == "Player") {
			Instantiate (audio, other.transform.position, other.transform.rotation);
            gameController.AddScore(scoreValue);
			Destroy(gameObject);
        }
    }
}
