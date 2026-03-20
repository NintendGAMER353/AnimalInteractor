using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.VictoryPanel.SetActive(true);
        Time.timeScale = 0f;
        GameManager.Instance.paused = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
