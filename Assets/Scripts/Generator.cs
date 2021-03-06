﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO; 

public class Generator : MonoBehaviour {
	public Cell sampleCell;
	public Cell platelet;
	public Cell WhiteCell;
	public EndWall endWall;
	public Plaque plaque1,plaque2,plaque3;
	string filecells = "";
	List<Cell> cells = new List<Cell> ();
	List<Plaque> plaques = new List<Plaque> ();

	float itsTime = 0;
	public int pladlets,whiteCells;
	int plaqueType = 0;

	void Load_Cells () {
		Cell cell,addCell;
		int rand;

		//Rigidbody rb = sampleCell.GetComponent<Rigidbody>();
		List<float> mylist;

		foreach (string line in filecells.Split('\n')){
			mylist = new List<float> ();
			if (line.Trim() != "")  {
				foreach (string u  in line.Split()) {
					float floatu;;
					if(float.TryParse(u,out floatu))
						mylist.Add(floatu);
				}
				//rb.velocity = new Vector3(mylist[2],mylist[3],0);
				rand = Random.Range(0,100);
				if(rand < whiteCells)
					addCell = WhiteCell;
				else if(rand < (whiteCells + pladlets))
					addCell = platelet;
				else
					addCell = sampleCell;
				cell = Instantiate(addCell, new Vector3(mylist[0]-350,mylist[1],mylist[2]), Quaternion.identity) as Cell;
				cell.SetEnd(endWall);

				cell.SetVelocity (mylist[3],mylist[4],mylist[5]);
				//cell.SAC (mylist[5],mylist[6],0,mylist[4]);
				cell.SC (mylist[6]);
				cells.Add(cell);
				cell.SetCells(cells);
				//print ("read a line" + line);
				//particle =  
			//particles= [make(num+1,particle) for num,particle in enumerate(f)
			//            if particle.strip()];

			}
		}
		//return particles;
	}
	//   -Use this for initialization
	IEnumerator Start () {

		plaques.Add (null);
		plaques.Add (plaque1);
		plaques.Add (plaque2);
		plaques.Add (plaque3);
		string fileName = "info-particles3.txt";
		try{
			StreamReader theFile = new StreamReader(fileName);
			using (theFile) {
				filecells = theFile.ReadToEnd ();
			}
		}
		catch {
			filecells = "";
		}
		if(filecells ==""){
			print ("no particles");
			WWW www =new WWW(fileName);
			yield return www;
			filecells = www.text;
		}
		//Load_Cells();
	}
	
	// Update is called once per frame
	void Update () {
		itsTime += Time.deltaTime;
		if ((itsTime > 1) & (!endWall.stop())){
			itsTime =0;
			Load_Cells();
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			//old plaque invisable
			if (plaqueType != 0)
				plaques [plaqueType].OnAndOff (false);
			//number +=1
			plaqueType += 1;
			if (plaqueType > 3)
				plaqueType = 0;
			//new plaque visable
			if (plaqueType != 0)
				plaques [plaqueType].OnAndOff (true);
		}

	}
}
