using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColorChange : MonoBehaviour {


    Mesh mesh;
    Color[] meshColors;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        meshColors = new Color[mesh.vertices.Length];
    }

    // Update is called once per frame
    void Update()
    {


        float r = Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad));
        float g = Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad*0.5f));
        float b = Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad*1.5f));
        Color newColor = new Color(r,g,b);
        for (int i = 0; i < meshColors.Length; ++i)
        {
            meshColors[i] = newColor;
        }
        mesh.colors = meshColors;
        this.GetComponent<Renderer>().material.color = newColor;
    }
}
