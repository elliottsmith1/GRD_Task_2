using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationManager : MonoBehaviour {

    [SerializeField] DatabaseManager manager_ref;
    [SerializeField] SliderText year_slider_ref;

    [SerializeField] int population_total = 0;
    [SerializeField] List<DiseaseStats> population = new List<DiseaseStats>();    

    private List<DiseaseStats> sub_population = new List<DiseaseStats>();
    private int population_year = 2007;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (year_slider_ref.current_year != population_year)
        {
            population_year = year_slider_ref.current_year;
            Populate();
        }
	}

    public void Populate()
    {
        population.Clear();
        population_total = 0;

        for (int i = 0; i < manager_ref.disease_databse.Count; i++)
        {
            if (manager_ref.disease_databse[i].year == population_year)
            {
                population.Add(manager_ref.disease_databse[i]);
                population_total += (int)manager_ref.disease_databse[i].deaths;
            }
        }
    }

    public List<DiseaseStats> SelectSubPopulation(string _disease, string _sex, string _race)
    {
        sub_population.Clear();

        for (int i = 0; i < population.Count; i++)
        {
            if ((population[i].death_cause == _disease) && (population[i].sex == _sex) && (population[i].race == _race))
            {
                sub_population.Add(population[i]);
            }
        }

        return sub_population;
    }
}
