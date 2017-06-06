using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIntensity : MonoBehaviour {
	public float offset;
	// Update is called once per frame
	void Update () {
		if ((Time.fixedTime + offset) % 10 > 5)
			gameObject.GetComponent<TubeLight> ().m_Intensity = (float)(0.8 * Mathf.Abs (Mathf.Sin ((Time.fixedTime + offset) * 10)));
		else
			gameObject.GetComponent<TubeLight> ().m_Intensity = (float)0.8;
	}
}
