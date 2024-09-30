using UnityEngine;

public class lily : MonoBehaviour
{
    public Sprite evilLily;
    public Sprite niceLily;
    private SpriteRenderer spriteRenderer;

    public float rotationSpeed = 30f;
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

    public void SetIsEvil(bool evilState)
    {
        isEvil = evilState;
        UpdateSprite(); 
    }

    void UpdateSprite()
    {
        if (isEvil)
        {
            spriteRenderer.sprite = evilLily;
        }
        else
        {
            spriteRenderer.sprite = niceLily;
        }
    }
}

