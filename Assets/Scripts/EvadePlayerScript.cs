using UnityEngine;
using System.Collections;

public class EvadePlayerScript : MonoBehaviour {

	Transform player;
	GameObject thePlayer;
	GameObject playerFov;
	GameObject wanderPoint;
	float curr_time;
	float last_time;
	bool time_up;
	GUIText gtxt;
	float speed = 5f;

	// Use this for initialization
	Vector3 wanderPos;
	bool wasEvading;
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerFov = GameObject.FindGameObjectWithTag ("Player_Circle");
		thePlayer = GameObject.FindGameObjectWithTag ("Player");
		wanderPoint = GameObject.FindGameObjectWithTag ("Wander_point");
		gtxt = GameObject.FindGameObjectWithTag ("text1").guiText;

		wanderPos = new Vector3 (0f, 0f, 0f);
		wasEvading = false;
		curr_time = 0f;
		last_time = 0f;
		time_up = false;
	}
	
	// Update is called once per frame
	void Update () {
		last_time = curr_time;
		curr_time = last_time + Time.deltaTime;

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

		gtxt.text = "EVADE";
		gtxt.color = Color.cyan;
		Vector2 frce = new Vector2(transform.position.x - thePlayer.transform.position.x, transform.position.y - thePlayer.transform.position.y);
		rigidbody2D.AddForce (frce);

		Quaternion rot = thePlayer.transform.rotation;
		transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 2);
	}
	void wander()
	{
		if (curr_time >= 2.5f)
		{
			time_up = true;
			curr_time  =0f;
			last_time = 0f;
		}
		else
		{
			time_up = false;
		}

		gtxt.text = "WANDER";
		gtxt.color = Color.red;

		// pick random point
		if(transform.position != wanderPos && !wasEvading && !time_up)
		{
			transform.position = Vector3.MoveTowards(transform.position, wanderPos, speed*Time.deltaTime);
		}
		else
		{
			GameObject[] temp = GameObject.FindGameObjectsWithTag("Wander_point");
			for (int i = 1; i<temp.Length;i++)Destroy (temp[i]);
			wanderPos = new Vector3(Random.Range(-50f,50f),Random.Range(-25f,25f),-1f);
			Instantiate(wanderPoint,wanderPos,Quaternion.identity);
		}
		// change this
		//transform.LookAt (wanderPos);
		print (wanderPos);
		/*
		Quaternion rot = Quaternion.LookRotation (wanderPos);
		transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 2);
		*/
		Vector3 moveDirection = wanderPos - gameObject.transform.position;
		if (moveDirection != Vector3.zero)
		{
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 2);
		}

	}
}
