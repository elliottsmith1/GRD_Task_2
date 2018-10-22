using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDeathTotals : MonoBehaviour {

    [SerializeField] DatabaseManager manager;

    [SerializeField] List<int> death_totals = new List<int>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Calculate()
    {
        for (int i = 0; i < manager.disease_names.Count; i++)
        {
            int num = 0;
            death_totals.Add(num);
        }

        for (int j = 0; j < manager.disease_databse.Count; j++)
        {
            int id = 0;

            for (int l = 0; l < manager.disease_names.Count; l++)
            {
                if (manager.disease_names[l] == manager.disease_databse[j].death_cause)
                {
                    id = l;

                    death_totals[id] += (int)manager.disease_databse[j].deaths;
                    break;
                }
            }            
        }
    }
}
