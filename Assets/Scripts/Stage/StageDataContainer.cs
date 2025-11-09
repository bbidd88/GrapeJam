using System.Collections.Generic;
using UnityEngine;

public class StageDataContainer : MonoBehaviour
{
    [SerializeField] public float TimeLimitSec = 30.0f;
    [SerializeField] public List<StageData> StageDatas = new List<StageData>();
    
}
