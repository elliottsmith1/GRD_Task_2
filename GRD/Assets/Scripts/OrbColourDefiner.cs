using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbColourDefiner : MonoBehaviour {

	public int deathCount;
	public int ethnicities;
	ColourManager CM;
	Renderer OrbRend;
	Vector4 colourToApply;
	float deathCalculation;
	public Material OrbMat;

	// Use this for initialization
	void Start () {
		CM = FindObjectOfType<ColourManager>();
		OrbRend = GetComponent<Renderer>();
		deathCalculation = (CM.maxDeaths/ deathCount);
	}
	
	// Update is called once per frame
	void Update () {
		if (deathCalculation > CM.colourDivider) {
			OrbRend.material.color = new Color(1f, 1f, 1f, 0f);
			Color color = OrbMat.color;
			color.a = 0;
			OrbMat.color = color;
		}
		
	}
}
