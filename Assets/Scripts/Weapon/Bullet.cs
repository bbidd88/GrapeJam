using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using static Bullet;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 3f;
    [SerializeField] private float LifeTime = 10f;

    public delegate void AttackFunction(YCharacter InTarget);
    private AttackFunction _attackFunction;

    private void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    private void FixedUpdate()
    {
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0f)
            return;

        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            var monaterCharacter = collision.gameObject.GetComponent<YCharacter>();
            if (monaterCharacter)
            {
                _attackFunction?.Invoke(monaterCharacter);
            }            

            Destroy(gameObject);
        }        
    }

    public void SetAttachFunction(AttackFunction InAttackFunction)
    {
        _attackFunction = InAttackFunction;
    }
}