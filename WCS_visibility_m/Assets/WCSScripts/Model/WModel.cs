using System;
using UnityEngine;

public class WModel
{
    public GameObject objPrefab;

    public WModelInfo info;

    public float pos_x;
    public float pos_y;
    public float pos_z;
    public int floor;
    public float scale_x;
    public float scale_y;
    public float scale_z;


    public WModel()
	{
        info = new WModelInfo();

        pos_x = 0f;
        pos_y = 0f;
        pos_z = 0f;
        floor = 1;
    }
}

