using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 10f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private SpriteRenderer playerSprite;
    private Gamepad gamepad;

    [Header("References")]

    public GameObject completionText;
    public GameObject cancelText;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;                      //Handles movement

        gamepad = Gamepad.current;
        if (gamepad.buttonEast.wasPressedThisFrame)
        {
            if (!completionText.activeInHierarchy)
            {
                if (cancelText.activeInHierarchy)
                {
                    cancelText.SetActive(false);
                }
                else
                {
                    cancelText.SetActive(true);
                }
            }
        }
        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            if (completionText.activeInHierarchy || cancelText.activeInHierarchy)
            {
                SceneManager.LoadScene(0);          //changes current scene to menu scene
            }
        
        }


        }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (moveInput.x < 0)                            //flips player sprite so it matches faced direction
        {
            playerSprite.flipX = true;
        }
        if (moveInput.x > 0)
        {
            playerSprite.flipX = false;
        }

        
    }


}
