using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public enum BumperType
    {
        Active,
        Passive
    }

    // Start is called before the first frame update
    public BumperType Type;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            //Debug.Log("Bumper Collision");
            if (Type == BumperType.Active)
            {
                Rigidbody Body = collision.gameObject.GetComponent<Rigidbody>();

                Vector3 vDir = Body.velocity;
                vDir.Normalize();

                float fLength = Body.velocity.magnitude;

                Vector3 vReflect = Vector3.Reflect(vDir, collision.contacts[0].normal);

                //Body.AddForce(vReflect * 50.0f);
                //Body.AddForce(vReflect * 50.0f);
                Body.velocity = vReflect * fLength;
            }

            else
            {
                Rigidbody Body = collision.gameObject.GetComponent<Rigidbody>();

                Body.velocity *= 0.5f;
            }
        }
    }
}
