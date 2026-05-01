using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    public GameObject agentPrefab; // assign your NavMeshAgent prefab here
    public GameObject target1;
    public float dealy = 0f;

    void Start()
    {
        StartCoroutine(SpawnAgents());
    }

    IEnumerator SpawnAgents()
    {
        while (true)
        {
            SpawnAgent();
            yield return new WaitForSeconds(dealy); // 1 second delay
        }
    }

    void SpawnAgent()
    {
        GameObject agentObj = Instantiate(agentPrefab, this.transform.position, this.transform.rotation);

        // Get script from spawned agent
        Enemy ai = agentObj.GetComponent<Enemy>();

        // Assign target manually
        ai.target = target1;
    }
}


