using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DiseaseStats : MonoBehaviour
{
    public string death_cause;
    public string race;
    public string sex;
    public int year;
    public float deaths;
    public float death_rate;
    public float age_adjusted_death_rate;

    public int id;

    private CalculateDeathTotals cal_ref;
    // Use this for initialization
    void Start()
    {
        cal_ref = GameObject.Find("DatabaseManager").GetComponent<CalculateDeathTotals>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}