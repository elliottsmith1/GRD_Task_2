using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationManager : MonoBehaviour {

    [SerializeField] DatabaseManager manager_ref;
    [SerializeField] SliderText year_slider_ref;
    
    [SerializeField] GameObject person_prefab;

    [SerializeField] int population_total = 0;
    [SerializeField] List<DiseaseStats> population = new List<DiseaseStats>();    

    private List<GameObject> people = new List<GameObject>();
    private List<GameObject> sub_population = new List<GameObject>();
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

        if (Input.GetButtonDown("Fire2"))
        {
            List<GameObject> sub_group = new List<GameObject>();
            sub_group = SelectSubPopulation("Any", "M", "Any");

            for (int i = 0; i < sub_group.Count; i++)
            {
                sub_group[i].GetComponent<Person>().SetTarget(transform.position);
            }
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

        SpawnPeople();
    }

    public List<GameObject> SelectSubPopulation(string _disease, string _sex, string _race)
    {
        sub_population.Clear();

        for (int i = 0; i < people.Count; i++)
        {
            Person person_script = people[i].GetComponent<Person>();
            if (!person_script.seeking)
            {
                if ((person_script.death_cause == _disease) || (_disease == "Any"))
                {
                    if ((person_script.sex == _sex) || (_sex == "Any"))
                    {
                        if ((person_script.race == _race) || (_race == "Any"))
                        {
                            sub_population.Add(people[i]);
                        }
                    }
                }
            }
        }

        return sub_population;
    }

    void SpawnPeople()
    {
        for (int j = 0; j < people.Count; j++)
        {
            Destroy(people[j].gameObject);
        }

        people.Clear();

        for (int i = 0; i < population.Count; i++)
        {
            for (int j = 0; j < (population[i].deaths / 100); j++)
            {
                GameObject person = Instantiate(person_prefab, transform.position, transform.rotation);
                Person person_script = person.GetComponent<Person>();
                person_script.death_cause = population[i].death_cause;
                person_script.sex = population[i].sex;
                person_script.race = population[i].race;

                people.Add(person);
            }
        }
    }
}
