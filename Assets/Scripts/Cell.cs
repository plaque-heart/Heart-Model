using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cell : MonoBehaviour {
	float ax,ay,az =0;
	float vx,vy,vz = 0;
	float charge = 0;
	List<Cell> cells = new List<Cell> ();

	// Use this for initialization
	void Start () {
	
	}

	public void SetVelocity (float vx,float vy, float vz) {
		this.vx = vx;
		this.vy = vy;
		this.vz = vz;
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
	public void SetCells (List <Cell> cells) {
		this.cells = cells;
	}
	// Update is called once per frame
	void Update () {
		//this.accel(particles);
	}


	void FixedUpdate () {
		//this.move ();
	}
}
