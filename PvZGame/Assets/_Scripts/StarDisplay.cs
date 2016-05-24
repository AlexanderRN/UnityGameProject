using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

    public int totalStars = 50;
    private Text text;
    public enum Status {SUCCESS, FAILURE};

    void Start()
    {
        text = GetComponent<Text>();
        UpdateDisplay();
    }

    public void AddStars (int amount)
    {
        totalStars += amount;
        UpdateDisplay();
    }

    public Status SpendStars (int amount)
    {
        if (totalStars >= amount)
        {
            totalStars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;

    }

    private void UpdateDisplay()
    {
        text.text = totalStars.ToString();
    }

}
