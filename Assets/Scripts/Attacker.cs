using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range(-1f,1.5f)]
    private float currentSpeed;

    [Tooltip("Average number of spawns per second")]
    public float spawnPerSecond;

    private GameObject currentTarget;
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            anim.SetBool("IsAttacking", false); 
        }
	}

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }

       
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }

    void OnTriggerEnter2D()
    {

    }
}
