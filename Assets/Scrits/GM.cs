// Jamshed Ashurov 
// 03/15/18
// This is the game manager scritp that controls the lives, the transition between scenes, movememt of the ball and the paddle

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public int lives = 3; 
	public int bricks = 20;
	public float resetDelay = 1f; 
	public Text livesText; 
	public GameObject bricksPrefab; 
	public GameObject paddle; 
	public GameObject deathParticles; 
	public static GM instance = null;

	private GameObject clonePaddle; 

	// Use this for initialization
	void Start () {
		// This code is used to make sure that there is only one game manager. If there is more than one, it could mess up the game.
		// Therefore it says if there is no instance of the game manager use this one, but if there is another instance of the game manager it will destroy it. 
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject); 
		Setup (); 
	}

	public void Setup()
	{
		// This code sets up the paddle
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject; 
		Instantiate (bricksPrefab, transform.position, Quaternion.identity); 

	}

	void CheckGameover()
	{
		if (bricks < 1){
			//youWon.SetActive (true);
			//Time.timeScale = .25f; 
			//Invoke ("Reset", resetDelay);


			// Once the number of bricks is less than one, the code makes it so that you would go to the next scene right after the scene that you are on.
			// It is important to have correct order in the "Build Settings" 

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
			 
		}

		if (lives < 1) {
			//gameOver.SetActive (true); 
			//Time.timeScale = .25f; 
			//Invoke ("Reset", resetDelay);


			SceneManager.LoadScene("GameOver"); 
		}
	}

	//void Reset()
	//{
		//Time.timeScale = 1f; 
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	//}

	public void LoseLife()
	{ 
		// This code subtracts a live, destroys the paddle, and then creates the paddle again
		lives--; 
		livesText.text = "Lives: " + lives; 
		Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity); 
		Destroy (clonePaddle); 
		Invoke ("SetupPaddle", resetDelay); 
		CheckGameover (); 
	}

	void SetupPaddle()
	{
		// creates the paddle 
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity); 

	}

	public void DestroyBrick()
	{
		// Subtracts the number of bricks and checks the gameover function 
		bricks--;  
		CheckGameover (); 
	}

}
