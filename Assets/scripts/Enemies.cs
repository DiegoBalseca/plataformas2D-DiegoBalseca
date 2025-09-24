using UnityEngine;

public class Enemies : MonoBehaviour
{


    private Rigidbody2D _rigidBody;
    private Animator _animator;
    [SerializeField] private float DirectionEnemy = 1;


    

    [SerializeField] private float _enemiesVelocity = 5;






    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "limites")
        {
            if (DirectionEnemy == 1)
            {
                DirectionEnemy = -1;
            }
            else
            {
                DirectionEnemy = 1;
            }
        }
    }

    
    
    
    void FixedUpdate()
    {
    

         _rigidBody.linearVelocity = new Vector2(DirectionEnemy * _enemiesVelocity, _rigidBody.linearVelocityY);   
    }

    void Movement2()
    {

    }
}
