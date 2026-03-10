using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetSelecter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        string room = GameObject.Find("DoNotDestroyOnLoad").GetComponent<ConstantScript>().room;
        GameObject.Find("2Q24").GetComponent<TargetScript>().active = false;
        GameObject.Find("2Q28").GetComponent<TargetScript>().active = false;
        GameObject.Find("3Q22").GetComponent<TargetScript>().active = false;

        if (room == "2Q24")
        {
            GameObject.Find("2Q24").GetComponent<TargetScript>().active = true;
        }
        if (room == "2Q28")
        {
            GameObject.Find("2Q28").GetComponent<TargetScript>().active = true;
        }
        if (room == "3Q22")
        {
            GameObject.Find("3Q22").GetComponent<TargetScript>().active = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }






}
