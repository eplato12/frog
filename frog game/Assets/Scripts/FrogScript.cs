using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FrogScript : MonoBehaviour
{
    public Sprite[] frogSprites;
    public AudioClip frogJump;
    public AudioClip splash;
    public Rigidbody2D rb;
    public GameObject firstLily;
    public AdvanceScene advanceScene;

    private AudioSource frogAudio;
    private SpriteRenderer frogSprite;
    private float jumpDistance = 1f;
    

    void Start()
    {
        frogSprite = GetComponent<SpriteRenderer>();
        frogAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        //transform.parent = firstLily.transform;
        transform.position = firstLily.transform.position;
    }

    void Update()
    {
        if (transform.position != firstLily.transform.position)
        {
            firstLily.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            if (IsPortal(transform.position))
            {
                string nextScene = GetNextScene(SceneManager.GetActiveScene().name);
                if (!string.IsNullOrEmpty(nextScene))
                {
                    advanceScene.toLevel(nextScene);
                }
            }
            else
            {
                IsLily(transform.position);
            }

        }
    }

    void Jump()
    {
        transform.position += transform.up * jumpDistance;
        PlayAudio(frogJump);
        StartCoroutine(Animate());
    }

    private string GetNextScene(string currentScene)
    {
        switch (currentScene)
        {
            case "Level 1": return "Level 2";
            case "Level 2": return "Level 3";
            case "Level 3": return "Level 4";
            case "Level 4": return "Win";
            default: return null;
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

    protected void IsLily(Vector2 gridPosition)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gridPosition, 0.1f);
        bool isOnLily = false; // Flag to check if on a lily pad

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("lily"))
            {
                // Parent to the lily and reset position
                transform.parent = collider.gameObject.transform;
                transform.localPosition = Vector3.zero; // Set to local position (0, 0, 0)
                isOnLily = true; // Set flag indicating we're on a lily
                break; // Exit loop if we've found a lily pad
            }
        }

        // If not on a lily, handle splash
        if (!isOnLily)
        {
            PlayAudio(splash);
            advanceScene.toLevel("Frog Die"); // Transition to "Frog Die"
        }
    }


    protected bool IsPortal(Vector2 gridPosition)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gridPosition, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("portal"))
            {
                return true;
            }
        }
        return false;
    }

}


