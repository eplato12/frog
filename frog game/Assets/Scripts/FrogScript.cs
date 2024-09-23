using UnityEngine;
using System.Collections;

public class FrogScript : MonoBehaviour
{
    public Sprite[] frogSprites;
    public AudioClip frogJump;
    private AudioSource frogAudio;
    private SpriteRenderer frogSprite;
    private float jumpDistance = 1f;
    public Rigidbody2D rb;
    public GameObject firstLily;


    void Start()
    {
        frogSprite = GetComponent<SpriteRenderer>();
        frogAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        transform.parent = firstLily.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            if (!IsLily(transform.position))
            {
                //FrogDie();
                frogSprite.enabled = false;
            }
        }
        RotateFrog();
    }

    void Jump()
    {
        transform.position += transform.up * jumpDistance;
        PlayAudio(frogJump);
        StartCoroutine(Animate());
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

    private IEnumerator Animate()
    {
        for (int i = 0; i < frogSprites.Length; i++)
        {
            frogSprite.sprite = frogSprites[i];
            yield return new WaitForSeconds(0.1f);
        }
    }

    protected bool IsLily(Vector2 gridPosition)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gridPosition, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("lily"))
            {
                transform.parent = collider.gameObject.transform;
                transform.localPosition = new Vector3(0, 0, 0);
                return true;
            }
        }
        return false;
    }

}


