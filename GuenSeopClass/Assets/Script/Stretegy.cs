using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    Character context;
    public Stretegy(Character _context)
    {
        context = _context;
    }

    public void StretegyInit(EPlayerAIType type)
    {
        switch (type)
        {
            case EPlayerAIType.Archer:
                thisAI = new Archer_1(context);
                break;
            case EPlayerAIType.Berserker:
                thisAI = new Berserker_1(context);
                break;
            case EPlayerAIType.HeavyCavalry:
                thisAI = new HeavyCavalry_1(context);
                break;
            case EPlayerAIType.SwordMan:
                thisAI = new SwordMan_1(context);
                break;
        }
    }

    public void Attack()
    {
        thisAI.Attack();
    }

    public void Move()
    {
        thisAI.Move();
    }
}

public abstract class AI
{
    protected Character context;
    protected GameObject gameObject;
    protected Transform transform;

    protected float attackRange = 10;
    protected float moveSpeed = 1;

    protected Scarecrow targeted;

    public AI(Character _context)
    {
        context = _context;

        gameObject = context.gameObject;
        transform = context.transform;
    }

    public abstract void Attack();
    public abstract void Move();

    public virtual void MoveToTarget()
    {
        if (NeedMoveToTargetX(targeted.transform))
        {
            int dir = 0;

            float transX = transform.position.x;
            float targetX = targeted.transform.position.x;
            if (transX < targetX && targetX - transX > attackRange)
            {
                dir = 1;
            }
            else if (transX > targetX && transX - targetX < attackRange)
            {
                dir = 1;
            }
            else if (transX > targetX && transX - targetX > attackRange)
            {
                dir = -1;
            }
            else if (transX < targetX && targetX - transX < attackRange)
            {
                dir = -1;
            }

            transform.Translate(Vector3.right * dir * moveSpeed * Time.deltaTime);
        }

        if (NeedMoveToTargetY(targeted.transform))
        {
            int dir = transform.position.y < targeted.transform.position.y ? 1 : -1;

            transform.Translate(Vector3.up * dir * moveSpeed * Time.deltaTime);
        }
    }
    public virtual bool IsArriveAtTarget()
    {
        return !NeedMoveToTargetX(targeted.transform) && !NeedMoveToTargetY(targeted.transform);
    }
    public virtual bool NeedMoveToTargetX(Transform target)
    {
        bool result = false;

        if (Mathf.Abs(Mathf.Abs(target.position.x - transform.position.x) - attackRange) > 0.1f)
        {
            result = true;
        }
        if (Mathf.Abs(target.position.x - transform.position.x) > attackRange)
        {
            result = true;
        }

        return result;
    }
    public virtual bool NeedMoveToTargetY(Transform target)
    {
        bool result = false;

        if (Mathf.Abs(transform.position.y - target.position.y) > 0.1f)
        {
            result = true;
        }

        return result;
    }
}



public class Archer_1 : AI
{
    public Archer_1(Character context) : base(context)
    {

    }

    public override void Attack()
    {
        Debug.Log("Attack_1");
    }

    public override void Move()
    {
        MoveToTarget();
    }
}

public class Berserker_1 : AI
{
    public Berserker_1(Character context) : base(context)
    {

    }

    public override void Attack()
    {
        Debug.Log("Attack_2");
    }

    public override void Move()
    {

    }

}

public class HeavyCavalry_1 : AI
{
    public HeavyCavalry_1(Character context) : base(context)
    {
    }

    public override void Attack()
    {

    }

    public override void Move()
    {

    }
}

public class SwordMan_1 : AI
{
    public SwordMan_1(Character context) : base(context)
    {
    }

    public override void Attack()
    {

    }

    public override void Move()
    {

    }
}