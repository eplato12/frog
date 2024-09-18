using UnityEngine;

public class WaterRotation : MonoBehaviour
{
    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        float angle = speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(angle,
        Vector3.forward);
    }
}
