using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

    private Animator anim;
    private float previousHealth;
    private float currentHealth;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        currentHealth = GetComponent<Health>().health;
        previousHealth = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
        currentHealth = GetComponent<Health>().health;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        Attacker attacker = collider.gameObject.GetComponent<Attacker>();

        if (attacker)
        {
            if (previousHealth > currentHealth)
            {
                previousHealth = currentHealth;
                anim.SetTrigger("IsAttacked");
            }
        }
    }
}
