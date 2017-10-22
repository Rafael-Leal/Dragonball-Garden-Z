using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    public Image image;
    private Color color;

    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();
        color.a = 1f;
        image.color = color;
    }
	
	// Update is called once per frame
	void Update () {
		if(image.color.a > 0f)
        {
            color.a -= .01f;
            image.color = color;
        }
        else
        {
            gameObject.SetActive(false);
        }
        
	}
}
