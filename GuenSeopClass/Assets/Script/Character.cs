using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Data
{
    public EPlayerAIType ePlayerAI;
    public EState eState;

    Stretegy stretegy;

    public void Start()
    {
        stretegy = new Stretegy(this);

        stretegy.StretegyInit(ePlayerAI);
    }

    public void Update()
    {
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
