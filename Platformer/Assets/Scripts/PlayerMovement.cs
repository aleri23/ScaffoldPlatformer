using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    /// <summary>
    /// PlayeMovement handles the movement of the player by specifying player speed, reading user Input,
    /// and calling CharacterController2D to move the Player Object  
    /// </summary>
    
    [SerializeField] private float runSpeed;
    float horizontalMove = 0f;
    bool jump = false;
    public CharacterController2D controller;

    void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }
    // Update is called once per frame
     void Update()
    {
        if (Input.GetMouseButton(0))
        {
            horizontalMove = ((Input.mousePosition[0] - (Screen.width / 2)) / Screen.width) * 4 * runSpeed;
            if ((Input.mousePosition[1]) > 2 * Screen.height / 3)
            {
                jump = true;
            }
        }
        else
        {
            horizontalMove = 0;
        }

    }

    // FixedUpdate is called multiple times per x amount of frames
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
