using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterSystem : MonoBehaviour {

    [SerializeField] PopulationManager popmanager_ref;

    [SerializeField] Dropdown diseasedropdown_ref;
    [SerializeField] Dropdown sexdropdown_ref;
    [SerializeField] Dropdown ethnicitydropdown_ref;
    [SerializeField] Button reset_ref;

    [SerializeField] GameObject Spawnflag;                              //Flag Sprite
    public Vector3 flagPosition = new Vector3(0f, 1f, 0f);              //Flag Position

    private List<GameObject> sub_group = new List<GameObject>();
    private List<GameObject> pre_sub_group = new List<GameObject>();    //Previous sub group to reset their positions

    private string disease_name;
    private string sex_name;
    private string ethnicity_name;

    private bool buttonClicked = false;                                 //Check if button was clicked


    // Use this for initialization
    void Start () {
        //Add listener for when the value of the Dropdown changes, to take action
        diseasedropdown_ref.onValueChanged.AddListener(delegate {
            DropdownValueChanged(diseasedropdown_ref);
        });
        sexdropdown_ref.onValueChanged.AddListener(delegate {
            DropdownValueChanged(sexdropdown_ref);
        });
        ethnicitydropdown_ref.onValueChanged.AddListener(delegate {
            DropdownValueChanged(ethnicitydropdown_ref);
        });
        
        reset_ref.onClick.AddListener(ResetPersonButton);   //Listener for the Reset button
    }

    // Update is called once per frame
        void Update () {
	    
    }

    //Unity Event Listener for when a dropdown menu value changes
    void DropdownValueChanged(Dropdown ddDropdown)
    {
        if (buttonClicked == false)
        {
            string filteredname = ddDropdown.captionText.text; //The name for option that is now filtered to
            string dropdownname = ddDropdown.name; //Dropdown object name 

            SetNewTarget(dropdownname, filteredname);
        }
    }

    //Sets the AI target for the filtered population
    void SetNewTarget(string dd_name, string fn)
    {
        if (pre_sub_group.Count != 0)
        {
            for (int i = 0; i < pre_sub_group.Count; i++)
            {
                pre_sub_group[i].GetComponent<Person>().ResetPerson();
                Unflagged();
            }
        }
        
        switch (dd_name)
        {
            case "Disease":
                disease_name = fn;
                break;
            case "Sex":
                sex_name = fn;
                break;
            case "Ethnicity":
                ethnicity_name = fn;
                break;
            default:
                Debug.Log("Something has gone wrong");
                break;
        }

        if (diseasedropdown_ref.value == 0)
        {
            disease_name = "Any";
        }
        if (sexdropdown_ref.value == 0)
        {
            sex_name = "Any";
        }
        if (ethnicitydropdown_ref.value == 0)
        {
            ethnicity_name = "Any";
        }

        sub_group = popmanager_ref.SelectSubPopulation(disease_name, sex_name, ethnicity_name);
        pre_sub_group = sub_group;

        //Setting the new position for the group to organise to
        for (int i = 0; i < sub_group.Count; i++)
        {
            sub_group[i].GetComponent<Person>().SetTarget(flagPosition);
        }

        Flagged();

        /*//For checking which catergories are choosen                          
        Debug.Log(disease_name);
        Debug.Log(sex_name);
        Debug.Log(ethnicity_name);
        */
    }

    void ResetPersonButton()
    {
        buttonClicked = true;

        //Changing the values will call the DropdownValueChanged() because the listener is an interrupt
        diseasedropdown_ref.value = 0;
        sexdropdown_ref.value = 0;
        ethnicitydropdown_ref.value = 0;

        if (sub_group.Count != 0)
        {
            for (int i = 0; i < sub_group.Count; i++)
            {
                sub_group[i].GetComponent<Person>().ResetPerson();
            }
        }

        pre_sub_group.Clear();
        sub_group.Clear();

        buttonClicked = false;

        Unflagged();
    }

    void Flagged()                  //Giving the individual person a flag over their head
    {
        //new Vector3 as a cheap edit for the size of the flag
        Instantiate(Spawnflag, flagPosition + new Vector3(0f,10f,0), Quaternion.identity);
    }

    void Unflagged()                //Taking their flag away
    {
        GameObject[] flags = GameObject.FindGameObjectsWithTag("FlagTag");

        foreach (GameObject flag in flags)
        {
            Destroy(flag.gameObject);
        }
    }
}
