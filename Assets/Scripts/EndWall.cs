using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class EndWall : MonoBehaviour {
	private int count =0;
	public GameObject uicount,uitime;
	private Text countText;
	private float time =0;
	private Text timeText;

	// Use this for initialization
	void Start () {
		countText = uicount.GetComponent<Text> ();
		timeText = uitime.GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider col) {
		Cell cell = (Cell)col.gameObject.GetComponent<Cell>();
		time += Time.time-cell.startTime;
		count += 1;
		Destroy(col.gameObject);
		timeText.text = "Time: " + (time / count).ToString ();
		countText.text = "Count: " + count.ToString ();
	}
}