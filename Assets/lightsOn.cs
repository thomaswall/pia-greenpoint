using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsOn : MonoBehaviour {
	private Color color;
	public float offset;

	void Start () {
		color = GetComponent<Renderer>().material.color;
		color = new Color (color.r, color.g, color.b, color.a / 2);
	}

	void Update () {
		var material = GetComponent<Renderer> ().material;


		if ((Time.fixedTime) % 6.0 >= offset && (Time.fixedTime) % 6.0 < offset + 2) {
			material.color = color;
		} else {
			material.color = new Color (color.r, color.g, color.b, 0);
		}
	}
}
