using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Player_0 PlayerScript;
    private float _speed = 1.5f;
    private Vector3 moveDelta;
    
    void Start()
    {
        PlayerScript.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDelta = new Vector3(horizontalInput, verticalInput);

        if (moveDelta.x > 0)
        {
            PlayerScript.transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            PlayerScript.transform.localScale = new Vector3(-1, 1, 0);
        }

        PlayerScript.Move(moveDelta, _speed);
    }
}


