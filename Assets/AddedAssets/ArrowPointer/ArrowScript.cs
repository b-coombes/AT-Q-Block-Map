using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [Header("References")]
    public GameObject Target;
    public GameObject Arrow;
    private GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string room = GameObject.Find("DoNotDestroyOnLoad").GetComponent<ConstantScript>().room;        //pulls data stored from other scene
        if (room.Length == 4)
        {
            Target = GameObject.Find(room);                                                             //room is identical to gameobject names
        }
        if (Target == null)
        {
            Debug.Log("Target GameObject not set");
        }

        player = GameObject.Find("PlayerCharacter");                                                    //assign player to get position

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null) //
        {
            var dir = Target.transform.position - transform.position;                                   //direction of target room from player

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);                          //sets angle based on room direction

            if (player.transform.position.x > Target.transform.position.x)                              //if target is on the left of the player, sets the arrows position to the left of the player
            {
                Vector3 tempValue = player.transform.position;                                          //temp value created to change one axis value
                tempValue.x = player.transform.position.x - 2;
                Arrow.transform.position = tempValue;                                                           
            }
            if (player.transform.position.x < Target.transform.position.x)                              //if target is on the right of the player, sets the arrows position to the right of the player
            {
                Vector3 tempValue = player.transform.position;
                tempValue.x = player.transform.position.x + 2;
                Arrow.transform.position = tempValue;
            }
        }
        else
        {
            Arrow.SetActive(false);
        }
    }
}
