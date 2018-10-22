using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour {

    [SerializeField] Slider slider_ref;
    private Text text_ref;

	// Use this for initialization
	void Start ()
    {
        text_ref = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		switch ((int)slider_ref.value)
        {
            case 0:
                text_ref.text = "2007";
                break;
            case 1:
                text_ref.text = "2008";
                break;
            case 2:
                text_ref.text = "2009";
                break;
            case 3:
                text_ref.text = "2010";
                break;
            case 4:
                text_ref.text = "2011";
                break;
            case 5:
                text_ref.text = "2012";
                break;
            case 6:
                text_ref.text = "2013";
                break;
            case 7:
                text_ref.text = "2014";
                break;
        }
	}
}
