using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerMain playerMain;
    private float _speed = 1.5f;
    private Vector2 moveDelta;
    
    void Start()
    {
        playerMain.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDelta.x = Input.GetAxis("Horizontal");
        moveDelta.y = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        if (moveDelta.x > 0)
        {
            playerMain.transform.localScale = Vector2.one;
        }
        else if (moveDelta.x < 0)
        {
            playerMain.transform.localScale = new Vector2(-1, 1);
        }

        playerMain.Move(moveDelta, _speed);
    }
}


