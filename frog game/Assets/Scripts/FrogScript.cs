using UnityEngine;
using System.Collections;

public class FrogScript : MonoBehaviour
{
    public Sprite[] frogSprites;
    public AudioClip frogJump;
    private Rigidbody2D rb;
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
        Vector2 vel = rb.linearVelocity;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += Vector3.up * 1f;
        }
    }

    private void PlayAudio(AudioClip clip)
    {
        frogAudio.PlayOneShot(clip);
    }

}
