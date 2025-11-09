using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using System.Linq;
using UnityEngine.Rendering;

public class YGame : MonoBehaviour
{
    static public bool GetIsAwaken() { return Managers != null; }

    static private Dictionary<System.Type, YManager> Managers = null;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void RuntimeInit()
    {
        if (GetIsAwaken())
            return;

        GameObject gameInstanceObj = GameObject.Find("@YGame");
        if (gameInstanceObj == null)
            gameInstanceObj = new GameObject("@YGame");

        if (!gameInstanceObj.GetComponent<YGame>())
            gameInstanceObj.AddComponent<YGame>();
    }

    private void Awake()
    {
        Debug.Log("YGame - Awake");
        if (GetIsAwaken())
            return;

        Managers = new Dictionary<System.Type, YManager>();

        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(
            t => typeof(YManager).IsAssignableFrom(t) && t != typeof(YManager) && !t.IsAbstract&& !t.IsInterface)
            .ToArray();
        foreach (System.Type type in types)
        {
            YManager manager = (YManager)System.Activator.CreateInstance(type);
            manager.OnAwake();
            Managers.Add(type, manager);
        }

        
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Debug.Log("YGame - OnStart");
        foreach (YManager manager in Managers.Values)
        {
            manager.OnStart();
        }
    }
    private void Update()
    {
        foreach (YManager manager in Managers.Values)
        {
            if (manager is YIManagerUpdate)
                (manager as YIManagerUpdate).OnUpdate();
        }
    }

    public static T Get<T>()
    {
        if (Managers != null && Managers.ContainsKey(typeof(T)))
            return (T)System.Convert.ChangeType(Managers[typeof(T)], typeof(T));

        return default(T);
    }    
}
