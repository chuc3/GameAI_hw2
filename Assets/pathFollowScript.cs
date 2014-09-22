using UnityEngine;
using System.Collections;

public class pathFollowScript : MonoBehaviour {

	public GameObject path;
	Transform BL;
	Transform TL;
	Transform TR;
	Transform BR;

	int pos;

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


	}
}
