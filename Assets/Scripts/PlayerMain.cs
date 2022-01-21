using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.freezeRotation = true;
    }

    public void Move(Vector2 moveDelta, float speed)
    {
        rigidBody.velocity = (moveDelta * speed);
    }
}