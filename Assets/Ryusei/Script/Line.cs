using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Line : MonoBehaviour
{

    public bool ElectricityFlg;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Player" && ElectricityFlg == true)
    //    {
    //        Debug.Log("感電！");
    //    }
    //}

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player" && ElectricityFlg == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("感電！");
        }
    }
}
