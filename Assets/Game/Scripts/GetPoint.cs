using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoint : MonoBehaviour {
    public int m_pointNum;
    public int ad_libNum;
    public int m_flypointNum;

    public GameObject Point;
    public GameObject Ad_lib;
    public GameObject Flypoint;
    GameObject flypoint;

    float _timer;
    int _timernum=0;
    bool cancreat=true;

    // Use this for initialization
	void Start ()
    {
        CreatPoint(m_pointNum);
        CreatAdLib(ad_libNum);
    }

    // Update is called once per frame
    void Update ()
    {
        Timer();
        Debug.Log(_timernum);
        FlyPointMove(_timernum);
	}

    /// <summary>
    /// Creat point
    /// </summary>
    /// <param name="pointNum"></param>
    public void CreatPoint(int m_pointNum)
    {
        for(int _pointNum = 0; _pointNum<=m_pointNum-1; _pointNum++)
        {
            GameObject point= Instantiate(Point, new Vector3(0,0,20*_pointNum), Quaternion.identity);
            point.name = "Point" + (_pointNum+1);
        }
    }

    /// <summary>
    /// Creat fly point
    /// </summary>
    /// <param name="_flynum"></param>
    public void CreatFlyPoint()
    {
        flypoint= Instantiate(Flypoint, new Vector3(20, 0, 50), Quaternion.identity);
        flypoint.name = "Flypoint" + 1;
    }

    /// <summary>
    /// Fly point move
    /// </summary>
    /// <param name="_timernum"></param>
    public void FlyPointMove(int _timernum)
    {
        if (_timernum == 3 && cancreat)//Creat fly point
        {
            CreatFlyPoint();
            cancreat = false;
        }
        if (_timernum >= 4 && _timernum <= 15)//Fly point move
        {
            float step = 20f * Time.deltaTime;
            Debug.Log("Come on!!!!");
            flypoint.transform.localPosition = Vector3.MoveTowards(flypoint.transform.localPosition, new Vector3(0, 0, 50), step);
            Debug.Log("I'm crazy!!!");
        }
    }

    /// <summary>
    /// Creat ad-lib
    /// </summary>
    public void CreatAdLib(int ad_lib)
    {
        for (int _adlib = 1; _adlib <= ad_lib - 1; _adlib++)
        {
            GameObject adlib =Instantiate(Ad_lib, new Vector3(0, 0, 12*_adlib), Quaternion.identity);
            adlib.name = "Ad-lib" + (_adlib + 1);
        }
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
