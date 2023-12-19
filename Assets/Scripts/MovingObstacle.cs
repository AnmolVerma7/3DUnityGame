using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float distance = 2.0f;
    public float speed = 2.0f;
    private Vector3 centerPosition;
    private float minX;
    private float maxX;

    // Start is called before the first frame update
    void Start()
    {
        centerPosition = transform.position;
        minX = centerPosition.x - distance;
        maxX = centerPosition.x + distance;
    }

    // Update is called once per frame
    void Update()
    {
        float newX = centerPosition.x + Mathf.PingPong(Time.time * speed, maxX - minX);
        transform.position = new Vector3(newX, centerPosition.y, centerPosition.z);
    }
}
