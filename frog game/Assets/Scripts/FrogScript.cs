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

    [SerializeField] private ParticleSystem bubbleSystem;

    private AudioSource frogAudio;
    private SpriteRenderer frogSprite;
    private float jumpDistance = 1f;
    private ParticleSystem bubbleSystemInstance;

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
                if (IsLily(transform.position))
                {
                    spawnBubbles();
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
                }
            }
            PlayAudio(splash);
            StartCoroutine(advanceScene.LoadTempScene("Frog Die", SceneManager.GetActiveScene().name));
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
                return true;
            }
        }
        return false;
    }

    private void spawnBubbles()
    {
        bubbleSystemInstance = Instantiate(bubbleSystem, transform.position, Quaternion.identity);
    }
}


