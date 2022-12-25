using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour
{
    GameObject Record;
    // Start is called before the first frame update
    void Start()
    {
        this.Record = GameObject.Find("Record");
    }

    // Update is called once per frame
    void Update()
    {

        this.Record.GetComponent<Text>().text = "당신의 기록은 " + GameDirector.recording.ToString("F2") + "초입니다.";
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("FirstScene");
        }
    }
}
