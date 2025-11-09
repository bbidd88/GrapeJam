using UnityEngine;

public class Monster : YCharacter
{
    [SerializeField] public int Exp { get; protected set; } = 10;
    [SerializeField] public int Gold { get; protected set; } = 10;

    protected override void Update()
    {
        if (IsDeath())
        {
            Destroy(gameObject);
            return;
        }
    }

    protected override void Damaged(int InAttackPower)
    {
        base.Damaged(InAttackPower);

        if (IsDeath())
        {
            YGame.Get<GameManager>().OnMounstKill();            
        }
    }
}
