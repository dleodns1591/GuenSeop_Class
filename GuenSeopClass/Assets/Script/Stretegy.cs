using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum EAIType
{
    Archer,
    Berserker,
    HeavyCavalry,
    SwordMan,
}

public enum EState
{
    None,
    Move,
    Attack
}

class Stretegy
{
    AI thisAI;

    Character context;
    public Transform target = null;

    public Stretegy(Character _context)
    {
        context = _context;
    }

    public void StretegyInit(EAIType type)
    {
        switch (type)
        {
            case EAIType.Archer:
                thisAI = new ArcherAI(context);
                break;
            case EAIType.Berserker:
                thisAI = new BerserkerAI(context);
                break;
            case EAIType.HeavyCavalry:
                thisAI = new HeavyCavalryAI(context);
                break;
            case EAIType.SwordMan:
                thisAI = new SwordManAI(context);
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
    public Transform target;

    public Vector3 movePos = Vector3.zero;

    protected Character context;
    protected GameObject gameObject;
    protected Transform transform;

    public abstract void Attack();
    public abstract void Move();
}



public class ArcherAI : AI
{
    public ArcherAI(Character _context)
    {
        context = _context;
        gameObject = _context.gameObject;
        transform = _context.transform;
    }

    public override void Attack()
    {
        Debug.Log("공격");
    }

    public override void Move()
    {

        if (target == null)
        {
            if (transform.position == movePos || movePos == Vector3.zero)
            {
                Debug.Log(target);
                var screenScaleHeight = Screen.height;
                var screenScaleWidth = Screen.width;

                var targetRangeX = Random.Range(0, screenScaleWidth);
                var targetRangeY = Random.Range(0, screenScaleHeight);

                var randPosition = Camera.main.ScreenToWorldPoint(new Vector2(targetRangeX, targetRangeY));
                movePos = randPosition + new Vector3(0, 0, 10);
            }
        }
        else
        {
            context.eState = EState.Attack;
        }

        transform.position = Vector3.MoveTowards(transform.position, movePos, 3 * Time.deltaTime);
    }



    private Coroutine StartCoroutine(IEnumerator routine)
    {
        return context.StartCoroutine(routine);
    }
}

public class BerserkerAI : AI
{
    public BerserkerAI(Character _context)
    {
        context = _context;
        gameObject = _context.gameObject;
        transform = _context.transform;
    }

    public override void Attack()
    {
        Debug.Log("공격");
    }

    public override void Move()
    {

        if (target == null)
        {
            if (transform.position == movePos || movePos == Vector3.zero)
            {
                Debug.Log(target);
                var screenScaleHeight = Screen.height;
                var screenScaleWidth = Screen.width;

                var targetRangeX = Random.Range(0, screenScaleWidth);
                var targetRangeY = Random.Range(0, screenScaleHeight);

                var randPosition = Camera.main.ScreenToWorldPoint(new Vector2(targetRangeX, targetRangeY));
                movePos = randPosition + new Vector3(0, 0, 10);
            }
        }
        else
        {
            context.eState = EState.Attack;
        }

        transform.position = Vector3.MoveTowards(transform.position, movePos, 3 * Time.deltaTime);
    }

    private Coroutine StartCoroutine(IEnumerator routine)
    {
        return context.StartCoroutine(routine);
    }
}

public class HeavyCavalryAI : AI
{
    public HeavyCavalryAI(Character context)
    {
    }

    public override void Attack()
    {

    }

    public override void Move()
    {

    }
}

public class SwordManAI : AI
{
    public SwordManAI(Character context)
    {
    }

    public override void Attack()
    {

    }

    public override void Move()
    {

    }
}