using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "StageData", menuName = "Scriptable Objects/StageData")]
public class StageData : ScriptableObject
{
    public string Name;
    public int MonsterCount = 10;
    public List<GameObject> SpawnMonsterList;
}
