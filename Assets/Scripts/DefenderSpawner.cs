using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private StarDisplay starDisplay;
    private GameObject parent;

	// Use this for initialization
	void Start () {
        parent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseDown()
    {
        int defenderCost = Button.selectedDefender.GetComponent<Defender>().starCost;
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            Vector2 pos = SnapToGrid(CalculateWorldPointOfMouseClick());
            GameObject defender = Instantiate(Button.selectedDefender, pos, Quaternion.identity) as GameObject;
            defender.transform.parent = parent.transform;
        }
        
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float x = rawWorldPos.x;
        float y = rawWorldPos.y;

        return new Vector2(Mathf.Round(x), Mathf.Round(y));
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        float distanceToCamera = 10f;

        Vector3 weirdTriplet = new Vector3(x, y, distanceToCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }
}
