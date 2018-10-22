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
    private MeshRenderer mesh_ref;
    // Use this for initialization
    void Start()
    {
        cal_ref = GameObject.Find("DatabaseManager").GetComponent<CalculateDeathTotals>();
        mesh_ref = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float num = Mathf.InverseLerp(cal_ref.min_deaths, cal_ref.max_deaths, cal_ref.death_totals[id]);
        Color col = Color.Lerp(Color.green, Color.red, num);
        mesh_ref.material.color = col;
    }
}