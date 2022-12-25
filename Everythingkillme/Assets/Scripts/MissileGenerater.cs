using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerater : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject VanPrefab;
    public GameObject BeetlePrefab;
    public GameObject PlanePrefab;
    public GameObject SshipPrefab;
    float span1 = 1.0f;
    float span2 = 4.0f;
    float span3 = 4.5f;
    float span4 = 3.0f;
    float span5 = 3.5f;
    float delta1 = 0;
    float delta2 = 0;
    float delta3 = 0;
    float delta4 = 0;
    float delta5 = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta1 += Time.deltaTime;
        this.delta2 += Time.deltaTime;
        this.delta3 += Time.deltaTime;
        this.delta4 += Time.deltaTime;
        this.delta5 += Time.deltaTime;

        if (this.delta1 > this.span1) // 미사일 생성
        {
            this.delta1 = 0;
            GameObject go1 = Instantiate(bombPrefab) as GameObject;
            int px = Random.Range(-8, 9);
            go1.transform.position = new Vector3(px, 6, 0);
        }

        if (this.delta2 > this.span2) // 차량 생성
        {
            this.delta2 = 0;
            GameObject go3 = Instantiate(BeetlePrefab) as GameObject;
            go3.transform.position = new Vector3(10, -3.6f, 0);
        }

        if (this.delta3 > this.span3) // 버스 생성
        {
            this.delta3 = 0;
            GameObject go2 = Instantiate(VanPrefab) as GameObject;
            go2.transform.position = new Vector3(-10, -3.6f, 0);
        }

        if (this.delta4 > this.span4) // 1번 비행기 생성
        {
            this.delta4 = 0;
            GameObject go4 = Instantiate(PlanePrefab) as GameObject;
            int ry = Random.Range(-3, 6);
            go4.transform.position = new Vector3(10, ry, 0);
        }

        if (this.delta5 > this.span5) // 2번 비행기 생성
        {
            this.delta5 = 0;
            GameObject go5 = Instantiate(SshipPrefab) as GameObject;
            int ry = Random.Range(-1, 6);
            go5.transform.position = new Vector3(-10, ry, 0);
        }
    }
}
