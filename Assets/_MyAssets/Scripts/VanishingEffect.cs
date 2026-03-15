using UnityEngine;

public class VanishingEffect : MonoBehaviour
{

    Timer timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = new(1);
    }

    // Update is called once per frame
    void Update()
    {

       
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }
}
