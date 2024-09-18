using UnityEngine;
using System.Collections;

public class FrogScript : MonoBehaviour
{

    public Sprite[] frogSprites;
    public float speed;
    private SpriteRenderer frogSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        frogSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += transform.up * speed * Time.deltaTime;
            StartCoroutine(AnimateFrog());
        }
    }

    private IEnumerator AnimateFrog()
    {
        for (int i = 0; i < frogSprites.Length; i++)
        {
            frogSprite.sprite = frogSprites[i];
            yield return new WaitForSeconds(0.1f);
        }
    }
}
