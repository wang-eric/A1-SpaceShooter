﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
    public GameObject player;
    public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
    public GUIText lifeText;
    public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
    private int score;
    private int life;

	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
        life = 5;
		UpdateScore ();
        UpdateLife();
		StartCoroutine (SpawnWaves ());
	}

	void Update()
	{
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i<hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver){
				restartText.text = "Press 'R' to Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

    public int GetLife()
    {
        return life;
    }

    public void RemoveLife()
    {
        life -= 1;
        UpdateLife();
    }

    void UpdateLife()
    {
        lifeText.text = "Life: " + life;
    }

    public void GameOver()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
