using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public EAIType eAIType;
    public EState eState;

    Stretegy stretegy;

    public void Start()
    {
        stretegy = new Stretegy(this);
        stretegy.StretegyInit(eAIType);
    }

    public void Update()
    {
        switch (eState)
        {
            case EState.None:
                break;
            case EState.Move:
                if (stretegy.target == null)
                {
                    stretegy.Move();
                    AttackDistance();
                }
                break;
            case EState.Attack:
                if (stretegy.target != null)
                    stretegy.Attack();
                else
                    eState = EState.Move;
                break;
        }
    }

    // ���ݰŸ� üũ���ִ� �Լ�
    void AttackDistance()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 4);

        foreach (Collider2D colliders in collider)
        {
            var check = colliders.GetComponent<Scarecrow>();
            if (check != null)
                stretegy.target = colliders.transform;
        }
    }

    // ����� �׷��ִ� �Լ�
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 4);
    }
}
