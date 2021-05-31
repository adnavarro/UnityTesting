using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7.4f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit by: " + other.transform.name);

        if (other.transform.name == "Player")
        {
            Destroy(GameObject.FindWithTag(other.transform.name));
        }
        else if (other.transform.name == "Laser(Clone)")
        {
            Destroy(GameObject.FindWithTag("Laser"));
            Destroy(this.gameObject);
        }
    }
}
