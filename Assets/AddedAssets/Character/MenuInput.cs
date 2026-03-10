using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInput : MonoBehaviour
{
    public GameObject DoNotDestroy;

    public TextMeshProUGUI playerText;

    private float timer;

    private string room;
    private string[] rooms;

    // Start is called before the first frame update
    private void Start()
    {

        rooms = new string[3] { "2Q24", "2Q28", "3Q22" };
    }



    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timer)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Add("Q");
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Add("0");
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Add("1");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Add("2");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Add("3");
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Add("4");
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Add("5");
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                room = room.Remove(room.Length - 1);
                playerText.text = room;
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Check();

            }
        }
    }

    private void Add(string input)
    {
        room += input;
        timer = Time.time + 0.5f;
        playerText.text = room;
        
    }
    private void Check()
    {
        bool correct = false;
        for (int i = 0; i < rooms.Length; i++)
        {
            Debug.Log("Check: " +  rooms[i]);
            if (room == rooms[i])
            {
                GameObject.Find("DoNotDestroyOnLoad").GetComponent<ConstantScript>().room = room;
                Debug.Log("Output:" + GameObject.Find("DoNotDestroyOnLoad").GetComponent<ConstantScript>().room);
                SceneManager.LoadScene(1);
                correct = true;
            }
        }
        if (!correct)
        {
            playerText.text = "Please input valid room";
            room = "";
        }




    }

}
