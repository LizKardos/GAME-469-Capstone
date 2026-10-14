using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class humanoidAIMovement : MonoBehaviour
{
    //public variables
    public Transform target;
    public float lookRadius = 10f;
    public bool isAggro;

    //private variables
    private NavMeshAgent agent;

    void Start()
    {
        isAggro = false;
        target = playerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    { 
       attackTarget();
    }

    void attackTarget()
    {
        float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius)
            {
                isAggro = true;
                agent.SetDestination(target.position);

                if (distance <= agent.stoppingDistance)
                {
                    faceTarget();
                }
            }
            else
            {
                isAggro = false;
            }    
    }

    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void raycast()
    {
        
    }
}
