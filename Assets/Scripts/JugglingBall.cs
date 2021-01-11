using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugglingBall : MonoBehaviour
{
    private Rigidbody2D ballRb;
    Vector3 worldPosition;
    private GameObject lifeCounterObject;
    private LifeController lifeScript;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        lifeCounterObject = GameObject.FindGameObjectWithTag("LifeCounter");
        if (lifeCounterObject != null)
        {
            lifeScript = lifeCounterObject.GetComponent<LifeController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnMouseDown()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 currentVelocity = ballRb.velocity;
        Vector2 scatterAngle = ballRb.position-new Vector2(worldPosition.x, worldPosition.y);

        scatterAngle.y = Mathf.Abs(scatterAngle.y);
        Debug.Log(currentVelocity);
        Debug.Log(scatterAngle.normalized);

        ballRb.velocity = currentVelocity+scatterAngle.normalized*Constants.TAP_BOOST;
        if (ballRb.velocity.x > Constants.MAX_HORIZONTAL_VELOCITY)
        {
            //Debug.Log("Horizontal velocity too high, Reducing velocity from " + ballRb.velocity.x + " to " + Constants.MAX_HORIZONTAL_VELOCITY);
            ballRb.velocity =new Vector2(Constants.MAX_HORIZONTAL_VELOCITY, ballRb.velocity.y);
        }
        else if (ballRb.velocity.x < -Constants.MAX_HORIZONTAL_VELOCITY)
        {
            //Debug.Log("Horizontal velocity too high, Reducing velocity from " + ballRb.velocity.x + " to " + Constants.MAX_HORIZONTAL_VELOCITY);
            ballRb.velocity =new Vector2(-Constants.MAX_HORIZONTAL_VELOCITY, ballRb.velocity.y);
        }
        if (ballRb.velocity.y < Constants.MINIMUM_VERTICAL_BOOST)
        {
            //Debug.Log("Low Verical Boost, updating Vertical boost from " + ballRb.velocity.y + " to " + Constants.MINIMUM_VERTICAL_BOOST);
            ballRb.velocity = new Vector2(ballRb.velocity.x, Constants.MINIMUM_VERTICAL_BOOST);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            lifeScript.UpdateLivesText();
            Destroy(gameObject);
        }
    }

}
