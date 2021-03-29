using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    // Start is called before the first frame update
    private float fPower = 0.0f;
    public float fPowerMax = 1.0f;
    private bool bFire = false;
    private float fFireTime = 0.0f;
    private float fFireTimeMax = 0.05f;
    public Rigidbody BallBody;
    public Transform BallTransform;
    private bool bFireEnable = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            fPower += Time.deltaTime * 3.0f;

            if (fPower >= fPowerMax)
                fPower = fPowerMax;

            Vector3 vScale = transform.localScale;

            vScale.y = (((fPowerMax - fPower) / fPowerMax) * 0.5f + 0.5f) * 0.2f;

            transform.localScale = vScale;
        }

        if (Input.GetKeyUp(KeyCode.Space) && bFireEnable)
        {
            fPower = 0.0f;
            bFire = true;
            BallBody.AddForce(BallTransform.forward * 60.0f, ForceMode.Impulse);
            Debug.Log("Fire");
            bFireEnable = false;
        }

        if (bFire)
        {
            fFireTime += Time.deltaTime;

            if (fFireTime >= fFireTimeMax)
            {
                fFireTime = 0.0f;
                bFire = false;
                transform.localScale = new Vector3(0.1f, 0.2f, 0.1f);
            }

            else
            {
                float fScaleY = fFireTime / fFireTimeMax * 0.1f;

                transform.localScale = new Vector3(0.1f, 0.1f + fScaleY, 0.1f);
            }
        }
    }
}
