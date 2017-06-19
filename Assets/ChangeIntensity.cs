using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeIntensity : MonoBehaviour {
	public float offset;
	float trigger = 0;
	// Update is called once per frame
	IEnumerator Start () {
		WebSocket w = new WebSocket(new Uri("ws://127.0.0.1:1337"));
		yield return StartCoroutine(w.Connect());
		w.SendString("Hi there");
		int i=0;
		while (true)
		{
			string reply = w.RecvString ();
			if (reply != null)
			{
				Debug.Log ("Received: "+reply);
				trigger = Time.fixedTime;
			}
			if (w.error != null)
			{
				Debug.LogError ("Error: "+w.error);
				break;
			}
			yield return 0;
		}
		w.Close();
	}

	void Update () {
		float time_since_trigger = Time.fixedTime - (trigger + offset);
		if (time_since_trigger > 0 && time_since_trigger < 5)
			gameObject.GetComponent<TubeLight> ().m_Intensity = (float)(0.8 * Mathf.Abs (Mathf.Sin ((Time.fixedTime + offset) * 15)));
		else if (Time.fixedTime - trigger < 10)
			gameObject.GetComponent<TubeLight> ().m_Intensity = (float)0.8;
		else
			gameObject.GetComponent<TubeLight> ().m_Intensity = 0;
	}
}
