using System.Collections;
using UnityEngine;

public class RandomMovementAndCloning : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения
    public float moveDuration = 2f; // Время движения
    public GameObject clonePrefab; // Префаб клона
    public float cloneLifetime = 5f; // Время жизни клона
    public GameObject additionalObjectPrefab; // Префаб дополнительных объектов
    public float additionalObjectLifetime = 3f; // Время жизни дополнительных объектов
    public AudioClip clickSound; // Аудиоклип, проигрываемый при клике

    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Проверка, попал ли клик по этому объекту (с его коллайдером)
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Воспроизводим звук при клике
                if (clickSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(clickSound);
                }

                // Запускаем движение и клонирование
                StartCoroutine(MoveAndClone(hit.point));
            }
        }
    }

    IEnumerator MoveAndClone(Vector3 targetPos)
    {
        // Генерируем случайное направление
        Vector3 direction = (targetPos - transform.position).normalized;
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;

        // Включаем анимацию движения
        animator.SetBool("IsMoving", true);

        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            // Двигаем персонажа в случайном направлении
            transform.position += randomDirection * moveSpeed * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Останавливаем анимацию движения
        animator.SetBool("IsMoving", false);

        // Клонируем персонажа
        if (clonePrefab != null)
        {
            GameObject clone = Instantiate(clonePrefab, transform.position, transform.rotation);
            Destroy(clone, cloneLifetime);

            // Ждем, пока клон исчезнет
            yield return new WaitForSeconds(cloneLifetime);

            CreateAdditionalObjects();
        }
    }

    void CreateAdditionalObjects()
    {
        // Создаем дополнительные объекты на случайной позиции
        Vector3 randomPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
        if (additionalObjectPrefab != null)
        {
            GameObject additionalObject = Instantiate(additionalObjectPrefab, randomPosition, Quaternion.identity);
            Destroy(additionalObject, additionalObjectLifetime);
        }
    }
}