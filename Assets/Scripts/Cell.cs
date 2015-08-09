using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Cell : MonoBehaviour {
	float ax,ay,az =0;

	float charge = 0;
	List<Cell> cells;
	bool firstTime = true;
	int listSize;
	Rigidbody rb;
	Vector3 tf,velocity;
	public float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		rb = GetComponent <Rigidbody> ();
		tf = GetComponent <Transform> ().position;	
	}

	public void SetVelocity (float vx,float vy, float vz) {
	
		rb = GetComponent <Rigidbody> ();
		velocity = new Vector3 (vx, vy, vz);
		rb.velocity = velocity;
	}
	public void SC (float q) {  //SAC: Set Charge
		ax = 0;
		ay = 0;
		az = 0;
		charge = q;
		//print ("Render" + pq.ToString());
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
		listSize = cells.Count;
	}
	void Accel(){

		/*    ax = sum([particle.q if particle.x < self.x else particle.q * -1
              for particle in particles
               if self != particle and self.x != particle.x]) */
		float tax =0 ,tay = 0;
		foreach (Cell cell in cells) {
			if (this != cell && tf.x != cell.tf.x)
				tax += (cell.tf.x < tf.x) ? cell.charge : cell.charge * -1;
		}
		foreach (Cell cell in cells) {
			if (this != cell && tf.y != cell.tf.y)
				tay += (cell.tf.y < tf.y) ? cell.charge : cell.charge * -1;
		}

		this.ax = tax*(charge/10)*Time.deltaTime;
		this.ay = tay*(charge/10)*Time.deltaTime;
		//print ("ax ay" + tax.ToString() + ' ' + tay.ToString()+' '+ Time.deltaTime + ' ' +charge);
	}
	// Update is called once per frame
	void Update () {
		if (firstTime) {
			firstTime = false;
		}
			//Accel ();

	}

	void LateUpdate () {
		velocity.x = rb.velocity.x + ax;
		velocity.y = rb.velocity.y + ay;
		//rb.velocity = new Vector3(velocity.x,velocity.y,0);
	}
}