using Unity.VisualScripting;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    public GameObject Target;
    private GameObject player;
    private GameObject arrow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string room = GameObject.Find("DoNotDestroyOnLoad").GetComponent<ConstantScript>().room;
        Target = GameObject.Find(room);
        player = GameObject.Find("PlayerCharacter");
        arrow = GameObject.Find("Arrow");
    }

    // Update is called once per frame
    void Update()
    {

        var dir = Target.transform.position - transform.position;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        if (player.transform.position.x > Target.transform.position.x)
        {
            Vector3 tempValue = player.transform.position;
            tempValue.x = player.transform.position.x - 2;
            arrow.transform.position = tempValue;
        }
        if (player.transform.position.x < Target.transform.position.x)
        {
            Vector3 tempValue = player.transform.position;
            tempValue.x = player.transform.position.x + 2;
            arrow.transform.position = tempValue;
        }



    }
}
