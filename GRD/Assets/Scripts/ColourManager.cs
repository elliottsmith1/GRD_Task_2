using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourManager : MonoBehaviour {

	[SerializeField] Slider slider_col;
	public int colourDivider = 1;
	public int maxDeaths = 100;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update()
	{
		switch ((int)slider_col.value)
		{
			case 0:
				colourDivider = 1;
				maxDeaths = 100;
				break;
			case 1:
				colourDivider = 2;
				maxDeaths = 200;
				break;
			case 2:
				colourDivider = 3;
				maxDeaths = 300;
				break;
			case 3:
				colourDivider = 4;
				maxDeaths = 400;
				break;
			case 4:
				colourDivider = 5;
				maxDeaths = 500;
				break;
		}
	}
}
