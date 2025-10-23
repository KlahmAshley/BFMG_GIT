using UnityEngine;

public class LerpBubble : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float speed;
    private Transform current;
    private Transform target;
    private float sinTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current = pointA;
        target = pointB;
        transform.position = current.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target.position)
        {
            sinTime += Time.deltaTime * speed;
            sinTime = Mathf.Clamp(sinTime, 0, Mathf.PI);
            float t = Evaluate(sinTime);
            transform.position = Vector3.Lerp(current.position, target.position, t);
        }

        Swap();

    }

    public void Swap()
    {
        if (transform.position != target.position)
        {
            return;
        }

        Transform t = current;
        current = target;
        target = t;
        sinTime = 0;
    }

    public float Evaluate(float x)
    {
        return 0.5f * Mathf.Sin(x - Mathf.PI / 2f) + 0.5f;
    }
}
