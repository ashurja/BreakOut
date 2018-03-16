// Jamshed Ashurov 
// 03/15/18
// This is the script that loads the "Main" scene and quits the application 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelManager : MonoBehaviour {

	public void StartGame()
	{
		SceneManager.LoadScene ("Main"); 

	}

	public void QuitGame()
	{
		Application.Quit (); 
	}
}
