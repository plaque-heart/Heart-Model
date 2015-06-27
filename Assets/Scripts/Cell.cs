using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {
	private float ax,ay,az =0;
	private float vx,vy,vz = 0;
	private float charge = 0;

	// Use this for initialization
	void Start () {
	
	}

	public void SetVelocity (float pvx,float pvy, float pvz) {
		vx = pvx;
		vy = pvy;
		vz = pvz;
		Rigidbody rb = GetComponent <Rigidbody> ();
		rb.velocity = new Vector3(vx,vy,0);
	}
	public void SAC (float pax, float pay, float paz, float pq) {  //SAC: Set Acelleration & Charge
		ax = pax;
		ay = pay;
		az = paz;
		charge = pq;
		print ("Render" + pq.ToString());
		Renderer render = GetComponent <MeshRenderer> ();
		if(charge == -1)
			render.material.color = Color.red; //SetColor("_SpecColor", Color.red);
		else if(charge == 1)
			render.material.color = Color.cyan; //SetColor("_SpecColor", Color.red);
		else
			render.material.color = Color.white; //SetColor("_SpecColor", Color.red);

	}

	// Update is called once per frame
	void Update () {
		//particle.accel(particles);
	}


	void FixedUpdate () {
		//particle.move ();
	}
}
