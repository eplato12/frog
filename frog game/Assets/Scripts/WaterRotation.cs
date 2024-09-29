using UnityEngine;

public class WaterRotation : MonoBehaviour
{
    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (Random.value < 0.5f)
            speed = -1 * Random.Range(10, 20);
        else
            speed = Random.Range(10, 20);



    }

    // Update is called once per frame
    void Update()
    {
        float angle = speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(angle,
        Vector3.forward);
    }
}
