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
    public lily lilly;
    public float lilyPadColliderWidth;
    public GameObject frogLegs;
    public GameObject arrow;

    private AudioSource frogAudio;
    private SpriteRenderer frogSprite;
    private float jumpDistance = 1f;
    private Animator frogAnimator;
    private float newSpeed = 2.0f;


    void Start()
    {
        frogSprite = GetComponent<SpriteRenderer>();
        frogAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        frogAnimator = GetComponent<Animator>();
        frogSprite.enabled = true;
        transform.position = firstLily.transform.position;
        frogAnimator.SetBool("isJumping", false);
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
        frogAnimator.SetBool("isJumping", true);
        transform.position += transform.up * jumpDistance;
        PlayAudio(frogJump);
        StartCoroutine(HandleLanding());
    }

    private IEnumerator HandleLanding()
    {
        yield return new WaitForSeconds(frogAnimator.GetCurrentAnimatorStateInfo(0).length);
        frogAnimator.SetBool("isJumping", false);  
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

    private void IsLily(Vector2 gridPosition)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gridPosition, lilyPadColliderWidth);
        bool isOnLily = false; // Flag to check if on a lily pad

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("lily"))
            {
                transform.parent = collider.gameObject.transform;
                transform.localPosition = Vector3.zero;
                isOnLily = true;
                break;
            }
            else if (collider.CompareTag("evilLily"))
            {
                transform.parent = collider.gameObject.transform;
                transform.localPosition = Vector3.zero;
                isOnLily = true;
                SpeedUpLilies(); 
                break;
            }
        }
        if (!isOnLily)
        {
            StartCoroutine(FrogDead());
        }
    }

    private IEnumerator FrogDead()
    {
        PlayAudio(splash);
        arrow.SetActive(false);
        frogSprite.enabled = false;

        Instantiate(frogLegs, transform.position, Quaternion.identity);
        
        yield return new WaitForSeconds(0.5f);
        advanceScene.Invoke("ReloadScene", 0.5f);
    }


    private void SpeedUpLilies()
    {
        if (lilly != null)
        {
            lilly.speedIncrease(newSpeed);
        }
    }


    public void GoToDeathScene()

    {
        advanceScene.toLevel("Frog Die");
    }


    private bool IsPortal(Vector2 gridPosition)
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


