using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 2f;

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
            var move = moveDirection * MoveSpeed * Time.fixedDeltaTime;
            rigidbody.MovePosition(rigidbody.position + move);
        }
    }
}
