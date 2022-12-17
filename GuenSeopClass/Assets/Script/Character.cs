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
                stretegy.Move();
                break;
            case EState.Attack:
                stretegy.Attack();
                break;
        }
    }

    public void ViewDistance()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5);

        foreach (Collider2D collider in colliders)
        {
            var check = collider.GetComponent<Scarecrow>();
            if (check != null)
                stretegy.targetPos = collider.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5);
    }
}
