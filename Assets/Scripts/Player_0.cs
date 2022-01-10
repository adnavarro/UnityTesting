using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_0 : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.freezeRotation = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Move(Vector3 moveDelta, float speed)
    {
        rigidBody.velocity = (moveDelta * speed);
    }
}