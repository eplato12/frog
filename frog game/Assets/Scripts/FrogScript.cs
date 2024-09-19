using UnityEngine;
using System.Collections;

public class FrogScript : MonoBehaviour
{
    public Sprite[] frogSprites;
    public AudioClip frogJump;
    private AudioSource frogAudio;
    private SpriteRenderer frogSprite;
    public Rigidbody2D rb;


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
            Jump();
        }
        RotateFrog();
    }

    void Jump()
    {
        
        //Vector3 jumpDirection = transform.up;
        rb.AddForce(transform.up * 50f);
        rb.linearVelocity = Vector2.zero;
        //transform.position += transform.up * jumpDistance;
        PlayAudio(frogJump); 
    }

    void RotateFrog()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, 90 * Time.deltaTime); 
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -90 * Time.deltaTime); 
        }
    }

    private void PlayAudio(AudioClip clip)
    {
        frogAudio.PlayOneShot(clip);
    }
}


