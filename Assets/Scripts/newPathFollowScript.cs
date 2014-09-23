using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class newPathFollowScript : MonoBehaviour {

	public GameObject path;
	List<Transform> pts = new List<Transform>();
	int size;
	int next = 0;
	float speed = 5f;
	// Use this for initialization
	void Start () {
		size = 0;
		foreach (Transform child in path.transform)
		{
			pts.Add (child.transform);
			size++;
		}
		print (size);
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.MoveTowards (transform.position,pts[next].position,speed*Time.deltaTime);
		//transform.LookAt (pts [next].position);
		//transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 2);
		Vector3 moveDirection = pts[next].transform.position - gameObject.transform.position;
		if (moveDirection != Vector3.zero)
		{
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 10);
		}
		if (transform.position == pts [next].position)
		{
			next = (next + 1)%size;
			print (next);
		}
		
	}
}
