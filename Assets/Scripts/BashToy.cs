using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BashToy : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ScoreText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();

            ball.Score += 10;

            //Destroy(gameObject);
            DestroyObject(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            Ball ball = other.gameObject.GetComponent<Ball>();

            ball.Score += 10;

            ScoreText.text = "Score : " + ball.Score.ToString();

            //Destroy(gameObject);
            DestroyObject(gameObject);
        }
    }
}
