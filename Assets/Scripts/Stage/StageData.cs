using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "StageData", menuName = "Scriptable Objects/StageData")]
public class StageData : ScriptableObject
{
    public string Name;
    public float TimeLimitSec = 30.0f;
    public int MonsterCount = 10;
    public int SpawnMonsterCount = 30;
    public List<GameObject> SpawnMonsterList;
}
