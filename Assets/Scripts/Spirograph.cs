using System.Collections.Generic;
using UnityEngine;


// -----------------------------------------------------------------------------
//  Class........:  Spirograph
//
//  Description..:  Attach this to the parent GameObject of the Spirograph.
//                  The parent GameObject should have two child GameObjects
//                  that represent the inner and outer circles, and a third
//                  child GameObject that represents the draw point.  The
//                  LineRenderer components for the outer circle and the
//                  spirograph should be assigned in the inspector.
// -----------------------------------------------------------------------------

public class Spirograph : Singleton<Spirograph>
{
    // -------------------------------------------------------------------------
    // Public Variables:
    // -----------------
    //   DrawPoint
    //   InnerCircle
    //   OuterCircle
    //   LineRendererOuterCircle
    //   LineRendererSpirograph
    //
    //   DrawPointRadius
    //   InnerRadius
    //   OuterRadius
    //   OuterCircleRotationSpeed
    //
    //   MaxGraphPoints
    //   DrawInterval
    //   GraphPointDistanceThreshold
    // -------------------------------------------------------------------------

    #region .  Public Variables  .


    [Header("Spirograph")]
    public Transform     DrawPoint;
	public Transform     InnerCircle;
	public Transform     OuterCircle;
	public LineRenderer  LineRendererOuterCircle;
    public LineRenderer  LineRendererSpirograph;

    [Space, Header("Spirograph Controls")]
	                     public float    DrawPointRadius             =   5.0f;      //   5.0f
                         public float    InnerCircleRadius           =   9.5f;      //   9.5f
	                     public float    OuterCircleRadius           =  15.0f;      //  15.0f
    [Range(10f, 1500f)]  public float    OuterCircleRotationSpeed    = 400.0f;      // 200.0f

    [Space, Header("Spirograph Optimization")]
	                     public int      MaxGraphPoints              = 5000;        // 5000.0
	[Range(0.0001f, 1f)] public float    DrawInterval                = .0001f;      // .005f
	[Range(0.01f,   1f)] public float    GraphPointDistanceThreshold = .01f;        // .01f

    #endregion



    // -------------------------------------------------------------------------
    // Private Variables:
    // ------------------
    //   _firstGraphPoint
    //   _graphPoints
    //   _innerCircleRotationSpeed
    //   _lastDrawTime
    //   _shouldDraw
    // -------------------------------------------------------------------------

    #region .  Private Variables  .

    private Vector3       _firstGraphPoint;
    private List<Vector3> _graphPoints;
    private float         _innerCircleRotationSpeed;
	private float         _lastDrawTime;
	private bool          _shouldDraw = false;

    #endregion



    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   ClearLineVisuals()
    // -------------------------------------------------------------------------

    #region .  ClearLineVisuals()  .
    // -------------------------------------------------------------------------
    //  Method.......:  ClearLineVisuals()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void ClearLineVisuals()
	{
		_shouldDraw = true;
		LineRendererOuterCircle.positionCount = 0;

		OuterCircle.gameObject.SetActive(false);

    }   //  ClearLineVisuals()
    #endregion



    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   AddPointToGraph()
    //   Awake()
    //   ClearGraph()
    //   DrawSpiroGraph()
    //   InitializePoints()
    //   LateUpdate()
    //   OnDrawGizmos()
    //   OnValidate()
    //   RotatePoints()
    //   Update()
    //   UpdateLine()
    // -------------------------------------------------------------------------

    #region .  AddPointToGraph()  .
    // -------------------------------------------------------------------------
    //  Method.......:  AddPointToGraph()
    //  Description..:  
    //  Parameters...:  Vector3
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void AddPointToGraph(Vector3 pointToDraw)
	{
        _graphPoints.Add(pointToDraw);

        //DebugText.text = $"AddPointToGraph:  _graphPoints.Count = {_graphPoints.Count}, _firstGraphPoint = {_firstGraphPoint}, pointToDraw = {pointToDraw}, distance = {distance}";
        
        if (Time.time - _lastDrawTime >= DrawInterval)
		{
			_lastDrawTime = Time.time;

            float distance = (_graphPoints.Count == 1)
                           ? 0f
                           : Vector3.Distance(pointToDraw, _graphPoints[0]);

            if ( (distance > 0) && ( distance < GraphPointDistanceThreshold) )
            {
                Debug.Log($"Curve closed, distance = {distance}, GraphPointDistanceThreshold = {GraphPointDistanceThreshold}");
            }

            if (_graphPoints.Count > MaxGraphPoints)
            {
                Debug.Log($"Maximum points reached = {MaxGraphPoints}");
                ClearLineVisuals();
            }

            DrawSpiroGraph();
		}

    }   //  AddPointToGraph()
    #endregion


    #region .  Awake()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Awake()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Awake()
	{
        _graphPoints = new List<Vector3>();

		InitializePoints();

    }	// Awake()
    #endregion


    #region .  ClearGraph()  .
    // -------------------------------------------------------------------------
    //  Method.......:  ClearGraph()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void ClearGraph()
	{
		_graphPoints?.Clear();

		LineRendererSpirograph.positionCount = 0;

    }   //  ClearGraph()
    #endregion


    #region .  DrawSpiroGraph()  .
    // -------------------------------------------------------------------------
    //  Method.......:  DrawSpiroGraph()
    //  Description..:  This method draws the spirograph.  Set the position count
    //                  of the LineRenderer to the number of points in the graph.
    //                  Loop through the list of points and set the position of a
    //                  vertex in the line.
    //  Parameters...:  None 
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void DrawSpiroGraph()
	{
		LineRendererSpirograph.positionCount = _graphPoints.Count;

		for (int i = 0; i < _graphPoints.Count; i++)
        {
			LineRendererSpirograph.SetPosition(i, _graphPoints[i]);
		}

        //TODO:  add a text label showing the current count.

    }   //  DrawSpiroGraph()
    #endregion


    #region .  InitializePoints()  .
    // -------------------------------------------------------------------------
    //  Method.......:  InitializePoints()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void InitializePoints()
	{
		_innerCircleRotationSpeed = OuterCircleRotationSpeed * OuterCircleRadius / InnerCircleRadius;
		InnerCircle.localPosition = new Vector3(OuterCircleRadius - InnerCircleRadius, 0f, 0f);
		DrawPoint  .localPosition = new Vector3(DrawPointRadius, 0f, 0f);
        _firstGraphPoint          = DrawPoint.localPosition;

        //if (UIManager.Instance.IsStarted)
        //{
        UpdateLine();
        //}

    }   //  InitializePoints()
    #endregion


    #region .  LateUpdate()  .
    // -------------------------------------------------------------------------
    //  Method.......:  LateUpdate()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void LateUpdate()
	{
		if (_shouldDraw) return;

        if (UIManager.Instance.IsStarted)
        {
            UpdateLine();
        }

    }   // LateUpdate()
    #endregion


    #region .  OnDrawGizmos()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnDrawGizmos()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, OuterCircleRadius);

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(InnerCircle.position, InnerCircleRadius);

		float drawSphereRadius = 0.1f;

		Gizmos.color = Color.magenta;
		Gizmos.DrawSphere(DrawPoint.position, drawSphereRadius);

    }   // OnDrawGizmos()
    #endregion


    #region .  OnValidate()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnValidate()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnValidate()
	{
		_shouldDraw = false;
		OuterCircle.gameObject.SetActive(true);

        if (UIManager.Instance.IsStarted)
        {
            InitializePoints();
            ClearGraph();
        }

    }   // OnValidate()
    #endregion


    #region .  RotatePoints()  .
    // -------------------------------------------------------------------------
    //  Method.......:  RotatePoints()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void RotatePoints()
	{
		OuterCircle.Rotate(transform.forward,   OuterCircleRotationSpeed * Time.deltaTime);
		InnerCircle.Rotate(-transform.forward, _innerCircleRotationSpeed * Time.deltaTime);

    }   //  RotatePoints()
    #endregion


    #region .  Update()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Update()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Update()
	{
		if (_shouldDraw) return;

        if (UIManager.Instance.IsStarted)
        {
            RotatePoints();
            AddPointToGraph(DrawPoint.position);
        }

    }   // Update()
    #endregion


    #region .  UpdateLine()  .
    // -------------------------------------------------------------------------
    //  Method.......:  UpdateLine()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void UpdateLine()
    {
		LineRendererOuterCircle.positionCount = 3;
		LineRendererOuterCircle.SetPosition(0, transform  .position);
		LineRendererOuterCircle.SetPosition(1, InnerCircle.position);
		LineRendererOuterCircle.SetPosition(2, DrawPoint  .position);

    }   //  UpdateLine()
    #endregion


}   // class SpiroGraph
