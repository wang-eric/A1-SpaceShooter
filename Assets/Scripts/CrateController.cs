using UnityEngine;
using System.Collections;

public class CrateController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public float speed;

	// Use this for initialization
	void Start () {
		//this._Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.z -= speed;
		gameObject.GetComponent<Transform> ().position = currentPosition;

		// Check bottom boundary
		if (currentPosition.z <= -6) {
			this._Reset();
		}
	}

	private void _Reset() {
		Vector3 resetPosition = new Vector3 (0, 0, 24);
		gameObject.GetComponent<Transform> ().position = resetPosition;
	}
}
