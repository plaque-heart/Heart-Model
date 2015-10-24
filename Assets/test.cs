using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO; 

public class test : MonoBehaviour {

	public float speed = 12f;
	float mySpeed =0;
	Camera cam;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Input.GetKeyDown(KeyCode.F ))
			mySpeed += speed;
		if (Input.GetKeyDown (KeyCode.B) )
			mySpeed -= speed;
		if (Input.GetKeyDown (KeyCode.Alpha0) ) {
			//print ("whatever");
			mySpeed = 0;
		}
		//		if (Input.GetAxis("Vertical") > 0)
		//		{
		//			transform.Translate(0f,0f,0.1f);
		//		}
		GetComponent<Rigidbody>().AddForce (Input.GetAxis("Vertical") * speed * transform.forward);
		//transform.Rotate (Vector3.up * Time.deltaTime * Input.GetAxis("Vertical"));
		//transform.Rotate (Input.GetAxis("Vertical"),0,0);
		//transform.Rotate (0,Input.GetAxis("Horizontal"),0);
		GetComponent<Rigidbody>().velocity= (mySpeed * transform.forward);
	}
}
