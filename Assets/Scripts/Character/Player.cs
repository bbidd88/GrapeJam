using UnityEngine;

public class Player : YCharacter
{
    private const int MaxExp = 10;

    protected override void Attack(YCharacter InTarget) 
    {
        base.Attack(InTarget);

        if (!InTarget.IsDeath())
            return;

        Gold += InTarget.Gold;
        Exp += InTarget.Exp;
        while (Exp >= MaxExp)
        {
            Exp -= MaxExp;
            Level++;            
        }
    }
}
