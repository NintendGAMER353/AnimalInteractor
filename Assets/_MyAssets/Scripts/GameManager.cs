using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public PresentSpawnController presentGen;

    public static GameManager Instance;

    public GameObject pausePanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void OnContinue()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }

    public void OnReturnMainMenu()
    {
        Debug.Log("Return Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void OnQuit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
