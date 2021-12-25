using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class locator : MonoBehaviour
{
    Transform target;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "desert")
            target = GameObject.FindGameObjectWithTag("locator").transform;
        else this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (target !=null)
        {
            transform.LookAt(target.position);
        }
        
    }
}
