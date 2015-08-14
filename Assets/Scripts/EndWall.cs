using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;


public class EndWall : MonoBehaviour {
	private int count =0;
	public GameObject uicount,uiCellTime,uitime,uimean,uisd;
	public int sampleStart, sampleCount, displayTime;
	private int thisCount;
	int samples;
	bool die = false;
	float time0,endTime=0;
	List<float> data;
	private Text countText;
	private float time =0;
	private Text timeText,theTime;
	private Text meanText, sdText;

	// Use this for initialization
	void Start () {
		countText = uicount.GetComponent<Text> ();
		timeText = uiCellTime.GetComponent<Text> ();
		theTime = uitime.GetComponent<Text> ();
		meanText = uimean.GetComponent<Text> ();
		sdText = uisd.GetComponent<Text> ();
		Reset ();
	}
	public bool stop(){ return die;}
	void Reset(){
		time0 = Time.time;
		samples = 0;
		data = new List<float>();
		die = false;
		endTime = 0;
		time = 0;
		thisCount = 0;
	}
	float RunTime(){
		return Time.time - time0;
	}
	// Update is called once per frame
	void Update () {
		theTime.text = "Time: " + RunTime().ToString ();
		if(endTime > 0){
			//print ("Hello "+endTime.ToString()+ " - "+Time.time.ToString() +" > "+ ((float)displayTime).ToString());
			if ((Time.time - endTime) > (float)displayTime){
				//print("die");
				die = true;
			}
			if ((Time.time - endTime) > (float)(displayTime+3)){
				//print ("wake");
				Reset();
			}
		}
	}
	void OnTriggerEnter (Collider col) {
		Cell cell = (Cell)col.gameObject.GetComponent<Cell>();
		float cellTime = Time.time-cell.startTime;
		time += cellTime;
		count += 1;
		thisCount += 1;
		if ((RunTime() > sampleStart) & (samples < sampleCount)) {
			samples += 1;
			data.Add(cellTime);
			float mean= data.Sum()/samples;
			meanText.text = "Sample Mean: " + mean;
			if (samples == sampleCount){
				float sdsum=0;
				foreach(float sample in data)
					sdsum += (sample-mean)*(sample-mean);
				sdText.text = "Standard Deviation: " + (Mathf.Sqrt(sdsum/(samples-1))).ToString();
				endTime = Time.time;
			}
		}
		Destroy(col.gameObject);
		timeText.text = "Av. cell time: " + (time / thisCount).ToString ();
		countText.text = "Count: " + count.ToString ();
	}
}