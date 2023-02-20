using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisEnemyManager : MonoBehaviour
{
    [SerializeField] Transform enemyTarget;


    public Transform SetTransformEnemyPosition()
    {
        return enemyTarget;
    }
}
