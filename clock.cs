using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class clock : MonoBehaviour {

    //public  float _angleSpeed;
    string action = null;
    float time_unit;
    float count;
    float start_delay;
    int rd;
    int flag;
    string final;
    // Use this for initialization
    void Start () {
        rd = UnityEngine.Random.Range(1, 6);
        flag = 2;
    }

    void Update () {
        if(flag == 1){
            time_unit = Time.deltaTime;
            //action = string.Format("{0}s",start_delay);
            if(start_delay >= rd){
                action = "点击tap!!!!!!!!";
                count += time_unit;
                final = string.Format("{0}s",count);
            }
            else{
                start_delay += time_unit;
                action = "请准备";
            }
        }
        if(flag == -1){
            action = "提前点击，失败了";
        }
        if(flag == 0){
            action = "游戏结束";
            count = 0;
            start_delay = 0;
            rd = UnityEngine.Random.Range(1, 6); 
        }
        if(flag == 2){
             action = "测试你的反应时间，点击start开始游戏";
        }
    }
    void OnGUI()
    {
        GUI.TextField(new Rect(300, 120, 230, 40), action);
        GUI.TextField(new Rect(300, 160, 230, 40), final);
        if (GUI.Button(new Rect(350, 280, 110, 40), "start")) flag = 1;
        if (GUI.Button(new Rect(350, 230, 110, 40), "tap")){
            if (flag == 1){
                flag = 0;
            }
            else{
                flag = -1;
            }
        }
    }
}
