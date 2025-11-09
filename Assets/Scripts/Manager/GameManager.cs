using System;
using UnityEngine;
using System.Collections.Generic;

public struct GameInfo
{
    public float StageElapsedTime;
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
        Info.StageElapsedTime = 0.0f;
        Info.Exp = 0;
        Info.Gold = 0;
    }

    public override void OnStart()
    {
        
    }

    public void OnUpdate()
    {
        //
        UpdateTime();
    }

    private void UpdateTime()
    {
        Info.StageElapsedTime += Time.deltaTime;
        // 
    }

    public void AddGold(int InGold)
    {
        Info.Gold += InGold;
    }
    public void AddExp(int InExp)
    {
        Info.Exp += InExp;
    }
}
