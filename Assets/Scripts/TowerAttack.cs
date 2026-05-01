using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public float range = 10f;
    public float fireRate = 1f; // attacks per second
    public int damage = 10;

    private float fireCountdown = 0f;

    void Update()
    {
        GameObject target = FindClosestEnemy();

        if (target == null)
            return;

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= range)
        {
            if (fireCountdown <= 0f)
            {
                Shoot(target);
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject nearest = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);

            if (dist < shortestDistance)
            {
                shortestDistance = dist;
                nearest = enemy;
            }
        }

        return nearest;
    }

    void Shoot(GameObject enemy)
    {
        Debug.Log("Tower attacking");

        EnemyHealth eh = enemy.GetComponent<EnemyHealth>();
        if (eh != null)
        {
            eh.TakeDamage(damage);
        }
    }
}