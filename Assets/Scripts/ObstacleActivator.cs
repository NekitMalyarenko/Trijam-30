using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleActivator : MonoBehaviour
{

    [SerializeField] private BouncingSphere[] obstacles;

    private bool isActivated = false;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    void OnTriggerEnter(Collider other)
    {

        if (this.isActivated) return;

        if (other.gameObject.tag == "Player")
        {
            this.isActivated = true;
            foreach (BouncingSphere item in obstacles)
            {
                item.Activate();
            }
        }
    }
}
