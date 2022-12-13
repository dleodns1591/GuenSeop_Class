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
            case EPlayerAIType.HeavyCavalry:
                thisAI = new HeavyCavalry_1();
                break;
            case EPlayerAIType.SwordMan:
                thisAI = new SwordMan_1();
                break;
        }
    }

    public void Attack()
    {
        thisAI.Attack();
    }
}

public abstract class AI
{
    public abstract void Attack();
}

public class Archer_1 : AI
{
    public override void Attack()
    {
        Debug.Log("Attack_1");
    }

}

public class Berserker_1 : AI
{
    public override void Attack()
    {
        Debug.Log("Attack_2");
    }
}

public class HeavyCavalry_1 : AI
{
    public override void Attack()
    {

    }
}

public class SwordMan_1 : AI
{
    public override void Attack()
    {

    }
}