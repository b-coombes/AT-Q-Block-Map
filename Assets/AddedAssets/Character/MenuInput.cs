using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class MenuInput : MonoBehaviour
{

    [Header("References")]
    public GameObject DoNotDestroy;

    public TextMeshProUGUI floorNumberText;
    
    public TextMeshProUGUI roomNumOneText;
    
    public TextMeshProUGUI roomNumTwoText;

    private TextMeshProUGUI activeText;
    
    public TextMeshProUGUI errorText;

    [Header("Configurations")]
    public int activeNum;

    private float blinkTimer;
    private float inputTimer;

    private string room;
    private string[] rooms;

    private List<string> roomList = new List<string>();

    private int roomSlot;
    
    private bool invis;

    private Gamepad gamepad;

    


    // Start is called before the first frame update
    private void Start()
    {
        blinkTimer = Time.time + 1f;
        activeText = floorNumberText;
        activeNum = Int32.Parse(activeText.text);




        string[] rooms = new string[33];
        for (int i = 0; i < 54; i++)
        {
            if (i != 0 && i != 1 && i != 2 && i != 3 && i != 7 && i != 8 && i != 9 && i != 10 && i != 11 && i != 27 && i != 30 && i != 31 && i != 34 && i != 36 && i != 37 && i != 38 && i != 39 && i != 40 && i != 41 && i != 44 && i != 51)
            {

                //rooms[i] = "2Q" + (i+1).ToString("D2");
                //Debug.Log(i.ToString("D2"));
                roomList.Add("2Q" + i.ToString("D2"));
            }
        }
        



    }
    // Update is called once per frame
    void Update()
    {
        gamepad = Gamepad.current;
        if (gamepad == null)
        {
            return;
        }
        else
        {
            Vector2 dpadValue = gamepad.dpad.ReadValue();


            if (dpadValue.x == -1.00) //left
            {
                ChangeHorizontal("Left");
                //Debug.Log("L");
            }
            if (dpadValue.x == 1.00) //right
            {
                ChangeHorizontal("Right");
                //Debug.Log("R");
            }
            if (dpadValue.y == 1.00) //up
            {
                ChangeVertical("Up");
                //Debug.Log("U");
            }
            if (dpadValue.y == -1.00) //down
            {
                ChangeVertical("Down");
                //Debug.Log("D");
            }

            if (gamepad.buttonSouth.wasPressedThisFrame)
            {
                Check();
            }

        }


        //blinking affect on active number
        if (blinkTimer <= Time.time)
        {

            if (!invis)
            {
                activeText.text = "";
                blinkTimer = Time.time + 0.3f;
                invis = true;
            }
            else
            {
                activeText.text = activeNum.ToString();
                blinkTimer = Time.time + 0.3f;
                invis = false;
            }
        }
    }

    void ChangeVertical(string upOrDown)
    {
        if (Time.time >= inputTimer)
        {
            if (upOrDown == "Up")
            {
                if (activeNum != 9)
                {
                    activeNum += 1;
                }
                else
                {
                    activeNum = 0;
                }
            }
            if (upOrDown == "Down")
            {
                if (activeNum != 0)
                {
                    activeNum -= 1;
                }
                else
                {
                    activeNum = 9;
                }
            }
            activeText.text = activeNum.ToString();
            inputTimer = Time.time + 0.2f;
        }
    }

    void ChangeHorizontal(string leftOrRight)
    {

        if (Time.time >= inputTimer)
        {
            activeText.text = activeNum.ToString();
            if (leftOrRight == "Left")
            {
                if (roomSlot != 1)
                {
                    roomSlot -= 1;
                }
                else
                {
                    roomSlot = 3;
                }
            }
            if (leftOrRight == "Right")
            {
                if (roomSlot != 3)
                {
                    roomSlot += 1;
                }
                else
                {
                    roomSlot = 1;
                }
            }
            if (roomSlot == 1)
            {
                activeText = floorNumberText;
            }
            if (roomSlot == 2)
            {
                activeText = roomNumOneText;
            }
            if (roomSlot == 3)
            {
                activeText = roomNumTwoText;
            }
            activeNum = Int32.Parse(activeText.text);
            inputTimer = Time.time + 0.2f;
            //Debug.Log("run count");
        }
    }


    private void Check()
    {
        if (Time.time >= inputTimer)
        {
            activeText.text = activeNum.ToString();
            room = floorNumberText.text + "Q" + roomNumOneText.text + roomNumTwoText.text;
            //Debug.Log(room);

            bool correct = false;




            //for (int i = 0; i < rooms.Length; i++)


            for (int i = 0; i < roomList.Capacity; i++)
            {
                //Debug.Log("Check: " + roomList[i]);
                if (room == roomList[i])
                {
                    GameObject.Find("DoNotDestroyOnLoad").GetComponent<ConstantScript>().room = room;
                    Debug.Log("Output:" + GameObject.Find("DoNotDestroyOnLoad").GetComponent<ConstantScript>().room);
                    SceneManager.LoadScene(1);
                    correct = true;
                }
            }
            if (!correct)
            {
                errorText.text = "Please input valid room";
                room = "";
            }

            inputTimer = Time.time + 1f;
        }
    }
}
