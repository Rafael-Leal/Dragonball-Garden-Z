using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    private int start = 0;

    private Slider slider;
    private LevelManager levelManager;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private GameObject winLabel;

    public int levelTime = 120;
    

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        levelManager = FindObjectOfType<LevelManager>();
        audioSource = GetComponent<AudioSource>();
        FindYouWin();
        winLabel.SetActive(false);

        slider.value = start;
        slider.maxValue = levelTime;
	}

    void FindYouWin()
    {
        winLabel = GameObject.Find("You Win");
        if (!winLabel)
        {
            Debug.LogWarning("Create You Win object");
        }
    }
	
	// Update is called once per frame
	void Update () {
        slider.value = slider.value + 1*Time.deltaTime;

        bool timeIsUp = (slider.value >= levelTime);
        if(timeIsUp && !isEndOfLevel)
        {
            DestroyAllTaggedObjects();
            audioSource.Play();
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
            isEndOfLevel = true;
        }
	}

    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("Attackers");

        foreach (GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }

    public float GetTime()
    {
        return slider.value;
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
