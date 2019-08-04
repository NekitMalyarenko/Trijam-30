using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [Serializable]
    private class LevelData
    {
        public GameObject level;
        public GameObject floor;

        public GameObject spawn = null;
        public GameObject finish = null;

        public Vector3 cameraBounces;

        public bool hasFinish = true;
    }


    [SerializeField] private LevelData[] levels;

    public GameObject finishPrefab;

    public float cameraFieldOfView;

    private int currentLevel = -1;


    public void InitGame()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            LevelData item = levels[i];
            this.InitLevel(item);

            if (i != 0)
            {
                this.Hide(item.level);
            }
        }
    }


    private void InitLevel(LevelData levelData)
    {
        Vector3 sizes = levelData.floor.GetComponent<Collider>().bounds.size;

        if (levelData.spawn == null)
        {
            Vector3 spawnPos = Vector3.zero;
            spawnPos.x = levelData.floor.transform.position.x;
            spawnPos.z = levelData.floor.transform.position.z - (sizes.z / 2) + 0.5f;
            spawnPos.y = levelData.floor.transform.position.y + 0.3f;

            levelData.spawn = Instantiate(new GameObject(), spawnPos, Quaternion.identity);
        }

        if (levelData.finish == null && levelData.hasFinish)
        {

            Vector3 finishPos = Vector3.zero;
            finishPos.x = levelData.floor.transform.position.x;
            finishPos.z = levelData.floor.transform.position.z + (sizes.z / 2);
            finishPos.y = levelData.floor.transform.position.y + 1.2f;

            levelData.finish = Instantiate(finishPrefab, finishPos, finishPrefab.transform.rotation);
        }

        levelData.cameraBounces = Vector3.zero;
        levelData.cameraBounces.x = levelData.floor.transform.position.x + sizes.x - cameraFieldOfView;
        levelData.cameraBounces.y = 10;
        levelData.cameraBounces.z = levelData.floor.transform.position.z + sizes.z - cameraFieldOfView;
    }


    public void NextLevel(GameObject player)
    {
        this.Show(levels[currentLevel + 1].level);

        Rigidbody rb = player.gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.MovePosition(rb.transform.position);
        rb.MoveRotation(Quaternion.identity);

        player.transform.position = levels[currentLevel + 1].spawn.transform.position;

        if (currentLevel != -1) this.Hide(levels[currentLevel].level);
        this.currentLevel++;
    }


    public Boolean CanCameraMove(Vector3 position)
    {
        Vector3 bounces = levels[currentLevel].cameraBounces;

        if (position.x != 0 && bounces.x < 0)
            return false;

        if (position.z != 0 && bounces.z < 0)
            return false;

        if (position.x < 0 && position.x * -1 > bounces.x)
        {
            return false;
        }

        if (position.z < 0 && position.z * -1 > bounces.z)
        {
            return false;
        }

        return true;
    }


    private void Show(GameObject root)
    {

        root.SetActive(true);
        /*Renderer renderer = root.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = true;
        }

        Transform[] children = root.GetComponentsInChildren<Transform>(true);
        if (children != null && children.Length > 1)
        {
            for (int i = 1; i < children.Length; i++)
            {
                this.Show(children[i].gameObject);
            }
        }*/
    }


    private void Hide(GameObject root)
    {
        root.SetActive(false);

        /*Transform[] children = root.GetComponentsInChildren<Transform>();
        if (children != null && children.Length > 1)
        {
            for (int i = 1; i < children.Length; i++)
            {
                this.Hide(children[i].gameObject);
            }
        }*/
    }
}
