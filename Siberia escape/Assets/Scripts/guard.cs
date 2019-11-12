using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class guard : MonoBehaviour
{
    [Header("Basic Settings")]
    [SerializeField] guardJobType guardJob;

    [Header("Path")]

    [SerializeField] Transform[] pathfPoints;


    [Header("Informations")]

    [SerializeField] bool isFollowingPath;
    [SerializeField] bool isMovingTo;



    enum guardJobType {Static, followPath};
    enum animationType {idle, walking, run};

    animationType guardAnimState;


    NavMeshAgent  navAgent;
    Animator anim;
    
   public int pointWhereGuardIs;
   public int headingPoint;

   public bool isHeadingToThePoint;

    Vector3 headingTo;

    public void moveTo(Vector3 position)
    {
        guardAnimState = animationType.walking;
        headingTo = position;
        isMovingTo = true;
        navAgent.SetDestination(position);
    }


    IEnumerator followPath()
    {
        isHeadingToThePoint = false;

        if (isFollowingPath) {
            guardAnimState = animationType.walking;
            if (pointWhereGuardIs + 1 >= pathfPoints.Length)
            {
                headingPoint = 0;
            }
            else
            {
                headingPoint = pointWhereGuardIs + 1;
            }        
            navAgent.SetDestination(pathfPoints[headingPoint].position);
            isHeadingToThePoint = true;

        }
        else
        {
            guardAnimState = animationType.idle;
            yield return new WaitForSeconds(Random.Range(2,8));
            isFollowingPath = true;
            StartCoroutine(followPath());
            yield break;
            

        }

       

    }
    





    void startJob()
    {
        if(guardJob == guardJobType.followPath)
        { 
            if(Random.Range(0,1) == 1)
            {
                isFollowingPath = true;               
            }
            else { isFollowingPath = false;}

            StartCoroutine(followPath());

        }
        else if(guardJob == guardJobType.Static)
        {

            isFollowingPath = false;
            guardAnimState = animationType.idle;


        }


    }

    void guardAnimationUpdate()
    {
        switch (guardAnimState)
        {
            case animationType.idle:
                {
                    anim.SetBool("idle", true);
                    anim.SetBool("walking", false);
                    anim.SetBool("running", false);
                    break;
                }
            case animationType.walking:
                {
                    anim.SetBool("walking", true);
                    anim.SetBool("idle", false);
                    anim.SetBool("running", false);
                    break;
                }
               

            case animationType.run:
                {
                    anim.SetBool("running", true);
                    anim.SetBool("idle", false);
                    anim.SetBool("walking", false);
                    break;
                }
              
        }

        



    }


    void Update()
    {
        if(isHeadingToThePoint)
        {
            if(Vector3.Distance(transform.position, pathfPoints[headingPoint].position) < 7)
            {
                
                pointWhereGuardIs = headingPoint;

                startJob();
            }


        }
        if(isMovingTo)
        {
            if(Vector3.Distance(transform.position, headingTo) < 4)
            {
                Debug.Log("Ended");
                isMovingTo = false;
                headingTo = new Vector3(0,0,0);
                guardAnimState = animationType.idle;
            }


        }

        guardAnimationUpdate();
    }



    void setRandomlyGuardPosition()
    {
        pointWhereGuardIs = Random.Range(0, pathfPoints.Length);
        navAgent.Warp(pathfPoints[pointWhereGuardIs].position);
        
    }


    void Start()
    {
        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        if (guardJob == guardJobType.followPath)
        {
            setRandomlyGuardPosition();
        }
        startJob();

    }





}
