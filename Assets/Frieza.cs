using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Frieza : MonoBehaviour
{

    private Animator anim;
    private Attacker attacker;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = col.gameObject;

        if (!obj.GetComponent<Defender>())
        {
            return;
        }
        else if (!obj.GetComponent<Stone>())
        {
            anim.SetBool("IsAttacking", true);
            attacker.Attack(obj);
        }
        else
        {
            anim.SetTrigger("Jump Trigger");
        }

    }
}