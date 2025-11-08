using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 4f;
    [SerializeField] private float JumpForce = 4f;

    private Vector3 MoveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        bool hasControl = (MoveDirection != Vector3.zero);
        if (hasControl)
        {
            transform.rotation = Quaternion.LookRotation(MoveDirection);
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
    }

    public void OnMove(InputValue InValue)
    {
        Vector3 input = InValue.Get<Vector3>();
        if (input != null)
        {
            MoveDirection = new Vector3(input.x, 0f, input.z);
        }
    }

    public void OnJump(InputValue InValue)
    {
        var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }        
    }   
}
