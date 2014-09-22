using UnityEngine;
using System.Collections;

public class followerPlayerScript : MonoBehaviour {

	Transform player;
	GameObject player_circle;
	GameObject vis;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		player_circle = GameObject.FindGameObjectWithTag ("Player_Circle");
		vis = GameObject.FindGameObjectWithTag ("Player_Circle_Sprite");
	}
	
	// Update is called once per frame
	void Update () {
		float speed = .025f;
		if (player_circle.collider2D.OverlapPoint (transform.position))
		{
			vis.renderer.enabled = true;
			speed = .005f;
		}
		else{
			vis.renderer.enabled = false;
		}
		transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
		transform.LookAt (player);
		
	}

}
