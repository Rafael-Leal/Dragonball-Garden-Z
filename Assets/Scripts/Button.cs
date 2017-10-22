using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    private Button[] buttonArray;
    private Text costText;

    public GameObject defender;
    public static GameObject selectedDefender;

    // Use this for initialization
    void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogWarning(name + "has no cost");
        }

        costText.text = defender.GetComponent<Defender>().starCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        if (defender)
        {
            selectedDefender = defender;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
