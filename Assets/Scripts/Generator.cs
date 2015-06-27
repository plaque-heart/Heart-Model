using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO; 

public class Generator : MonoBehaviour {
	public Cell sampleCell;

	void Load_particles (string fileName) {

		List<Cell> cells = new List<Cell> ();
		Cell cell;
		Rigidbody rb = sampleCell.GetComponent<Rigidbody>();
		List<float> mylist;
		string line = "";
		StreamReader theFile = new StreamReader(fileName);
		using (theFile) {
			while (line != null){
				line = theFile.ReadLine();
				mylist = new List<float> ();
				if (line != null)  {
					foreach (string u  in line.Split()) {
						mylist.Add(float.Parse(u));
					}
					//rb.velocity = new Vector3(mylist[2],mylist[3],0);
					cell = Instantiate(sampleCell, new Vector3(mylist[0],mylist[1],0), Quaternion.identity) as Cell;
					cell.SetVelocity (mylist[2],mylist[3],0);
					cell.SAC (mylist[5],mylist[6],0,mylist[4]);

					cells.Add(cell);
					cell.SetCells (cells);
					print ("read a line" + line);
					//particle =  
				//particles= [make(num+1,particle) for num,particle in enumerate(f)
				//            if particle.strip()];

				}
			}
		}
		//return particles;
	}
	// Use this for initialization
	void Start () {
		Load_particles("info-particles3.txt");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
