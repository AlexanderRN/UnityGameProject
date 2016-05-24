using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private StarDisplay starDisplay;
    private GameObject parent;

    void Start ()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        parent = GameObject.Find("Defenders");

        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
    }

    void OnMouseDown()
    {
        GameObject defender = Button.selectedDefender;
        int defenderPrice = defender.GetComponent<Defender>().starCost;
        
        if (starDisplay.SpendStars(defenderPrice) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(defender);
        } else
        {
            Debug.Log("Insufficient stars.");
        }
    }

    private void SpawnDefender(GameObject defender)
    {
        Vector2 pos = SnapToGrid(CalculateMouseClickWorldPoint());
        GameObject newDef = Instantiate(defender, pos, Quaternion.identity) as GameObject;
        newDef.transform.parent = parent.transform;
    }

    Vector2 CalculateMouseClickWorldPoint ()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        //Needs a distance, wont matter for this game.
        float distanceFromCamera = 10f;

        Vector3 aTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(aTriplet);

        return worldPos;
    }

    Vector2 SnapToGrid (Vector2 exactPosition)
    {
        float newX = Mathf.RoundToInt(exactPosition.x);
        float newY = Mathf.RoundToInt(exactPosition.y);

        return new Vector2(newX, newY);
    }
}
