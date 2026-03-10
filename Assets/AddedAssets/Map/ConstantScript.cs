using UnityEngine;

public class ConstantScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string room = "";

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
