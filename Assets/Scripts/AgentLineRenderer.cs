using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

// https://gamedev.stackexchange.com/questions/67839/is-there-a-way-to-display-navmesh-agent-path-in-unity
public class AgentLineRenderer : MonoBehaviour
{
    private LineRenderer line; //to hold the line Renderer

    private void Start()
    {
        line = GetComponent<LineRenderer>(); //get the line renderer
        line.material = new Material(Shader.Find("Sprites/Default"));
        // Set the start to a light blue.
        line.startColor = Color.blue;
    }

    public void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2) //if the path has 1 or no corners, there is no need
            return;

        line.SetPosition(0, transform.position);
        line.positionCount = path.corners.Length; //set the array of positions to the amount of corners

        for (var i = 1; i < path.corners.Length; i++)
        {
            line.SetPosition(i, path.corners[i]); //go through each corner and set that to the line renderer's position
        }
    }
}
