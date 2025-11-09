using UnityEngine;

public class Player : YCharacter
{
    private int MaxExp = 10;
    private int Exp = 0;
    private int Level = 1;
    private int Gold = 0;

    protected override void Attack(YCharacter InTarget) 
    {
        base.Attack(InTarget);

        Gold += 100;
        Exp++;
        if (Exp >= MaxExp)
        {
            Level++;
            Exp = 0;
        }
    }
}
