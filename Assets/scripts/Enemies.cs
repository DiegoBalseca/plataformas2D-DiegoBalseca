using UnityEngine;

public class Enemies : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Animator _animator;

    [SerializeField] private float DirectionEnemy = 1;
    [SerializeField] private float _enemiesVelocity = 5;

    [SerializeField] private int _maxHealth = 3;
    private int _currentHealth;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log($"enemigo recibio el ataque. Vida restante: {_currentHealth}");

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemigo muerto");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("limites"))
        {
            DirectionEnemy = -DirectionEnemy;
        }
    }

    void FixedUpdate()
    {
        _rigidBody.linearVelocity = new Vector2(DirectionEnemy * _enemiesVelocity, _rigidBody.linearVelocityY);
    }
}

