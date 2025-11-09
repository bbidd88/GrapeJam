
using System.Collections;
using UnityEngine;

public abstract class YManager
{
    public abstract void OnAwake();
    
    public abstract void OnStart();    
}

public interface YIManagerUpdate
{
    void OnUpdate();
}