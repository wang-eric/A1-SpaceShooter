using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;
    private Vector3 explosion_position;

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
		if (other.tag == "Boundary") {
			return;
		}
        explosion_position = new Vector3(transform.position.x, transform.position.y, transform.position.z-3);
		Instantiate (explosion, explosion_position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
            if (gameController.GetLife() <= 0) {
                Destroy(other.gameObject);
                gameController.GameOver();
            }
            else
            {
                
                other.transform.position = new Vector3(0, 0, 0);
                gameController.RemoveLife();
            }

        }
		if (other.tag != "Player"){
			gameController.AddScore (scoreValue);
            Destroy(other.gameObject);
        }
        Destroy(gameObject);

    }
}
