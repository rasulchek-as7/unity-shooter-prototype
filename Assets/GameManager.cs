using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int targetsLeft = 3;
    public Text targetText;
    public GameObject winText;

    void Start()
    {
        UpdateUI();
        winText.SetActive(false);
    }

    public void TargetDestroyed()
    {
        targetsLeft--;
        UpdateUI();

        if (targetsLeft <= 0)
        {
            Win();
        }
    }

    void UpdateUI()
    {
        targetText.text = "Targets: " + targetsLeft;
    }

    void Win()
    {
        winText.SetActive(true);
        //Time.timeScale = 0f;
    }
}