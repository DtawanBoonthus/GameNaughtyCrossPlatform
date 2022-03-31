using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using Manager;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField] private ChooseCharacterInfo chooseCharacterInfo;
    
    [Space]
    [SerializeField] private NavMeshAgent enemy;
    
    [Space]
    [Header("Position Ai")]
    [SerializeField] private Transform positionOne;
    [SerializeField] private Transform positionTwo;
    [SerializeField] private Transform positionThree;
    [SerializeField] private Transform positionFour;

    [SerializeField] private float chaseRadius = 3f;
    [SerializeField] private Animator anim;
    private Vector3 walkPosition;
    private bool isWalk = false;
    private bool isWalkOne = true;
    private bool isWalkTwo = false;
    private bool isWalkThree = false;
    private bool isWalkFour = false;
    private bool isChase = false;
    private int speedBot = 4;
    private int speedBotChase = 6;
    private bool isStun = false;


    private void Update()
    {
        float distance = Vector3.Distance(Target(), transform.position);

        if (!isStun)
        {
            if (distance <= chaseRadius)
            {
                isChase = true;
            
                enemy.speed = speedBotChase;
            }
            else
            {
                isChase = false;
            
                enemy.speed = speedBot;
            }

        
            Patrolling();
        

            if (isChase)
            {
                ChasePlayer();
            }
        }
    }

    private Vector3 Target()
    {
        if (chooseCharacterInfo.Name == "Jennie")
        {
            return CharacterManager.Instance.Jennie.transform.position;
        }
        else
        {
            return CharacterManager.Instance.John.transform.position;
        }
    }
    
    private void ChasePlayer()
    {
        if (chooseCharacterInfo.Name == "Jennie")
        {
            enemy.SetDestination(CharacterManager.Instance.Jennie.transform.position);
        }
        else
        {
            enemy.SetDestination(CharacterManager.Instance.John.transform.position);
        }
    }

    private void Patrolling()
    {
        if (!isWalk)
        {
            SearchWalkPoint();
        }

        if (isWalk)
        {
            enemy.SetDestination(walkPosition);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPosition;
       
        if (distanceToWalkPoint.magnitude < 2f)
        {
            isWalk = false;
        }
    }

    private void SearchWalkPoint()
    {
        Vector3 distanceToWalkPointOne = default;
        Vector3 distanceToWalkPointTwo = default;
        Vector3 distanceToWalkPointThree = default;

        if (isWalkOne)
        {
            walkPosition = positionOne.position;

            isWalkOne = false;
            isWalkTwo = true;
            
            distanceToWalkPointOne = transform.position - walkPosition;
        }
        
        if (isWalkTwo && distanceToWalkPointOne.magnitude < 2f)
        {
            walkPosition = positionTwo.position;

            isWalkTwo = false;
            isWalkThree = true;
            
            distanceToWalkPointTwo = transform.position - walkPosition;
        }
        
        if (isWalkThree && distanceToWalkPointTwo.magnitude < 2f)
        {
            walkPosition = positionThree.position;

            isWalkThree = false;
            isWalkFour = true;
            
            distanceToWalkPointThree = transform.position - walkPosition;
        }
        
        if (isWalkFour && distanceToWalkPointThree.magnitude < 2f)
        {
            walkPosition = positionFour.position;

            isWalkFour = false;
            isWalkOne = true;
        }

        isWalk = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }

    public void TakeHit(int damage)
    {
        StartCoroutine(Stun());
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var target = other.gameObject.GetComponent<IDamageable>();
        target?.TakeHit(1);

        StartCoroutine(Attack());
    }

    private IEnumerator Stun()
    {
        anim.SetBool("isWalk", false);
        isStun = true;
        enemy.speed = 0;
        anim.Play("BlockStun");
        yield return new WaitForSeconds(2);
        anim.SetBool("isWalk", true);
        isStun = false;
    }

    private IEnumerator Attack()
    {
        anim.SetBool("isWalk", false);
        isStun = true;
        enemy.speed = 0;
        anim.Play("Attack");
        yield return new WaitForSeconds(2);
        anim.SetBool("isWalk", true);
        isStun = false;
    }
}
