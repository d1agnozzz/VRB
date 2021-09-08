using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BotBehaviorState
{
    [HideInInspector] public Bot context;

    public void SetContext(Bot bot)
    {
        context = bot;
    }
    

    public virtual void Enter() { }

    public virtual void Exit() { }

    public abstract void Update();
}
