using UnityEngine;
using System.Collections;

public class Plaque : MonoBehaviour {

	private Renderer rend;
	private Collider coll;
	private int typeofplaque;
	// Use this for initialization
	void Start () {
		gameObject.SetActive(true);
		rend = GetComponent<MeshRenderer> ();
		coll = GetComponent<MeshCollider> ();
		rend.enabled = false;
		coll.enabled = false;
	}
	public void OnAndOff(bool enable){
		rend.enabled = enable;
		coll.enabled = enable;
	}
	// Update is called once per frame
	void NoUpdate () {
		if(Input.GetKeyDown(KeyCode.P)){
			OnAndOff(!rend.enabled);
			//print ("P down");
		}
		//else:
			//gameObject.SetActive(true);
	}
}
