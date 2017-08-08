using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour
{
 
    Mesh mesh;
    Color[] meshColors;

    void Start() {
        mesh = GetComponent<MeshFilter>().mesh;
        meshColors = new Color[mesh.vertices.Length];
    }

    // Update is called once per frame
    void Update() {

        float offset = (transform.position.x + transform.position.y)/4;

        float r = Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad  + offset));
        float g = Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad  + offset));
        float b = Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad  + offset));
        Color newColor = new Color(1-r,1-g,1-b);
        for (int i=0; i<meshColors.Length; ++i) {
            meshColors [i] = newColor;
        }
        mesh.colors = meshColors;
        this.GetComponent<Renderer>().material.color = newColor;
    }
    
}