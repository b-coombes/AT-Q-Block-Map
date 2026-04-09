using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private SpriteRenderer playerSprite;
    private GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        arrow = GameObject.Find("Arrow");
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (moveInput.x < 0)
        {
            playerSprite.flipX = true;
        }
        if (moveInput.x > 0)
        {
            playerSprite.flipX = false;
        }
    }


}
