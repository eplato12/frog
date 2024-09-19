using UnityEngine;
using System.Collections;

public class FrogScript : MonoBehaviour
{
    public Sprite[] frogSprites;
    public AudioClip frogJump;
    private AudioSource frogAudio;
    private SpriteRenderer frogSprite;

    public float jumpDistance = 1f; 

    void Start()
    {
        frogSprite = GetComponent<SpriteRenderer>();
        frogAudio = GetComponent<AudioSource>();
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
        
        Vector3 jumpDirection = transform.up; 
        transform.position += transform.up * jumpDistance; 
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


