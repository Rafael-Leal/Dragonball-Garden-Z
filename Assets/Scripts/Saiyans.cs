using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saiyans : MonoBehaviour {

    public GameObject projectile, blast;

    private Animator anim;
    private GameObject projectileParent;
    private Spawner laneSpawner;
    private GameTimer gameTimer;
    
	// Use this for initialization
	void Start () {
        projectileParent = GameObject.Find("Projectiles");
        gameTimer = FindObjectOfType<GameTimer>();

        anim = GetComponent<Animator>();

        //creates parent if necessary
        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        //sets lane in same position
        SetMyLaneSpawner();
	}
	
	// Update is called once per frame
	void Update () {
        if (IsAttackerAhead())
        {
            anim.SetBool("IsAttacking", true);
        }
        else
        {
            anim.SetBool("IsAttacking", false);
            Celebrate();
        }
	}

    void SetMyLaneSpawner()
    {
        Spawner[] spawns = FindObjectsOfType<Spawner>();
        foreach(Spawner spawnPosition in spawns)
        {
            if(spawnPosition.transform.position.y == transform.position.y)
            {
                laneSpawner = spawnPosition;
                return;
            }
        }
        Debug.LogError(name + "Cant find spawner in lane");
    }

    bool IsAttackerAhead()
    {
        if (laneSpawner.transform.childCount > 0)
        {
            foreach (Transform child in laneSpawner.transform)
            {
                if (child.transform.position.x > transform.position.x)
                {
                    return true;
                }
            }
        }
            return false;
    }

    void Celebrate()
    {
        if(gameTimer.GetTime() >= gameTimer.levelTime)
        {
            anim.SetBool("GameOver", true);
        }
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = blast.transform.position;
    }
}
