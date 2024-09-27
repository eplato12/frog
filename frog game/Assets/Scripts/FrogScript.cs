using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FrogScript : MonoBehaviour
{
    public Sprite[] frogSprites;
    public AudioClip frogJump;
    public Rigidbody2D rb;
    public GameObject firstLily;

    private AudioSource frogAudio;
    private SpriteRenderer frogSprite;
    private float jumpDistance = 1f;
    public AdvanceScene advanceScene;


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
                // If the frog is not on a portal, check if it's on a lily pad
                if (!IsLily(transform.position))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
                }
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

    protected bool IsPortal(Vector2 gridPosition)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gridPosition, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("portal"))
            {
                Debug.Log("Frog is at a portal.");
                return true;
            }
        }
        Debug.Log("Frog is not at a portal.");
        return false;
    }

}


