using System.Collections;
using System.Collections.Generic;
//using Unity.Burst.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public AudioSource Hit;

    public int maxHealth = 100;
    int currentHealth;

    public float damage;
    public HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
        {
            return;
        }
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        Hit.Play();


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!!!!1!!!");
        animator.SetBool("IsDead", true);

/*        GetComponent<Collider2D>().enabled = false;
*/
        this.enabled = false;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            healthManager.TakeDamage(damage);
        }
    }
}
