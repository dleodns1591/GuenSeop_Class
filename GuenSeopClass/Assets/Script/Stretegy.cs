using System;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerAIType
{
    Archer,
    Berserker,
    HeavyCavalry,
    SwordMan,
}

class Stretegy
{
    AI thisAI;

    public void StretegyInit(EPlayerAIType type)
    {
        switch (type)
        {
            case EPlayerAIType.Archer:
                thisAI = new Archer_1();
                break;
            case EPlayerAIType.Berserker:
                thisAI = new Berserker_1();
                break;
        }
    }

    public void Move()
    {
        thisAI.Move();
    }

    public void Attack()
    {
        thisAI.Attack();
    }
}

public abstract class AI
{
    public abstract void Move();
    public abstract void Attack();
}

public class Archer_1 : AI
{
    public override void Attack()
    {
        Debug.Log("Attack_1");
    }

    public override void Move()
    {
        Debug.Log("Move_1");
    }
}

public class Berserker_1 : AI
{
    public override void Attack()
    {
        Debug.Log("Attack_2");
    }

    public override void Move()
    {
        Debug.Log("Move_2");
    }
}

