using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

    private Text text;
    private int stars = 100;
    public enum Status {SUCCESS, FAILURE}
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        UpdateDisplay();
        InvokeRepeating("GenerateStars", 1f, 7f);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void GenerateStars()
    {
        stars += 5;
        UpdateDisplay();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    

    public Status UseStars(int amount)
    {
        if ((stars - amount) >= 0)
        {
            stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    private void UpdateDisplay()
    {
        text.text = stars.ToString();
    }
}
