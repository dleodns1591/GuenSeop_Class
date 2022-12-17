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
    public Transform targetPos;

    public Stretegy(Character _context) => context = _context;

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
        if (targetPos != null)
            thisAI.Attack();
        else
            context.eState = EState.Move;
    }

    public void Move()
    {
        if (targetPos == null)
        {
            thisAI.Move();
            context.ViewDistance();
        }
        else
        {
            thisAI.target = targetPos;
            context.eState = EState.Attack;
        }
    }
}

public abstract class AI
{
    protected bool isAtkCheck = false;

    protected Vector3 movePos = Vector3.zero;
    protected Vector3 currentPos = Vector3.zero;

    protected Character context;
    protected GameObject gameObject;
    protected Transform transform;
    public Transform target = null;

    public Animator animator = null;

    public abstract void Attack();
    public abstract void Move();
}



public class ArcherAI : AI
{
    public ArcherAI(Character _context)
    {

    }

    public override void Attack()
    {
    }

    public override void Move()
    {

    }
}

public class BerserkerAI : AI
{
    public BerserkerAI(Character _context)
    {
        context = _context;
        gameObject = _context.gameObject;
        transform = _context.transform;
        animator = _context.GetComponent<Animator>();
    }

    public override void Attack()
    {
        if (isAtkCheck == false)
            StartCoroutine(AI_Attack());
    }

    private IEnumerator AI_Attack()
    {
        isAtkCheck = true;
        currentPos = transform.position;
        animator.SetInteger("BerSerKer", 2);

        transform.DOMove(new Vector2(target.position.x + 2, target.position.y), 0.5f);

        yield return new WaitForSeconds(0.2f);

        Camera.main.DOShakePosition(0.5f, 0.5f);

        yield return new WaitForSeconds(1);

        transform.DOKill();
        Camera.main.DOShakePosition(0, 0);
        animator.SetInteger("BerSerKer", 1);
        transform.DOMove(currentPos, 2).SetEase(Ease.Linear).OnComplete(() =>
        {
            isAtkCheck = false;
        });

    }

    public override void Move()
    {
        animator.SetInteger("BerSerKer", 1);
        animator.SetBool("Start", true);

        if (target == null)
        {
            if (transform.position == movePos || movePos == Vector3.zero)
            {
                var screenScaleHeight = Screen.height;
                var screenScaleWidth = Screen.width;

                var targetRangeX = Random.Range(0, screenScaleWidth);
                var targetRangeY = Random.Range(0, screenScaleHeight);

                var randPosition = Camera.main.ScreenToWorldPoint(new Vector2(targetRangeX, targetRangeY));
                movePos = randPosition + new Vector3(0, 0, 10);
            }
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