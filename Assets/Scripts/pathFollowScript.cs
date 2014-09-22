using UnityEngine;
using System.Collections;

public class pathFollowScript : MonoBehaviour {

	public GameObject path;
	Transform BL;
	Transform TL;
	Transform TR;
	Transform BR;

	int pos;
	float speed = 10f;

	// Use this for initialization
	void Start () {
		BL = path.transform.GetChild (0);
		TL = path.transform.GetChild (1);
		TR = path.transform.GetChild (2);
		BR = path.transform.GetChild (3);

	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position==BL.position)
		{
			pos = 0;
		}
		else if(transform.position==TL.position)
		{
			pos = 1;
		}
		else if(transform.position==TR.position)
		{
			pos = 2;
		}
		else if(transform.position==BR.position)
		{
			pos = 3;
		}

		moveTo(pos);

	}
	void moveTo (int pos)
	{
		switch(pos)
		{
			case 0:
				transform.position = Vector3.MoveTowards(transform.position, TL.position, speed*Time.deltaTime);
			transform.rotation = Quaternion.LookRotation(Vector3.up);
				break;
			case 1:
				transform.position = Vector3.MoveTowards(transform.position, TR.position, speed*Time.deltaTime);
				transform.LookAt(TR.position);
				break;
			case 2:
				transform.position = Vector3.MoveTowards(transform.position, BR.position, speed*Time.deltaTime);
				transform.LookAt(BR.position);
				break;
			case 3:
				transform.position = Vector3.MoveTowards(transform.position, BL.position, speed*Time.deltaTime);
				transform.LookAt(BL.position); 
				break;
		}

	}
}
