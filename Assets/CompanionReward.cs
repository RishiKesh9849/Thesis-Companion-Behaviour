using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionReward : MonoBehaviour
{
    public Transform Reward;
    public CompanionFollow companion;
    // Start is called before the first frame update
    void Start()
    {
        Reward = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Companion"))
        {
            companion.FoundReward();
            Debug.Log("Found a reward");
        }
    }
}
