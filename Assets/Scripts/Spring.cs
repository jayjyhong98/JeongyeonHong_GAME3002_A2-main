using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    // Start is called before the first frame update
    private float fPower = 0.0f;
    public float fPowerMax = 10.0f;
    public Transform SpringTransform;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            fPower += Time.deltaTime * 2.5f;

            if (fPower >= fPowerMax)
                fPower = fPowerMax;

            Vector3 vScale = SpringTransform.localScale;

            vScale.y = ((fPowerMax - fPower) / fPowerMax) * 0.5f + 0.5f;

            SpringTransform.localScale = vScale;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            fPower = 0.0f;
            SpringTransform.localScale = Vector3.one;
        }
    }
}
