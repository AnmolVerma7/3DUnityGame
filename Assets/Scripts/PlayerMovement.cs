using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Reference to Rigidbody Component called "rb"
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float upwardsForce = 1f;
    public bool grounded = true;
    // Mark this as "Fixed Update"


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground")) 
        { 
            grounded = true; 
        }
    }
 
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground")) 
        { 
            grounded = false; 
        }
    }

    public void Update() {
        if (Input.GetKeyDown("space") && grounded == true) 
        {
            rb.AddForce(0, upwardsForce, 0 * Time.deltaTime, ForceMode.Impulse);
            grounded = false;
        }
    }
    
    void FixedUpdate() 
    {

        var s = rb.transform.localScale;

        // Add forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // User Input
        if (Input.GetKey("d")) 
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0 , 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a")) 
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0 , 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.LeftControl)) 
        {
            rb.transform.localScale = new Vector3(0.5f, 1, 1);
        }
        else 
        {
            rb.transform.localScale = new Vector3(1, 1, 1);
        }

        if (rb.position.y < -1f) 
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
