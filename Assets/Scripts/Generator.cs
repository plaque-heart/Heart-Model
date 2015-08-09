using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO; 

public class Generator : MonoBehaviour {
	public Cell sampleCell;
	string filecells = "";
	List<Cell> cells = new List<Cell> ();
	float itsTime = 0;

	void Load_Cells () {
		Cell cell;

		//Rigidbody rb = sampleCell.GetComponent<Rigidbody>();
		List<float> mylist;

		foreach (string line in filecells.Split('\n')){
			mylist = new List<float> ();
			if (line.Trim() != "")  {
				foreach (string u  in line.Split()) {
					mylist.Add(float.Parse(u));
				}
				//rb.velocity = new Vector3(mylist[2],mylist[3],0);
				cell = Instantiate(sampleCell, new Vector3(mylist[0]-350,mylist[1],mylist[2]), Quaternion.identity) as Cell;
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
	// Use this for initialization
	IEnumerator Start () {
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
		Load_Cells();
	}
	
	// Update is called once per frame
	void Update () {
		itsTime += Time.deltaTime;
		if (itsTime > 1) {
			itsTime =0;
			Load_Cells();
		}

	}
}
