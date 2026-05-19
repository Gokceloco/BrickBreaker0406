using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private Vector3 _direction;

    private void Start()
    {
        _direction = new Vector3(Random.Range(-1f, 1f), 1, 0);
    }

    private void Update()
    {
        rb.linearVelocity = _direction.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        _direction = Vector3.Reflect(_direction, collision.contacts[0].normal);

        if (collision.gameObject.CompareTag("Brick"))
        {
            collision.gameObject.GetComponent<Brick>().GetHit();
            GetComponentInParent<BallManager>().audioManager.PlayEnemyHitAS();
        }
        if (collision.gameObject.CompareTag("BottomWall"))
        {
            GetComponentInParent<BallManager>().BallDestroyed(this);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.x > transform.position.x + .3f)
            {
                _direction = new Vector3(-1f, 1f, 0);
            }
            else if (collision.transform.position.x < transform.position.x - .3f)
            {
                _direction = new Vector3(1f, 1f, 0);
            }
        }

        GetComponentInParent<BallManager>().audioManager.PlayBallImpactAS();
    }
}
