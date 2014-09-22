using UnityEngine;
using System.Collections;

public class EvadePlayerScript : MonoBehaviour {

	Transform player;
	GameObject thePlayer;
	GameObject playerFov;
	GameObject wanderPoint;

	// Use this for initialization
	Vector3 wanderPos;
	bool wasEvading;
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerFov = GameObject.FindGameObjectWithTag ("Player_FOV");
		thePlayer = GameObject.FindGameObjectWithTag ("Player");
		wanderPoint = GameObject.FindGameObjectWithTag ("Wander_point");

		wanderPos = new Vector3 (0f, 0f, 0f);
		wasEvading = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (playerFov.collider2D.OverlapPoint (transform.position)) {
			evade ();
			wasEvading = true;
		}
		else {
			rigidbody2D.velocity = Vector3.zero ;
			wander();
			wasEvading = false;
		}
	}

	void evade()
	{
		rigidbody2D.velocity = player.rigidbody2D.velocity*1.25f;
		if (thePlayer.rigidbody2D.velocity == Vector2.zero)
						wander ();
	}
	void wander()
	{
		// pick random point
		if(transform.position != wanderPos && !wasEvading)
		{
			transform.position = Vector3.MoveTowards(transform.position, wanderPos, .1f);
		}
		else
		{
			GameObject[] temp = GameObject.FindGameObjectsWithTag("Wander_point");
			for (int i = 1; i<temp.Length;i++)Destroy (temp[i]);
			wanderPos = new Vector3(Random.Range(-50f,50f),Random.Range(-25f,25f),0f);
			Instantiate(wanderPoint,wanderPos,Quaternion.identity);
		}
		transform.LookAt (wanderPos);
		 
	}
}
