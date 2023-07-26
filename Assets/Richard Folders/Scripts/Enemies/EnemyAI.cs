using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirFloat = 2f;


    private enum State
    {
        Roaming,
        Attacking
    } 

    private State state;
    private EnemyPathfinding enemyPathfinding;
    private Vector2 roamPosition;

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        state = State.Roaming;
    }

    private void Start()
    {
        roamPosition = GetRoamingPosition();
    }

    private void Update()
    {
        MovementStateControl();
    }

    private void MovementStateControl()
    {
        switch (state)
        {
            default:
                case State.Roaming:
                Roaming();
                break;

                case State.Attacking:
                    Attacking();
                break;
                    
        }
    }

    private void Roaming()
    {

    }

    private void Attacking()
    {

    }


    /* 
    private IEnumerator RoamingRoutine()
    {
        while(state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(roamChangeDirFloat);
        }
    }
    */

    private Vector2 GetRoamingPosition() 
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
