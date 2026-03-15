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
        //transform.position += Vector3.up * Time.deltaTime;

        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }
}
