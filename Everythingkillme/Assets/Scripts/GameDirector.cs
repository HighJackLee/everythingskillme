using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject hpui;
    GameObject Record;
    public static float recording;

    // Start is called before the first frame update
    void Start()
    {
        this.hpui = GameObject.Find("hpui");
        this.Record = GameObject.Find("Record");
        recording = 0;
    }

    public void DecreaseHp()
    {
        this.hpui.GetComponent<Image>().fillAmount -= 0.35f;
    }

    // Update is called once per frame
    void Update()
    {
        recording += Time.deltaTime;
        this.Record.GetComponent<Text>().text = recording.ToString("F2") + "초";

        // 플레이어의 체력이 0이 된다면 클리어 창으로
        if (this.hpui.GetComponent<Image>().fillAmount == 0.0f)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
