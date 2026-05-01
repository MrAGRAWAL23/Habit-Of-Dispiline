using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;
public class Enemy : MonoBehaviour
{

    public GameObject target;
    public float distanceCheck = 0f;
    NavMeshAgent agent;

    public int damage = 10;
    public CastleHealth castle;

    // Start is cled once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }

    }

    // Update is called once per frame

    private void Update()
    {
        if (target == null) return;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            castle.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
