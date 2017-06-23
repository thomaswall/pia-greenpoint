using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using WebSocketSharp;

public class ChangeIntensity : MonoBehaviour {
	public float offset;
	string last = "0";
	bool off = false;
	bool dirty = false;
	float trigger = 0;
	// Update is called once per frame
	void Start () {
		WebSocket w = new WebSocket("ws://192.168.0.96:8181/kinect");
		w.OnMessage += (object sender, MessageEventArgs e) => {
			Debug.Log(e.Data);
			if(last == "0" && e.Data != "0"){
				dirty = true;
				off = false;
			}
			else if(last != "0" && e.Data == "0")
				off = true;
			last = e.Data;
		};
		w.ConnectAsync ();
	}

	void Update () {
		if (dirty) {
			trigger = Time.fixedTime;
			dirty = false;
		}

		float time_since_trigger = Time.fixedTime - (trigger + offset);
		if (time_since_trigger > 0 && time_since_trigger < 5)
			gameObject.GetComponent<TubeLight> ().m_Intensity = (float)(0.8 * Mathf.Abs (Mathf.Sin ((Time.fixedTime + offset) * 17)));
		else if (!off)
			gameObject.GetComponent<TubeLight> ().m_Intensity = (float)(0.8 + 0.4 * Mathf.Sin(Time.fixedTime));
		else
			gameObject.GetComponent<TubeLight> ().m_Intensity = 0;
	}
}
