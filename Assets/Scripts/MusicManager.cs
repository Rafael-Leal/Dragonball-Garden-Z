using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;
    private AudioClip newLevelMusic;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        PlayerPrefsManager.SetMasterVolume(.1f);
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }
	
    private void OnEnable() { SceneManager.sceneLoaded += OnSceneLoaded; }
    private void OnDisable() { SceneManager.sceneLoaded -= OnSceneLoaded; }
    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        newLevelMusic = levelMusicChangeArray[scene.buildIndex];
        if (newLevelMusic && audioSource.clip != newLevelMusic)
        {
            audioSource.clip = newLevelMusic;
            if (scene.buildIndex != 0)
            {
                audioSource.loop = true;
            }
            audioSource.Play();
        }
    }
	// Update is called once per frame
	void Update () {
        
	}

    public void SetVolume(float newvolume)
    {
        audioSource.volume = newvolume;
    }
}
