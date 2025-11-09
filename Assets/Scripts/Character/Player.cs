using UnityEngine;

public class Player : YCharacter
{
    [SerializeField] private Gun Gun;
    [SerializeField] private float ShootTime = 1f;

    private float LastShootTime = 0f;

    protected override void Update()
    {
        base.Update();

        if (LastShootTime >= ShootTime)
        {
            Shoot();
            LastShootTime = 0f;
        }

        LastShootTime += Time.deltaTime;
    }

    private void Shoot()
    {
        if (!Gun)
            return;

        Gun.Shoot(Attack);
    }
}
