using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO; 

public class Generator : MonoBehaviour {
	public Cell cell;

	void Load_particles (string fileName) {
		/*Cell make(num,text) {
			nonlocal last;
			nums = text.strip().split();
			linesize =7;
			//print(nums)
			if len(nums) > linesize {
				raise RuntimeError('Line {} contains too many items'.format(num));
			}
			if len(nums) < linesize {
				raise RuntimeError('Line {} contains too few items'.format(num));
			}
			try
				flnums =[ float(num) for num in nums];
			catch (ValueError)
				raise TypeError('Line {} has a non-number'.format(num));
			x,y,vx,vy,q,ax,ay = flnums;
			if q not in [-1,0,1] {
				raise ValueError('Line {} has an invalid charge'.format(num));
			}
			for  lastX,lastY in last {
				if x== lastX and y == lastY {
					raise ValueError('Line {} uses the same position as a previous particle'.format(num));
				}
			}
			last += [(x,y)];
			return Cell(x,y,vx,vy,int(q),ax,ay);
		} */

		List<GameObject> particles = new List<GameObject> ();
		Cell particle;
		Rigidbody rb = cell.GetComponent<Rigidbody>();
		List<float> mylist = new List<float> ();
		string line = "";
		StreamReader theFile = new StreamReader(fileName);
		using (theFile) {
			while (line != null){
				line = theFile.ReadLine();
				if (line != null)  {
					foreach (string u  in line.Split()) {
						mylist.Add(float.Parse(u));
					}
					rb.velocity = new Vector3(mylist[2],mylist[3],0);
					particle = Instantiate(cell, new Vector3(mylist[0],mylist[1],0), Quaternion.identity) as Cell;
					particle.SetVelocity (mylist[2],mylist[3],0);
					particle.SAC (mylist[5],mylist[6],0,mylist[4]);
					print ("read a line" + line);
					mylist = new List<float> ();
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
