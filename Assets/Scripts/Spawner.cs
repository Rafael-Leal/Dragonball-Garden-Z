using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackers;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        foreach (GameObject thisAttacker in attackers)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}

    void Spawn(GameObject attacker)
    {
       GameObject myAttacker = Instantiate(attacker) as GameObject; //myAttacker holds instantiated game object
        myAttacker.transform.parent = this.transform; //sets myAttacker's parent to scripts game object
        myAttacker.transform.position = transform.position; //sets position of myAttacker to scripts game object position
    }

    bool isTimeToSpawn(GameObject attacker)
    {
        float spawnTime = attacker.GetComponent<Attacker>().spawnPerSecond;
        float spawnPerSecond = 1 / spawnTime;
        if(Time.deltaTime > spawnTime)
        {
            Debug.LogWarning("Spawn rate capped by frame rate ");
        }

        float threshold = spawnPerSecond * Time.deltaTime / (10/PlayerPrefsManager.GetDifficulty());

        return (Random.value < threshold);
    }
}
