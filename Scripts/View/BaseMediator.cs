using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMediator : MonoBehaviour 
{
    void Awake()
    {
        OnAwake();
    }
    void Start()
    {
        OnStart();
    }
    void Update()
    {
        OnUpdate();
    }
    void FixedUpdate()
    {
        OnFixedUpdate();
    }
    void OnDestroy()
    {
        OnDoDestroy();
    }
    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnFixedUpdate() { }
    protected virtual void OnDoDestroy() { }
}
