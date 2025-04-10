using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 2f;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public AudioSource moveAudioSource;

    private bool isMoving = false;
    private Vector3 targetPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                float randomDirection = Random.Range(0f, 1f) > 0.5f ? 1f : -1f;
                targetPosition = transform.position + new Vector3(randomDirection * moveDistance, 0, 0);
                isMoving = true;
                spriteRenderer.flipX = randomDirection > 0;

                if (moveAudioSource != null && !moveAudioSource.isPlaying)
                {
                    moveAudioSource.Play();
                }
            }
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                isMoving = false;

                if (moveAudioSource != null && moveAudioSource.isPlaying)
                {
                    moveAudioSource.Stop();
                }
            }
        }

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        animator.SetBool("isRunning", isMoving);
    }
}
