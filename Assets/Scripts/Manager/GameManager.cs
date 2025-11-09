using System;
using UnityEngine;
using System.Collections.Generic;

public struct GameInfo
{
    public int Kill;
    public int Exp;
    public int Gold;
}

public enum StageState
{ 
    Play,
    Clear,
    Fail,
}


public class GameManager : YManager, YIManagerUpdate
{
    private GameInfo Info;
    public GameInfo GetInfo()    
    {
        return Info;
    }

    public float ElapsedTime { get; private set; } = 0.0f;
    StageState StageState = StageState.Play;
    int CurStageIndex = 0;

    public void SetPause(bool IsPaused)
    {
        Time.timeScale = IsPaused ? 0.0f : 1.0f;
    }

    public void ClearStage()
    {
        SetPause(false);
        CurStageIndex = 0;
        Info.Kill = 0;
        Info.Exp = 0;
        Info.Gold = 0;
        ElapsedTime = 0.0f;
        StageState = StageState.Play;
    }

    public override void OnAwake()
    {
        ClearStage();
    }

    public override void OnStart()
    {
        
    }

    public void OnUpdate()
    {
        //        
        if(StageState == StageState.Play)
        {
            ElapsedTime += Time.deltaTime;
        }
        UpdateStageState();
    }
    
    public void OnMounstKill()
    {
        Info.Kill++;
        UpdateStageState();
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

        
        if (stageContainer.StageDatas.Count < CurStageIndex)
            return null;

        return stageContainer.StageDatas[CurStageIndex];
    }

    private void UpdateStageState()
    {
        if (StageState != StageState.Play)
            return;

        StageData stageData = GetCurStageData();
        if (stageData == null)
            return;
        
        if(ElapsedTime >= stageData.TimeLimitSec)
        {
            ElapsedTime = stageData.TimeLimitSec;
            StageState = StageState.Fail;
            GameObject.Find("FieldCanvas")?.GetComponent<FieldCanvas>()?.OpenGameOverPopup();
            return;
        }

        int maxKillCount = stageData.MonsterCount;
        if (Info.Kill >= maxKillCount)
        {
            StageState = StageState.Clear;
            GameObject.Find("FieldCanvas")?.GetComponent<FieldCanvas>()?.OpenStageClearPopup();
            return;
        }
        
    }
}
