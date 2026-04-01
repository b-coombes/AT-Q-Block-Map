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


        GameObject.Find(room).GetComponent<TargetScript>().active = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }






}
