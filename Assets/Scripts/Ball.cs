using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody Body = GetComponent<Rigidbody>();

        Vector3 vDir = Body.velocity;
        vDir.Normalize();

        Vector3 vReflect = Vector3.Reflect(vDir, collision.contacts[0].normal);

        Body.AddForce(vReflect * 50.0f);
    }
}
