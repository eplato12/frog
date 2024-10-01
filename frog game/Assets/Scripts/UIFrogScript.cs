using UnityEngine;

public class UIFrogScript : MonoBehaviour
{
    public float leftBoundary = -12f; // Adjust to your left limit
    public float rightBoundary = 12f; // Adjust to your right limit
    public float jumpDistance = 2f; // Distance of each jump
    private float moveDirection = 1f; // Direction of movement (1 = right, -1 = left)
    private SpriteRenderer frogSR;
    public float jumpInterval = 1f; // Time interval between jumps
    private float jumpTimer; // Timer to track time between jumps

    void Start()
    {
        frogSR = GetComponent<SpriteRenderer>();
        jumpTimer = jumpInterval;  
    }

    void Update()
    {
        jumpTimer -= Time.deltaTime;  

        if (jumpTimer <= 0f)
        {
            MoveFrog();
            jumpTimer = jumpInterval;  
        }
    }

    void MoveFrog()
    {
        Vector3 newPosition = transform.position + Vector3.right * jumpDistance * moveDirection;

        if (newPosition.x >= rightBoundary || newPosition.x <= leftBoundary)
        {
            moveDirection *= -1;
            FlipSprite();
        }
        else
        {
            transform.position = newPosition;
        }

    }

    private void FlipSprite()
    {
        frogSR.flipX = !frogSR.flipX;
    }
}
