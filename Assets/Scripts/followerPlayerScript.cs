using UnityEngine;
using System.Collections;

public class followerPlayerScript : MonoBehaviour {

	Transform player;
	GameObject player_circle;
	GameObject vis;
	GUIText gtxt;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		player_circle = GameObject.FindGameObjectWithTag ("Player_Circle");
		vis = GameObject.FindGameObjectWithTag ("Player_Circle_Sprite");
		gtxt = GameObject.FindGameObjectWithTag ("text2").guiText;
	}
	
	// Update is called once per frame
	void Update () {
		float speed = 5f;
		if (player_circle.collider2D.OverlapPoint (transform.position))
		{
			gtxt.text = "ARRIVE";
			gtxt.color = Color.white;
			vis.renderer.enabled = true;
			speed = speed*.75f;
		}
		else{
			gtxt.text = "FOLLOW";
			gtxt.color = Color.green;
			vis.renderer.enabled = false;
		}
		transform.position = Vector3.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
		transform.LookAt (player);
		
	}

}
