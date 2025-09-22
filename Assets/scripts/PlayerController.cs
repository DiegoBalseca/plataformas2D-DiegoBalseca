using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    // private GroundSensor _groundsensor;
    private Animator _animator;
    private InputAction _moveAction;
    private Vector2 _moveInput;
    private InputAction _jumpAction;
    private InputAction _attackAction;
    private InputAction _interactAction;

    [SerializeField] private float _playerVelocity = 5;
    [SerializeField] private float _jumpHeight = 2.5f;
    private bool _alreadyLanded = true;
    [SerializeField] private Transform _sensorPosition;
    [SerializeField] private Vector2 _sensorSize = new Vector2(0.5f, 0.5f);

    [SerializeField] private Vector2 _interactionZone = new Vector2(1, 1);





    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];
        _attackAction = InputSystem.actions["Attack"];
        _interactAction = InputSystem.actions["Interact"];
        //  _groundsensor = GetComponentInChildren<GroundSensor>();
    }
    void Start()
    {

    }


    void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();
        Debug.Log(_moveInput);

        //transform.position = transform.position + new Vector3(_moveInput.x, 0, 0) * _playerVelocity * Time.deltaTime;
        _rigidBody.linearVelocity = new Vector2(_moveInput.x * _playerVelocity, _rigidBody.linearVelocityY);
        

        if (_jumpAction.WasPressedThisFrame() && isGrounded())
        {
            Jump();

        }

        if(_interactAction.WasPerformedThisFrame())
        {
            Interact();
        }
        

        Movement();
        _animator.SetBool("IsJumping", !isGrounded());


        
       
       
    }

    void Movement()
    {
         if(_moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsMoving", true);
        }

        else if(_moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }



    void Jump()
    {
        _rigidBody.AddForce(transform.up * Mathf.Sqrt(_jumpHeight * -2 * Physics2D.gravity.y), ForceMode2D.Impulse);
        Debug.Log("salto");
        
      

    }

    void Interact()
    {
       // Debug.Log("Haciendo cosas");
       Collider2D[] interacables = Physics2D.OverlapBoxAll(transform.position, _interactionZone, 0);
       foreach (Collider2D item in interacables)
       {
        if(item.gameObject.tag == "Star")
        {
            Debug.Log("tocando estrellas");
        }
       }
    }

    bool isGrounded()
    {
        Collider2D[] ground = Physics2D.OverlapBoxAll(_sensorPosition.position, _sensorSize, 0);
        foreach (var item in ground)
        {
            if (item.gameObject.layer == 3)
            {
                
                return true;
            }
        }

        
        return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_sensorPosition.position, _sensorSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, _interactionZone);
    }
}
