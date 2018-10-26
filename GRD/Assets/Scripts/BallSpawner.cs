using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    
    Transform trsm;
    int childCount;                             //Number of child attaced to Data Manager
	private DiseaseStats DiseaseStatsScript;

    // Use this for initialization
    void Start () {
		trsm = this.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {       
		
    }

    public void SpawnBalls()                       //Spawns the balls by a diease category
    {
        childCount = trsm.childCount;
        GameObject[] DiseaseChildren = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
        {
			DiseaseChildren[i] = trsm.GetChild(i).gameObject;
			DiseaseStatsScript = DiseaseChildren[i].GetComponent<DiseaseStats>();

            float id = 0;

            switch (DiseaseStatsScript.death_cause)
            {
                case "Accidents Except Drug Posioning (V01-X39; X43; X45-X59; Y85-Y86)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(1f, 0f, 1f);
                    break;
                case "All Other Causes":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(2f, 0f, 2f);
                    break;
                case "Alzheimer's Disease (G30)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(3f, 0f, 3f);
                    break;
                case "Aortic Aneurysm and Dissection (I71)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(4f, 0f, 4f);
                    break;
                case "Assault (Homicide: Y87.1; X85-Y09)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(5f, 0f, 5f);
                    break;
                case "Atherosclerosis (I70)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(6f, 0f, 6f);
                    break;
                case "Cerebrovascular Disease (Stroke: I60-I69)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(7f, 0f, 7f);
                    break;
                case "Certain Conditions originating in the Perinatal Period (P00-P96)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(8f, 0f, 8f);
                    break;
                case "Chronic Liver Disease and Cirrhosis (K70; K73)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(9f, 0f, 9f);
                    break;
                case "Chronic Lower Respiratory Diseases (J40-J47)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(10f, 0f, 10f);
                    break;
                case "Congenital Malformations; Deformations; and Chromosomal Abnormalities (Q00-Q99)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(11f, 0f, 11f);
                    break;
                case "Diabetes Mellitus (E10-E14)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(12f, 0f, 12f);
                    break;
                case "Diseases of Heart (I00-I09; I11; I13; I20-I51)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(13f, 0f, 13f);
                    break;
                case "Essential Hypertension and Renal Diseases (I10; I12)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(14f, 0f, 14f);
                    break;
                case "Human Immunodeficiency Virus Disease (HIV: B20-B24)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(15f, 0f, 15f);
                    break;
                case "Influenza (Flu) and Pneumonia (J09-J18)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(16f, 0f, 16f);
                    break;
                case "Insitu or Benign / Uncertain Neoplasms (D00-D48)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(17f, 0f, 17f);
                    break;
                case "Intentional Self-Harm (Suicide: X60-X84; Y87.0)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(18f, 0f, 18f);
                    break;
                case "Malignant Neoplasms (Cancer: C00-C97)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(19f, 0f, 19f);
                    break;
                case "Mental and Behavioral Disorders due to Accidental Poisoning and Other Psychoactive Substance Use (F11-F16; F18-F19; X40-X42; X44)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(20f, 0f, 20f);
                    break;
                case "Mental and Behavioral Disorders due to Use of Alcohol (F10)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(21f, 0f, 21f);
                    break;
                case "Nephritis; Nephrotic Syndrome and Nephrisis (N00-N07; N17-N19; N25-N27)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(22f, 0f, 22f);
                    break;
                case "Parkinson's Disease (G20)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(23f, 0f, 23f);
                    break;
                case "Septicemia (A40-A41)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(24f, 0f, 24f);
                    break;
                case "Tuberculosis (A16-A19)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(25f, 0f, 25f);
                    break;
                case "Viral Hepatitis (B15-B19)":
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(26f, 0f, 26f);
                    break;
                default:
                    DiseaseChildren[i].GetComponent<Transform>().position = new Vector3(0f, 0f, 0f);
                    break;
            }            
        }
    }
}
