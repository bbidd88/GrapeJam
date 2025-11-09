using UnityEngine;

public class ObjectManager : YManager, YIManagerUpdate
{
    private const float RespawnTime = 3f;
    private (float min, float max) SpawnDistance = (5f, 30f);
    private float LastRespawnTime = 0f;
    private int CurSpawnMonsterCount = 0;


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
        if (killCount + CurSpawnMonsterCount >= stageData.MonsterCount)
            return;

        if (LastRespawnTime >= RespawnTime)
        {
            LastRespawnTime = 0f;
            MonsterRespown();
            return;
        }

        LastRespawnTime += Time.deltaTime;
    }

    private void MonsterRespown()
    {
        var stageData = YGame.Get<GameManager>().GetCurStageData();
        if (!stageData)
            return;

        if (stageData.SpawnMonsterList.Count <= 0)
            return;

        var randMonster = 
                stageData.SpawnMonsterList[Random.Range(0, stageData.SpawnMonsterList.Count - 1)];
        if (!randMonster)
            return;

        var player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
            return;

        var ramdomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        var position = player.transform.position + (ramdomDirection * Random.Range(SpawnDistance.min, SpawnDistance.max));
        MonoBehaviour.Instantiate(randMonster, position, Quaternion.identity);

        CurSpawnMonsterCount++;
    }
}
