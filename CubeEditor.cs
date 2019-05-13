using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor: MonoBehaviour
{
    
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
        
    }


    // Update is called once per frame
    void Update()
    {
        //X and Z snap
        SnapToGrid();
        //text and label
        UpdateLabel();

    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();

        transform.position = new Vector3(
            waypoint.GetGridPos().x * gridSize,
            0f,
            waypoint.GetGridPos().y * gridSize);
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = waypoint.GetGridSize();
        string labelText =
            waypoint.GetGridPos().x  +
            "," +
            waypoint.GetGridPos().y;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
