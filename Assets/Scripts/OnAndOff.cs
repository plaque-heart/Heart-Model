using UnityEngine;
using System.Collections;

public class OnAndOff : MonoBehaviour {

	private Renderer rend;
	private Collider coll;
	// Use this for initialization
	void Start () {
		gameObject.SetActive(true);
		rend = GetComponent<MeshRenderer> ();
		coll = GetComponent<MeshCollider> ();
		rend.enabled = false;
		coll.enabled = false;
	}
	void plaque(bool enable){
		rend.enabled = enable;
		coll.enabled = enable;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			plaque(!rend.enabled);
			//print ("P down");
		}
		//else:
			//gameObject.SetActive(true);
	}
}
