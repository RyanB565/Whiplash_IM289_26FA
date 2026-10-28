using UnityEngine;

public class PowerUpBob : MonoBehaviour
{
    public float startY;
    public float bobMagnitude = 0.5f;
    public float bobSpeed = 1f;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        float bob = Mathf.Sin(Time.time * bobSpeed) * bobMagnitude;

        transform.position = new Vector2(transform.position.x, startY * bob);
    }
}
