using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    [SerializeField] private string[] tags;


    void OnTriggerEnter(Collider other)
    {
        foreach(string tag in tags)
        {
            if (tag == other.gameObject.tag)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
