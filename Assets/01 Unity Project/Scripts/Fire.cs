using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed = 8.0f;
    private Rigidbody fireRigidbody = default;

    // Start is called before the first frame update
    void Start()
    {
        fireRigidbody = GetComponent<Rigidbody>();
        fireRigidbody.velocity = transform.forward * speed;

        //Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Destroy(gameObject);
            other?.GetComponent<PlayerController>().Die();
        }

        //if (other.tag.Equals("Wall"))
        //{
        //    Destroy(gameObject);
        //}
    }       //OnTriggerEnter()
}
