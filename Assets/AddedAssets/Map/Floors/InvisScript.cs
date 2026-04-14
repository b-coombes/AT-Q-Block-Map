using UnityEngine;

public class InvisScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;     //makes borders invisible when map is loaded
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
