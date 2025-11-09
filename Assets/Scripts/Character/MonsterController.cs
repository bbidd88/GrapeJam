using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 2f;
    [SerializeField] private float ForceReturnDist = 10.0f;

    public void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
            return;

        var playerCharacter = player.GetComponent<YCharacter>();
        if (!playerCharacter || playerCharacter.IsDeath())
            return;


        Vector3 moveDirection = player.transform.position - transform.position;
        moveDirection.Normalize();

        var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            if (Vector3.Distance(player.transform.position, transform.position) > ForceReturnDist)
            {
                rigidbody.linearVelocity = Vector3.zero;
            }
                
            var movePos = transform.position + moveDirection * MoveSpeed * Time.fixedDeltaTime;
            rigidbody.MovePosition(movePos);
            
        }
    }
}
