using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    static GameManager instance;
    public int m_score;
    public int m_greatNum;
    public int m_coolNum;
    public int m_goodNum;
    public int m_missNum;
    float m_distance;
    float m_missDistance;
    float m_greatDistance;
    float m_coolDistance;
    float m_goodDistance;
    bool m_getAnykey;

    GameObject m_target;

    private void Awake()
    {
        if (instance == null) {instance = this; }
        else if (instance != null) { Destroy(gameObject); }

    }
    void Start () {
        InitGame();
      
    }
	
	void FixedUpdate () {
        GameObject[] _targets = GameObject.FindGameObjectsWithTag("Target");
        for(int i=0; i < _targets.Length; i++)
        {
            m_target = _targets[i];
            m_distance = Vector3.Distance(GameObject.Find("Player").transform.position, m_target.transform.position);
            //Debug.Log(m_distance);
            if (m_distance < m_missDistance)
            break; 
        }
        Judge();
        m_score = 1000 * m_greatNum + 600 * m_coolNum + 100 * m_goodNum;
    }
    
    void InitGame()
    {
        m_score=0;
        m_greatNum=0;
        m_coolNum=0;
        m_goodNum=0;
        m_missNum=0;
        m_missDistance = 5;
        m_greatDistance =0.5f;
        m_coolDistance = 1;
        m_goodDistance = 3;
        m_getAnykey = false;
    }
    void HitJudge()
    {
        if (m_distance < m_greatDistance)
        {

            m_greatNum++;
            AutoDebug();
            Destroy(m_target);
        }
        else if (m_distance < m_coolDistance)
        {

            m_coolNum++;
            AutoDebug();
            Destroy(m_target);
        }
        else if (m_distance < m_goodDistance)
        {

            m_goodNum++;
            AutoDebug();
            Destroy(m_target);
        }
    }
    void Judge()
    {
        if (m_distance < m_missDistance)
        {
            if (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.S) | Input.GetKeyDown(KeyCode.I) | Input.GetKeyDown(KeyCode.L) | Input.GetKeyDown(KeyCode.K) | Input.GetKeyDown(KeyCode.J))
            {
                HitJudge();
            }
         
        }
    }
    void AutoDebug()
    {
        Debug.Log("greatNum=" + m_greatNum);
        Debug.Log("m_coolNum=" + m_coolNum);
        Debug.Log("m_goodNum=" + m_goodNum);
        Debug.Log("m_missNum=" + m_missNum);
        Debug.Log("Score=" + m_score);
    }
    void OnTriggerExit(Collider collider)
    {
        m_missNum++;
        AutoDebug();
        m_target.tag = "Missed";
    }
}
