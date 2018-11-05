using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterSystem : MonoBehaviour
{
    private const int numberOfFlags = 6;

    [SerializeField] PopulationManager popmanager_ref;

    [SerializeField] Dropdown diseasedropdown_ref;
    [SerializeField] Dropdown sexdropdown_ref;
    [SerializeField] Dropdown ethnicitydropdown_ref;
    [SerializeField] Button reset_ref;
    [SerializeField] Button resetOne_ref;
    [SerializeField] Button sorttoflags_ref;


    private string disease_name;
    private string sex_name;
    private string ethnicity_name;

    private bool buttonClicked = false; //Check if button was clicked

    //For finding the position on the map relative to the camera
    [SerializeField] Camera cam; //Camera in scene
    private RaycastHit hit;
    private int layerMask = 1 << 9; //layerMask to specify the only layer for the ray to collide with
    private Vector3 point_on_screen = new Vector3(0f, 0f, 0f); //The position on the plane the mouse is pointing at

    //For the flags
    [SerializeField] GameObject Spawnflag; //Flag Sprite
    [SerializeField] Dropdown flagDropdown_ref; //Dropdown menu for selecting the flag
    private Vector3[] flagPosition = new Vector3[numberOfFlags]; //Flag Position
    private int selectFlag = 0; //Selected Flag
    private bool[] selectFlagCheck = new bool[numberOfFlags];  //Selected Flags Check
    private GameObject[] flagGameObjects = new GameObject[numberOfFlags]; //Array of flags

    /*private List<GameObject> sub_group = new List<GameObject>();
    private List<List<GameObject>> sub_group_list = new List<List<GameObject>>();
    private List<GameObject> master_group = new List<GameObject>();      //Contains all people
    */

    private List<GameObject> temp_group = new List<GameObject>();

    private List<GameObject> sub_group1 = new List<GameObject>();
    private List<GameObject> sub_group2 = new List<GameObject>();
    private List<GameObject> sub_group3 = new List<GameObject>();
    private List<GameObject> sub_group4 = new List<GameObject>();
    private List<GameObject> sub_group5 = new List<GameObject>();
    private List<GameObject> sub_group6 = new List<GameObject>();

    private bool check_group = false;


    private string diseaseName = "Any";
    private string sexName = "Any";
    private string ethnicityName = "Any";



    // Use this for initialization
    void Start()
    {
        //Add listener for when the value of the Dropdown changes, to take action
        diseasedropdown_ref.onValueChanged.AddListener(delegate { DropdownValueChanged(diseasedropdown_ref); });
        sexdropdown_ref.onValueChanged.AddListener(delegate { DropdownValueChanged(sexdropdown_ref); });
        ethnicitydropdown_ref.onValueChanged.AddListener(delegate { DropdownValueChanged(ethnicitydropdown_ref); });
        flagDropdown_ref.onValueChanged.AddListener(delegate { SelectFlagFromList(flagDropdown_ref); });

        reset_ref.onClick.AddListener(ResetPersonButton); //Listener for the Reset button
        resetOne_ref.onClick.AddListener(ResetOnePersonButton); //Listener for the Reset button

        sorttoflags_ref.onClick.AddListener(SortPersonButton); //Listener for the Reset button

        //master_group = popmanager_ref.SelectSubPopulation("Any", "Any", "Any");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            FindPointOnScreen();
        }
    }

    //Unity Event Listener for when a dropdown menu value changes
    void DropdownValueChanged(Dropdown ddDropdown)
    {
        /*if (buttonClicked == false)
        {
            string filteredname = ddDropdown.captionText.text; //The name for option that is now filtered to
            string dropdownname = ddDropdown.name; //Dropdown object name 
            SetNewTarget(dropdownname, filteredname);
        }*/

        switch (ddDropdown.name)
        {
            case "Disease":
                diseaseName = ddDropdown.captionText.text;
                break;
            case "Sex":
                sexName = ddDropdown.captionText.text;
                break;
            case "Ethnicity":
                ethnicityName = ddDropdown.captionText.text;
                break;
            default:
                Debug.Log("Something has gone wrong");
                break;
        }
    }

    void SortPersonButton()
    {
        SetNewTarget();
    }

    void SelectFlagFromList(Dropdown ddDropdown)
    {
        selectFlag = ddDropdown.value;

        buttonClicked = true;

        diseasedropdown_ref.value = 0;
        sexdropdown_ref.value = 0;
        ethnicitydropdown_ref.value = 0;

        buttonClicked = false;
        //check_group = false;
    }

    //Sets the AI target for the filtered population
    //void SetNewTarget(string dd_name, string fn)
    void SetNewTarget()
    {
        /*if (check_group)
        {
            ResetPeople();
            check_group = false;
        }*/
        
        if (diseasedropdown_ref.value == 0)
        {
            diseaseName = "Any";
        }

        if (sexdropdown_ref.value == 0)
        {
            sexName = "Any";
        }

        if (ethnicitydropdown_ref.value == 0)
        {
            ethnicityName = "Any";
        }
        
        //sub_group = popmanager_ref.SelectSubPopulation(diseaseName, sexName, ethnicityName);
        //sub_group_list.Add(sub_group);

        Debug.Log("Selected Flag = " + selectFlag);

        switch (selectFlag)
        {
            case 0:
                sub_group1 = new List<GameObject>(popmanager_ref.SelectSubPopulation(diseaseName, sexName, ethnicityName));
                //temp_group
                break;
            case 1:
                sub_group2 = new List<GameObject>(popmanager_ref.SelectSubPopulation(diseaseName, sexName, ethnicityName));
                break;
            case 2:
                sub_group3 = new List<GameObject>(popmanager_ref.SelectSubPopulation(diseaseName, sexName, ethnicityName));
                break;
            case 3:
                sub_group4 = new List<GameObject>(popmanager_ref.SelectSubPopulation(diseaseName, sexName, ethnicityName));
                break;
            case 4:
                sub_group5 = new List<GameObject>(popmanager_ref.SelectSubPopulation(diseaseName, sexName, ethnicityName));
                break;
            case 5:
                sub_group6 = new List<GameObject>(popmanager_ref.SelectSubPopulation(diseaseName, sexName, ethnicityName));
                break;
            default:
                Debug.Log("Something has gone wrong");
                break;
        }

        //Setting the new position for the group to organise to
        SetNewTargetFunction();

        /*//For checking which catergories are choosen                          
        Debug.Log(disease_name);
        Debug.Log(sex_name);
        Debug.Log(ethnicity_name);
        */


        //check_group = true;
    }

    void ResetPersonButton()
    {
        buttonClicked = true;

        Unflagged();

        //sub_group[selectFlag] = popmanager_ref.SelectSubPopulation("Any", "Any", "Any");
        ResetPeople();
        //sub_group[selectFlag].Clear();

        //Changing the values will call the DropdownValueChanged() because the listener is an interrupt
        diseasedropdown_ref.value = 0;
        sexdropdown_ref.value = 0;
        ethnicitydropdown_ref.value = 0;

        selectFlagCheck[selectFlag] = false;
        buttonClicked = false;
    }

    void ResetOnePersonButton()
    {
        buttonClicked = true;

        UnflaggedOne();
        ResetPeopleOne();

        diseasedropdown_ref.value = 0;
        sexdropdown_ref.value = 0;
        ethnicitydropdown_ref.value = 0;

        selectFlagCheck[selectFlag] = false;
        buttonClicked = false;
    }

    void Flagged() //Spawns the flag on the map
    {
        //new Vector3 as a cheap edit for the size of the flag

        if (flagGameObjects[selectFlag] != null)
        {
            Destroy(flagGameObjects[selectFlag]);
        }
        
        flagGameObjects[selectFlag] = (GameObject) Instantiate(Spawnflag,
            flagPosition[selectFlag] + new Vector3(0f, 10f, 0), Quaternion.identity);
        if (selectFlagCheck[selectFlag])
        {
            SetNewTargetFunction();
        }
    }

    void Unflagged() //Takes the flag away
    {
        for (int i = 0; i < numberOfFlags; i++)
        {
            if (flagGameObjects[i] != null)
            {
                Destroy(flagGameObjects[i]);
            }
        }
    }

    void UnflaggedOne()
    {
        Destroy(flagGameObjects[selectFlag]);
    }

    void FindPointOnScreen()
    {
        Ray rrRay = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(rrRay.origin, rrRay.direction, out hit, Mathf.Infinity, layerMask);
        point_on_screen = hit.point;
        flagPosition[selectFlag] = new Vector3(point_on_screen.x, 1.0f, point_on_screen.z);

        Flagged();

        //Debug.Log(point_on_screen);
    }

    void ResetPeople()
    {
        if (sub_group1.Count != 0)
        {
            for (int j = 0; j < sub_group1.Count; j++)
            {
                sub_group1[j].GetComponent<Person>().StopSeeking();
            }
            sub_group1.Clear();
        }

        if (sub_group2.Count != 0)
        {
            for (int j = 0; j < sub_group2.Count; j++)
            {
                sub_group2[j].GetComponent<Person>().StopSeeking();
            }
            sub_group2.Clear();
        }

        if (sub_group3.Count != 0)
        {
            for (int j = 0; j < sub_group3.Count; j++)
            {
                sub_group3[j].GetComponent<Person>().StopSeeking();
            }
            sub_group3.Clear();
        }

        if (sub_group4.Count != 0)
        {
            for (int j = 0; j < sub_group4.Count; j++)
            {
                sub_group4[j].GetComponent<Person>().StopSeeking();
            }
            sub_group4.Clear();
        }

        if (sub_group5.Count != 0)
        {
            for (int j = 0; j < sub_group5.Count; j++)
            {
                sub_group5[j].GetComponent<Person>().StopSeeking();
            }
            sub_group5.Clear();
        }

        if (sub_group6.Count != 0)
        {
            for (int j = 0; j < sub_group6.Count; j++)
            {
                sub_group6[j].GetComponent<Person>().StopSeeking();
            }
            sub_group6.Clear();
        }
    }

    void ResetPeopleOne()
    {
        if (sub_group1.Count != 0 && selectFlag == 0)
        {
            for (int j = 0; j < sub_group1.Count; j++)
            {
                sub_group1[j].GetComponent<Person>().StopSeeking();
            }
            sub_group1.Clear();
        }

        if (sub_group2.Count != 0 && selectFlag == 1)
        {
            for (int j = 0; j < sub_group2.Count; j++)
            {
                sub_group2[j].GetComponent<Person>().StopSeeking();
            }
            sub_group2.Clear();
        }

        if (sub_group3.Count != 0 && selectFlag == 2)
        {
            for (int j = 0; j < sub_group3.Count; j++)
            {
                sub_group3[j].GetComponent<Person>().StopSeeking();
            }
            sub_group3.Clear();
        }

        if (sub_group4.Count != 0 && selectFlag == 3)
        {
            for (int j = 0; j < sub_group4.Count; j++)
            {
                sub_group4[j].GetComponent<Person>().StopSeeking();
            }
            sub_group4.Clear();
        }

        if (sub_group5.Count != 0 && selectFlag == 4)
        {
            for (int j = 0; j < sub_group5.Count; j++)
            {
                sub_group5[j].GetComponent<Person>().StopSeeking();
            }
            sub_group5.Clear();
        }

        if (sub_group6.Count != 0 && selectFlag == 5)
        {
            for (int j = 0; j < sub_group6.Count; j++)
            {
                sub_group6[j].GetComponent<Person>().StopSeeking();
            }
            sub_group6.Clear();
        }
    }

    void SetNewTargetFunction()
    {
        /*
        for (int i = 0; i < sub_group_list[selectFlag].Count; i++)
        {
            sub_group_list[selectFlag][i].GetComponent<Person>().SetTarget(flagPosition[selectFlag]);
            sub_group_list[selectFlag][i].GetComponent<Person>().EnableLight();
        }
        */

        switch (selectFlag)
        {
            case 0:
                for (int i = 0; i < sub_group1.Count; i++)
                {
                    sub_group1[i].GetComponent<Person>().SetTarget(flagPosition[selectFlag]);
                    sub_group1[i].GetComponent<Person>().EnableLight();
                }
                break;
            case 1:
                for (int i = 0; i < sub_group2.Count; i++)
                {
                    sub_group2[i].GetComponent<Person>().SetTarget(flagPosition[selectFlag]);
                    sub_group2[i].GetComponent<Person>().EnableLight();
                }
                break;
            case 2:
                for (int i = 0; i < sub_group3.Count; i++)
                {
                    sub_group3[i].GetComponent<Person>().SetTarget(flagPosition[selectFlag]);
                    sub_group3[i].GetComponent<Person>().EnableLight();
                }
                break;
            case 3:
                for (int i = 0; i < sub_group4.Count; i++)
                {
                    sub_group4[i].GetComponent<Person>().SetTarget(flagPosition[selectFlag]);
                    sub_group4[i].GetComponent<Person>().EnableLight();
                }
                break;
            case 4:
                for (int i = 0; i < sub_group5.Count; i++)
                {
                    sub_group5[i].GetComponent<Person>().SetTarget(flagPosition[selectFlag]);
                    sub_group5[i].GetComponent<Person>().EnableLight();
                }
                break;
            case 5:
                for (int i = 0; i < sub_group6.Count; i++)
                {
                    sub_group6[i].GetComponent<Person>().SetTarget(flagPosition[selectFlag]);
                    sub_group6[i].GetComponent<Person>().EnableLight();
                }
                break;
            default:
                Debug.Log("Something has gone wrong");
                break;
        }

        Debug.Log(sub_group1.Count);    //Somehow both groups are listing the sub_group
        Debug.Log(sub_group2.Count);

        selectFlagCheck[selectFlag] = true;
    }
}





/*for (int j = 0; j < numberOfFlags; j++)
{
    if (sub_group[j].Count != 0)
    {
        for (int i = 0; i < sub_group[j].Count; i++)
        {
            sub_group[j][i].GetComponent<Person>().ResetPerson();
        }
    }
}*/

/*for (int j = 0; j < numberOfFlags; j++)
{
    sub_group[j].Clear();
}*/
