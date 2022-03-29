using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Player_Controller m_Player;      
    private Vector3 m_v3RelationCamPos;     //玩家和相机相对距离
    private float m_magnitude;
    // Start is called before the first frame update
    void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
        m_v3RelationCamPos = transform.position - m_Player.transform.position;
        m_magnitude = m_v3RelationCamPos.magnitude;         //相对距离的模
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = m_Player.transform.position + m_v3RelationCamPos;
    }

    //void CalcPoints()
    //{
    //    Vector3 standPos = m_Player.transform.position + m_v3RelationCamPos;
    //}
}
