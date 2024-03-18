using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float projectileSpeed;
    public Animator animator;
    public AudioSource Swing;
    public GameObject projectile;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public int hitDamage = 20;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                Hit();
                nextAttackTime = Time.time + 1f / attackRate;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                animator.SetTrigger("Crouching");
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                animator.SetTrigger("HandUp");
            }
        }





    }

    void Attack()
    {
        Swing.Play();

        animator.SetTrigger("Attack") ;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {

            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void Hit()
    {
        Swing.Play();

        animator.SetTrigger("Hit");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {

            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(hitDamage);
        }
    }

    void Shoot()
    {
        /*        Shoot.Play();
        */
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector3(projectileSpeed, 3, 0), ForceMode2D.Impulse);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {

            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

