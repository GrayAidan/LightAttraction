using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneChange : MonoBehaviour
{
    public Transform nextRoomCamPos;
    public float transitionTime;
    private Vector3 startPos;
    private bool move;
    private float timeElapsed;
    private Camera cam;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").gameObject.GetComponent<Camera>();
        move = false;
        startPos = cam.transform.position;
    }

    private void Update()
    {
        if (move)
        {
            cam.transform.position = Vector3.Lerp(startPos, nextRoomCamPos.position, timeElapsed / transitionTime);
            timeElapsed += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            move = true;
        }
    }
}
