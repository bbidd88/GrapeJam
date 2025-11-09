using System;
using UnityEngine;

public abstract class YCharacter : MonoBehaviour
{
    [Serializable]
    public struct CharacterStat
    {
        public int MaxHp;
        public int AttackPower;
        public int DefensePower;
    }

    [SerializeField] private string Name;
    [SerializeField] public CharacterStat Stat;

    public int CurHp { get; protected set; } = 0;

    private void Start()
    {
        CurHp = Stat.MaxHp;
    }

    protected virtual void Update()
    {
    }

    protected virtual void Attack(YCharacter InTarget)
    {
        if (!InTarget)
            return;

        InTarget.Damaged(Stat.AttackPower);
    }

    protected virtual void Damaged(int InAttackPower)
    {
        var damage = InAttackPower - Stat.DefensePower;
        if (damage <= 0)
            return;

        CurHp -= damage;
        if (CurHp > 0)
            return;

        CurHp = 0;
    }

    public bool IsDeath()
    {
        return CurHp <= 0;
    }
}
