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
		Debug.Log ("Hit");
		if (other.tag == "Boundary") {
			return;
		}
        explosion_position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		Instantiate (explosion, explosion_position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.RemoveLife();
            if (gameController.GetLife() == 0) {
                Destroy(other.gameObject);
                gameController.GameOver();
            }
            else
            {
				//StartCoroutine(Invicible(other));
				other.transform.position = new Vector3(0, 0, 0);
            }

        }
		if (other.tag != "Player"){
			gameController.AddScore (scoreValue);
            Destroy(other.gameObject);
        }
        Destroy(gameObject);

    }
	/* For the invincible time after getting hit
	IEnumerator Invicible(Collider other)
	{
		Debug.Log ("Activate function");
		yield return new WaitForSeconds(3);
		Debug.Log ("Wait for seconds");
		other.GetComponent<Collider>().enabled = false;
		Debug.Log ("Collider Off!");
		other.transform.position = new Vector3(0, 0, 0);
		Debug.Log ("Reset position!");
		yield return new WaitForSeconds(3);
		Debug.Log ("Wait for seconds");
		other.GetComponent<Collider>().enabled = true;
		Debug.Log ("Collider On!!");
	}
	//*/
}
