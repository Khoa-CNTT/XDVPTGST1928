using UnityEngine;

public class LighterScrip : MonoBehaviour
{
    public GameObject lighterObj;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        lighterObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisnable()
    {
        lighterObj.SetActive(false);
    }
}
