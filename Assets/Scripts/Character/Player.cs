using UnityEngine;

public class Player : YCharacter
{
    [SerializeField] private Gun Gun;
    [SerializeField] private float ShootTime = 1f;
    [SerializeField] private int OneTimeShootCount = 3;
    [SerializeField] private float OneTimeShootInterval = 0.1f;

    private float LastShootTime = 0f;
    private int ShootCount = 0;

    protected override void Update()
    {
        base.Update();

        if (ShootCount != 0)
            return;

        if (LastShootTime >= ShootTime)
        {
            for (int i = 0; i < OneTimeShootCount; i++)
            {
                Invoke("Shoot", i * OneTimeShootInterval);
            }
            LastShootTime = 0f;
        }

        LastShootTime += Time.deltaTime;
    }

    private void Shoot()
    {
        if (!Gun)
            return;

        Gun.Shoot(Attack);
        ShootCount++;
        if (ShootCount >= OneTimeShootCount)
        {
            ShootCount = 0;
        }            
    }
}
