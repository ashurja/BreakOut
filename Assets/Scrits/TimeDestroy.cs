// Jamshed Ashurov 
// 03/16/18
// This is the script that destroys the objects 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour {

	public float destroyTime = 1f; 

	void Start () {
		// The script destroys the object after a second(used to destroy the instance of the bricks once they are destroyed by the ball) 
		Destroy (gameObject, destroyTime); 
	}

}
