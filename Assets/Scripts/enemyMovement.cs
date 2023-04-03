using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
     public Transform Player;
    CharactersStats stats; 
    NavMeshAgent agent;
    Animator anim;
    public float attackRaduis = 5;


    bool canAttack = true;
    float attackCooldown = 3f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<CharactersStats>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        float distance = Vector3.Distance(transform.position, LevelManager.instance.player.position);
        if (distance < attackRaduis)
        {
            agent.SetDestination(LevelManager.instance.player.position);
            if (distance <= agent.stoppingDistance)
            {
                if (canAttack)
                {
                    StartCoroutine(cooldown());
                    //play Attack Animation
                    anim.SetTrigger("Attack");
                }
            }
        }

    }

    IEnumerator cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player Contacted !");

            stats.ChangeHealth(-other.GetComponentInParent<CharactersStats>().power);
            //reduce health

           // Destroy(gameObject);
        }
    }
    public void DamagePlayer()
    {

        LevelManager.instance.player.GetComponent<CharactersStats>().ChangeHealth(-stats.power);
    }
    
}
