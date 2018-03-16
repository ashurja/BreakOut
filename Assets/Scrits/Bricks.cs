// Jamshed Ashurov 
// 03/15/18
// This is the script that destroys the bricks 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

	public GameObject brickParticle; 

	void OnCollisionEnter (Collision other)
	{
		// When something collides with the brick, it destroys it 
		Instantiate (brickParticle, transform.position, Quaternion.identity); 
		GM.instance.DestroyBrick ();
		Destroy (gameObject); 
	}
}
