using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public bool active;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCharacter")
        {
            if (active)
            {
                Debug.Log("Active Collider");
            }
            else
            {
                Debug.Log("Inactive Collider");
            }
        }
    }
}
