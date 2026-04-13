using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public bool active;
    public Material inactiveMaterial;
    public Material activeMaterial;
    public GameObject completionText;

    // Start is called before the first frame update
    void Start()
    {
        if (!active)
        {
            this.GetComponent<Renderer>().material = inactiveMaterial;
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            this.GetComponent<Renderer>().material = activeMaterial;
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.gold);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCharacter")
        {
            if (active)
            {
                Debug.Log("Active Collider");
                completionText.SetActive(true);
            }
            else
            {
                Debug.Log("Inactive Collider");
            }
        }
    }
}
