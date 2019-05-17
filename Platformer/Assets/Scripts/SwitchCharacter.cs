using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Swiches player sprite by pressing 1, 2, or 3
public class SwitchCharacter : MonoBehaviour
{
    public Sprite rock, paper, scissor; 

    private SpriteRenderer spriteRenderer;

    // Set rock, paper, scissor into sprites inside Resources file
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rock = Resources.Load<Sprite>("square");
        paper = Resources.Load<Sprite>("circle");
        scissor = Resources.Load<Sprite>("triangle");

        if (spriteRenderer.sprite == null) // player initialized to rock
            spriteRenderer.sprite = rock; 
    }

    // Update is called once per frame, change sprites when 1, 2, or 3 pressed
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))    //if 1 pressed, display square
            spriteRenderer.sprite = rock;
        
        else if (Input.GetKeyDown(KeyCode.Alpha2))   // if 2 pressed, display circle        
            spriteRenderer.sprite = paper;

        else if (Input.GetKeyDown(KeyCode.Alpha3))  // if 3 pressed, display triangle
            spriteRenderer.sprite = scissor;

    }
}