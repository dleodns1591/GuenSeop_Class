using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum EState
    {
        None,
        Move,
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
    }

    public void Update()
    {
        PlayerAI();
    }

    public void PlayerAI()
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

        switch (eState)
        {
            case EState.None:
                break;
            case EState.Move:
                stretegy.Move();
                break;
            case EState.Attack:
                stretegy.Attack();
                break;
        }
    }

}
