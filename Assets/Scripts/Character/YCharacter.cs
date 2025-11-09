using UnityEngine;

public abstract class YCharacter : MonoBehaviour
{
    public struct CharacterStat
    {
        public int MaxHp;
        public int AttackPower;
        public int DefensePower;
    }

    [SerializeField] private string Name;
    [SerializeField] public CharacterStat Stat { get; private set; }

    public int CurHp { get; private set; }

    private void Start()
    {
        CurHp = Stat.MaxHp;
    }

    private void Update()
    {
        if (CurHp <= 0)
            return;
    }

    protected virtual void Attack(YCharacter InTarget)
    {
        InTarget.BeAttecked(Stat.AttackPower);
    }

    protected void BeAttecked(int InAttackPower)
    {
        var damage = InAttackPower - Stat.DefensePower;
        if (damage <= 0)
            return;

        CurHp -= damage;
        if (CurHp > 0)
            return;

        CurHp = 0;
        Destroy(gameObject);
    }
}
