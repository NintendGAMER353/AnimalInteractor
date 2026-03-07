using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
