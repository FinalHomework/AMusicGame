using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoint : MonoBehaviour {
    public int m_pointNum;
    public GameObject prefabs;
    float _timer;
    int _timernum=0;
    bool cancreat=true;
    public GameObject _flypoint1;

    // Use this for initialization
	void Start ()
    {
        CreatPoint(m_pointNum);
    }

    // Update is called once per frame
    void Update ()
    {
        Timer();
        Debug.Log(_timernum);


        if (_timernum== 5&&cancreat)//Creat point
        {
            CreatFlyPoint();
            cancreat = false;
        }


        if (_timernum>=7)//Fly point move
        {
            _flypoint1.transform.localPosition = Vector3.MoveTowards(_flypoint1.transform.localPosition, new Vector3(0,0,110), 20f*Time.deltaTime);
        }
	}

    /// <summary>
    /// Creat point
    /// </summary>
    /// <param name="pointNum"></param>
    public void CreatPoint(int pointNum)
    {
        for(int _point = 0; _point<=pointNum-1; _point++)
        {
            Instantiate(prefabs, new Vector3(0,0,20*_point), Quaternion.identity);
        }
    }

    /// <summary>
    /// Creat fly point
    /// </summary>
    /// <param name="_flynum"></param>
    public void CreatFlyPoint()
    {
        _flypoint1= Instantiate(prefabs, new Vector3(20, 0, 110), Quaternion.identity);
        _flypoint1.name = "Flypoint1";
        Timer();
    }

    /// <summary>
    /// The timer
    /// </summary>
    /// <returns></returns>
    public float Timer()
    {
        _timer += Time.deltaTime;
        if (_timer >= 1)
        {
            _timernum++;
            _timer = 0;
        }
        return _timernum;
    }
}
