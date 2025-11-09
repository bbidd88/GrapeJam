using System;
using UnityEngine;
using System.Collections.Generic;

public struct GameInfo
{
    public int Kill;
    public int Exp;
    public int Gold;
}

public class GameManager : YManager, YIManagerUpdate
{
    private GameInfo Info;
    public GameInfo GetInfo()    
    {
        return Info;
    }
    public override void OnAwake()
    {
        Info.Kill = 0;
        Info.Exp = 0;
        Info.Gold = 0;
    }

    public override void OnStart()
    {
        
    }

    public void OnUpdate()
    {
        //
        
    }
    
    public void OnMounstKill()
    {
        Info.Kill++;
    }

    public void AddGold(int InGold)
    {
        Info.Gold += InGold;
    }
    public void AddExp(int InExp)
    {
        Info.Exp += InExp;
    }

    public StageData GetCurStageData()
    {
        var stageContainer = GameObject.Find("@StageContainer")?.GetComponent<StageDataContainer>();
        if (!stageContainer)
            return null;

        if (stageContainer.StageDatas.Count < 0)
            return null;

        return stageContainer.StageDatas[0];
    }
}
