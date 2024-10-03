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
            StartCoroutine(IncreaseRotationSpeedForSeconds(2f));
        }
    }

    private IEnumerator IncreaseRotationSpeedForSeconds(float speedMultiplier)
    {
        float originalSpeed = rotationSpeed;
        rotationSpeed *= speedMultiplier;

        yield return new WaitForSeconds(10f); 

        rotationSpeed = originalSpeed; 
    }

}

