using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5.8f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Powerup enabled");

            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.TripleShootActive();
            }
            else
            {
                Debug.Log("ERROR: The component Player is null");
            }
            Destroy(this.gameObject);
        }
    }
}
