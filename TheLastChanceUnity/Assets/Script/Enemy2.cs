using UnityEngine;
using System.Collections;

public class Enemy2 : EnemyStat
{
    private bool isCoroutineRunning = false;
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private string targetTag = "Player";
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        rb.freezeRotation = true;
    }

    private void Update()
    {
        if (targetTransform == null)
        {
            FindClosestTarget();
        }
        else if (!IsTargetInRange())
        {
            targetTransform = null;
        }

        if (targetTransform == null && !isCoroutineRunning)
        {
            anim.SetBool("Walk", false);
            StartCoroutine(WanderCoroutine());
        }
    }

    private void FixedUpdate()
    {
        if (targetTransform != null)
        {
            anim.SetBool("Walk", true);
            MoveTowardsTarget();
        }
    }

    private void FindClosestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        float closestDistance = Mathf.Infinity;
        Transform closestTarget = null;

        foreach (GameObject t in targets)
        {
            float dist = Vector2.Distance(transform.position, t.transform.position);
            if (dist < closestDistance && dist <= detectionRadius)
            {
                closestDistance = dist;
                closestTarget = t.transform;
            }
        }

        targetTransform = closestTarget;
    }

    private bool IsTargetInRange()
    {
        if (targetTransform == null) return false;
        float dist = Vector2.Distance(transform.position, targetTransform.position);
        return dist <= detectionRadius;
    }

    private void MoveTowardsTarget()
    {
        Vector2 direction = (targetTransform.position - transform.position).normalized;
        Vector2 newPos = rb.position + direction * Speed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);

        spriteRenderer.flipX = direction.x < 0;
    }

    private IEnumerator WanderCoroutine()
    {
        isCoroutineRunning = true;

        Vector2 dir = Vector2.right;
        rb.MovePosition(rb.position + dir * Speed * Time.fixedDeltaTime);
        spriteRenderer.flipX = false;
        yield return new WaitForSeconds(0.5f);

        dir = Vector2.left;
        rb.MovePosition(rb.position + dir * Speed * Time.fixedDeltaTime);
        spriteRenderer.flipX = true;
        yield return new WaitForSeconds(0.5f);

        isCoroutineRunning = false;
    }

    // je l'ai ajouté parce la cible était toujours le feu
    public void SetTarget(Transform target)
    {
        targetTransform = target;
    }
}
