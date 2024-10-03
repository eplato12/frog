using System.Collections;
using UnityEngine;

public class lily : MonoBehaviour
{
    public Sprite evilLily;
    public Sprite niceLily;
    private SpriteRenderer spriteRenderer;

    public float rotationSpeed = 90f;
    private int rotate;
    private bool isEvil = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rotate = Random.Range(0, 2) == 0 ? 1 : -1;
        UpdateSprite();
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * rotate * Time.deltaTime);
    }

    public void speedIncrease(float num)
    {
        rotationSpeed *= num;
    }

    public void SetIsEvil(bool evil)
    {
        isEvil = evil;
        UpdateSprite();
    }

    public void increaseBy(float x)
    {
        rotationSpeed *= x;
    }

    void UpdateSprite()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer == null)
        {
            return;
        }

        if (isEvil)
        {
            spriteRenderer.sprite = evilLily;
        }
        else
        {
            spriteRenderer.sprite = niceLily;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && isEvil)
        {
            StartCoroutine(IncreaseRotationSpeedForSeconds(10f));
        }
    }

    private IEnumerator IncreaseRotationSpeedForSeconds(float speedMultiplier)
    {
        float targetSpeed = rotationSpeed;
        float currentSpeed=rotationSpeed * speedMultiplier;
        float lerpTime=5;
        float elapsedTime=0;

        while (elapsedTime < lerpTime)
        {
            rotationSpeed = Mathf.Lerp(currentSpeed, targetSpeed, elapsedTime / lerpTime);
            elapsedTime += Time.deltaTime;


            yield return null;

        }
        rotationSpeed = targetSpeed;
        yield return null;
    }

}

