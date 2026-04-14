using UnityEngine;

public class ConstantScript : MonoBehaviour
{
    [Header("Held Variables")]
    public string room = "";

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);                 //keeps this gameobject active across scene changes, good for carrying variables across scenes
    }

    // Update is called once per frame
    void Update()
    {
    }
}
