using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneChange : MonoBehaviour
{
    public Transform nextRoomCamPos;
    public Transform nextRoomSpawnPos;
    public GameObject removeGroup;
    public GameObject addGroup;

    public float transitionTime;
    private Vector3 startPos;
    private bool move;
    private float timeElapsed;
    private Camera cam;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").gameObject.GetComponent<Camera>();
        move = false;
        addGroup.SetActive(false);
    }

    private void Update()
    {
        if (move)
        {
            cam.transform.position = Vector3.Lerp(startPos, nextRoomCamPos.position, timeElapsed / transitionTime);
            timeElapsed += Time.deltaTime;
        }

        if(cam.transform.position == nextRoomCamPos.position)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            move = true;
            SpawnPoint _sp = GameObject.Find("SpawnPoint").GetComponent<SpawnPoint>();
            _sp.transform.position = nextRoomSpawnPos.position;
            startPos = cam.transform.position;
            addGroup.SetActive(true);
            removeGroup.SetActive(false);
            _sp.Respawn(false);
        }
    }
}
