using UnityEngine;

public class ObjectManager : YManager, YIManagerUpdate
{
    private const float ResponeTime = 3f;
    private const float MaxSpownDistance = 30f;
    private float LastResponeTime = 0f;
    private int CurSponeMonsterCount = 0;


    public override void OnAwake()
    {
    }

    public override void OnStart()
    {        

    }

    public void OnUpdate()
    {
        var stageData = YGame.Get<GameManager>().GetCurStageData();
        if (!stageData)
            return;

        var killCount = YGame.Get<GameManager>().GetInfo().Kill;
        if (killCount + CurSponeMonsterCount >= stageData.MonsterCount)
            return;

        if (LastResponeTime >= ResponeTime)
        {
            LastResponeTime = 0f;
            MonsterRespown();
            return;
        }

        LastResponeTime += Time.deltaTime;
    }

    private void MonsterRespown()
    {
        var stageData = YGame.Get<GameManager>().GetCurStageData();
        if (!stageData)
            return;

        if (stageData.SpownMonsterList.Count <= 0)
            return;

        var randMonster = 
                stageData.SpownMonsterList[Random.Range(0, stageData.SpownMonsterList.Count - 1)];
        if (!randMonster)
            return;

        var player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
            return;

        var ramdomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        var position = player.transform.position + (ramdomDirection * Random.Range(0f, MaxSpownDistance));
        MonoBehaviour.Instantiate(randMonster, position, Quaternion.identity);

        CurSponeMonsterCount++;
    }
}
