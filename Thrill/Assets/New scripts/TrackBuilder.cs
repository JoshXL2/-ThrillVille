using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class TrackBuilder : MonoBehaviour
{
    public SplineContainer splineContainer;
    public Camera cam;

    void Update()
    {
        if (!BuildModeManager.Instance.isBuildMode)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Click Detected");

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 500f))
            {
                Debug.Log("Hit: " + hit.collider.name);
                AddPoint(hit.point);
            }
            else
            {
                Debug.Log("Raycast hit nothing");
            }
        }
    }

    void AddPoint(Vector3 worldPos)
    {
        var spline = splineContainer.Spline;

        float3 localPos =
            splineContainer.transform.InverseTransformPoint(worldPos);

        BezierKnot knot = new BezierKnot(localPos);

        spline.Add(knot);

        Debug.Log("Point Added");
    }
}