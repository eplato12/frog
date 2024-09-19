using UnityEngine;
using System.Collections;

public class FrogScript : MonoBehaviour
{
    public Sprite[] frogSprites;
    public float speed;
    public AudioClip frogJump;
    private Rigidbody2D rb;
    private float jumpForce = 2f;
    private AudioSource frogAudio;
    private SpriteRenderer frogSprite;


    void Start()
    {
        frogSprite = GetComponent<SpriteRenderer>();
        frogAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayAudio(frogJump);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
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

    private void PlayAudio(AudioClip clip)
    {
        frogAudio.PlayOneShot(clip);
    }

 
  
}
