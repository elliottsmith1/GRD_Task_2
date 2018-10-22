using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
public class DatabaseManager : MonoBehaviour
{
    public enum DATATYPE
    {
        DISEASE,
        RACE,
        SEX
    };

    [SerializeField] TextAsset database_file;
    [SerializeField] GameObject disease_prefab;
    [SerializeField] List<DiseaseStats> disease_databse = new List<DiseaseStats>();
    // Use this for initialization
    void Start()
    {
        CreateDiseases();
    }

    void CreateDiseases()
    {
        string file = database_file.text;
        List<string> diseases = new List<string>(System.Text.RegularExpressions.Regex.Split(file, System.Environment.NewLine));
        for (int i = 1; i < diseases.Count; i++)
        {
            GameObject NewDisease = Instantiate(disease_prefab, transform.position, transform.rotation);
            NewDisease.transform.parent = this.transform;
            DiseaseStats disease = NewDisease.GetComponent<DiseaseStats>();
            string[] disease_stats = Regex.Split(diseases[i], ",");

            //this will abort adding any null lines
            int try_num = 0;
            if (!int.TryParse((disease_stats[0]), out try_num))
            {
                return;
            }

            //add stats in correct format
            disease.year = int.Parse(disease_stats[0]);
            disease.death_cause = disease_stats[1];
            disease.sex = disease_stats[2];
            disease.race = disease_stats[3];
            disease.deaths = int.Parse(disease_stats[4]);
            disease.death_rate = float.Parse(disease_stats[5]);
            disease.age_adjusted_death_rate = float.Parse(disease_stats[6]);

            //if disease entry had deaths, add to database list
            if (disease.deaths > 0)
            {
                disease_databse.Add(disease);
            }
            else
            {
                Destroy(NewDisease);
            }
        }
    }

    public void SeparateByDataType(DATATYPE _type, List<DiseaseStats> _diseases)
    {
        switch (_type)
        {
            case DATATYPE.DISEASE:

                for (int i = 0; i < _diseases.Count; i++)
                {
                    
                }

                break;
            case DATATYPE.RACE:

                break;
            case DATATYPE.SEX:

                break;
        }
    }
}