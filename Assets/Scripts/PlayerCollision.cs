using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movementScript;
    void OnCollisionEnter (Collision collisionInfo) 
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movementScript.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
