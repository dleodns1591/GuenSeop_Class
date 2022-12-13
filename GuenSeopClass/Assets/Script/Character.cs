using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum EState
    {
        None,
        Attack
    }

    public enum EPlayerAI
    {
        Archer,
        Berserker,
        HeavyCavalry,
        SwordMan,
    }

    public EPlayerAI ePlayerAI;
    public EState eState;

    Stretegy stretegy = new Stretegy();


    public void Start()
    {
        switch (ePlayerAI)
        {
            case EPlayerAI.Archer:
                stretegy.StretegyInit(EPlayerAIType.Archer);
                break;

            case EPlayerAI.Berserker:
                stretegy.StretegyInit(EPlayerAIType.Berserker);
                break;

            case EPlayerAI.HeavyCavalry:
                stretegy.StretegyInit(EPlayerAIType.HeavyCavalry);
                break;

            case EPlayerAI.SwordMan:
                stretegy.StretegyInit(EPlayerAIType.SwordMan);
                break;
        }
    }

    public void Update()
    {
        switch (eState)
        {
            case EState.None:
                break;
            case EState.Attack:
                stretegy.Attack();
                break;
        }
    }

}
