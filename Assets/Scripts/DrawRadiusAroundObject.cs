using UnityEngine;



[ExecuteAlways]
[RequireComponent(typeof(LineRenderer))]
public class DrawRadiusAroundObject : MonoBehaviour
{
    [Range(1, 50)]    public int   segments = 50;
    [Range(1,  5)]    public float xRadius  =  5;
    [Range(1,  5)]    public float yRadius  =  5;
    [Range(0.1f, 5f)] public float width    =  0.1f;

    public bool controlBothXradiusYradius = false;
    public bool draw = true;



    [SerializeField] private LineRenderer line;



    public void CreatePoints()
    {
        line.enabled         = true;
        line.widthMultiplier = width;
        line.useWorldSpace   = false;
        line.widthMultiplier = width;
        line.positionCount   = segments + 1;

        float x;
        float y;

        var    angle  = 20f;
        var points = new Vector3[segments + 1];

        for (int i = 0; i < segments + 1; i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xRadius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yRadius;

            points[i] = new Vector3(x, 0f, y);

            angle += (380f / segments);
        }

        // it's way more efficient to do this in one go!
        line.SetPositions(points);

    }   // CreatePoints()



    private void Start()
    {
        if (!line)
        {
            line = GetComponent<LineRenderer>();
        }

        CreatePoints();

    }   // Start()



#if UNITY_EDITOR
    private float _previousRadiusX;
    private float _previousRadiusY;
    private int   _previousSegments;
    private float _previousWidth;


    private void OnValidate()
    {
        // Can't set up our line if the user hasn't connected it yet.
        if (!line)
        {
            line = GetComponent<LineRenderer>();
        }

        if (!line)
        {
            return;
        }

        if (!draw)
        {
            // Instead simply disable the component.
            line.enabled = false;
        }
        else
        {
            // Otherwise re-enable the component (re-use the previously created points).
            line.enabled = true;

            if ( (xRadius  != _previousRadiusX ) ||
                 (yRadius  != _previousRadiusY ) ||
                 (segments != _previousSegments) ||
                 (width    != _previousWidth   ) )
            {
                CreatePoints();

                // Cache the most recently used values.
                _previousRadiusX  = xRadius;
                _previousRadiusY  = yRadius;
                _previousSegments = segments;
                _previousWidth    = width;
            }

            if (controlBothXradiusYradius)
            {
                yRadius = xRadius;
            }
        }

    }   // OnValidate()
#endif


}   // class DrawRadiusAroundObject
