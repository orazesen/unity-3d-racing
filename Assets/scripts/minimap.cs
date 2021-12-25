using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour
{
    Transform player;
    LineRenderer lineRenderer;
    GameObject trackPath;
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lineRenderer = GetComponent<LineRenderer>();
        trackPath = this.gameObject;

        int num_of_path = trackPath.transform.childCount;

        lineRenderer.positionCount = num_of_path + 1;

        for (int i = 0; i < num_of_path; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(trackPath.transform.GetChild(i).transform.position.x, 4, trackPath.transform.GetChild(i).transform.position.z));
        }

        lineRenderer.SetPosition(num_of_path, trackPath.transform.GetChild(num_of_path - 1).transform.position);
        lineRenderer.startWidth = 10f;
        lineRenderer.endWidth = 10f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = player.position;
        newPos.y = camera.position.y;
        camera.position = newPos;

        camera.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
