using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target;

    public GameController gameController;

    public float yOffset;    


    // Start is called before the first frame update
    void Start()
    {
        gameController.cameraFieldOfView = GetComponent<Camera>().fieldOfView;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = new Vector3(target.transform.position.x, target.transform.position.y + yOffset, target.transform.position.z);

        /*if (gameController.CanCameraMove(pos))
        {
            transform.position = pos;
        };*/

        transform.position = pos;
    }
}
