using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    //
    //   OuterCircleRadius
    //   InnerCircleRadius
    //   DrawPointRadius
    //   OuterCircleRotationSpeed
    //
    //   DrawInterval
    //   GraphPointDistanceThreshold
    //   MaxGraphPoints
    // -------------------------------------------------------------------------

    #region .  Public Variables  .

    [Header("Spirograph")]
	public Transform OuterCircle;
	public Transform InnerCircle;
    public Transform DrawPoint;

    [Space, Header("Spirograph Controls")]
	public float     OuterCircleRadius        =  15.0f;
    public float     InnerCircleRadius        =   9.5f;
	public float     DrawPointRadius          =   5.0f;
    public float     OuterCircleRotationSpeed = 400.0f;

    [Space, Header("Spirograph Optimization")]
	[Range(0.0001f, 1.0f)] public float DrawInterval                = .0001f;      // .005f
    [Range(100, 50000)]    public int   MaxGraphPoints              = 5000;        // 5000.0
	                       public float GraphPointDistanceThreshold = .001f;       // .01f
    #endregion



    // -------------------------------------------------------------------------
    // Private Variables:
    // ------------------
    //   _firstGraphPoint
    //   _graphPoints
    //   _innerCircleRotationSpeed
    //   _lastDrawTime
    //   _shouldDraw
    //   _isCurveClosed
    //   _isFirstTime
    //   _sliderOuterCircle
    //   _sliderInnerCircle
    //   _sliderDrawPoint
    //   _sliderOuterCircleRotationSpeed
    //   _sliderGraphPointDistance
    //   _lineRendererOuterCircle
    //   _lineRendererSpirograph
    // -------------------------------------------------------------------------

    #region .  Private Variables  .

    private Vector3       _firstGraphPoint;
    private List<Vector3> _graphPoints;
    private float         _innerCircleRotationSpeed;
	private float         _lastDrawTime;
	private bool          _shouldDraw    = false;
	private bool          _isCurveClosed = false;
	private bool          _isFirstTime   = true;

    private Slider        _sliderOuterCircle;
    private Slider        _sliderInnerCircle;
    private Slider        _sliderDrawPoint;
    private Slider        _sliderOuterCircleRotationSpeed;
    private Slider        _sliderGraphPointDistance;

    private LineRenderer  _lineRendererOuterCircle;
    private LineRenderer  _lineRendererSpirograph;

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
		_lineRendererOuterCircle.positionCount = 0;

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

            if ( (distance > 0) && (distance < GraphPointDistanceThreshold) )
            {
                _isCurveClosed = true;
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
        _sliderOuterCircle              = UIManager.Instance.Slider_OuterCircle;
        _sliderInnerCircle              = UIManager.Instance.Slider_InnerCircle;
        _sliderDrawPoint                = UIManager.Instance.Slider_DrawPoint;
        _sliderOuterCircleRotationSpeed = UIManager.Instance.Slider_OuterCircleRotationSpeed;
        _sliderGraphPointDistance       = UIManager.Instance.Slider_GraphPointDistance;

        _lineRendererOuterCircle        = OuterCircle.GetComponent<LineRenderer>();
        _lineRendererSpirograph         = gameObject.GetComponent<LineRenderer>();

        //InitializePoints();

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

		_lineRendererSpirograph.positionCount = 0;

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
        _lineRendererSpirograph.positionCount = _graphPoints.Count;

		for (int i = 0; i < _graphPoints.Count; i++)
        {
            _lineRendererSpirograph.SetPosition(i, _graphPoints[i]);
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
        _graphPoints = new List<Vector3>();

		InnerCircle.transform.localPosition = new Vector3(OuterCircleRadius - InnerCircleRadius, 0f, 0f);
		DrawPoint  .transform.localPosition = new Vector3(DrawPointRadius, 0f, 0f);

		_innerCircleRotationSpeed = OuterCircleRotationSpeed * OuterCircleRadius / InnerCircleRadius;
        _firstGraphPoint          = DrawPoint.transform.localPosition;

        //if (UIManager.Instance.IsStarted)
        //{
        UpdateLine();
        //}

    }   //  InitializePoints()
    #endregion


    #region .  LateUpdate()  .
    //// -------------------------------------------------------------------------
    ////  Method.......:  LateUpdate()
    ////  Description..:  
    ////  Parameters...:  None
    ////  Returns......:  Nothing
    //// -------------------------------------------------------------------------
    //private void LateUpdate()
    //{
    //	if (_shouldDraw) return;

    //       if (UIManager.Instance.IsStarted)
    //       {
    //           UpdateLine();
    //       }

    //   }   // LateUpdate()
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
		float drawSphereRadius = 0.1f;

		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(OuterCircle.position, OuterCircleRadius);

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(InnerCircle.position, InnerCircleRadius);

		Gizmos.color = Color.magenta;
		Gizmos.DrawSphere(DrawPoint.position, drawSphereRadius);

    }   // OnDrawGizmos()
    #endregion


    #region .  OnDisable()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnDisable()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnDisable()
    {
        _sliderOuterCircle             .onValueChanged.RemoveListener((value) => { OuterCircleRadius           = value; });
        _sliderInnerCircle             .onValueChanged.RemoveListener((value) => { InnerCircleRadius           = value; });
        _sliderDrawPoint               .onValueChanged.RemoveListener((value) => { DrawPointRadius             = value; });
        _sliderOuterCircleRotationSpeed.onValueChanged.RemoveListener((value) => { OuterCircleRotationSpeed    = value; });
        _sliderGraphPointDistance      .onValueChanged.RemoveListener((value) => { GraphPointDistanceThreshold = value; });

    }   // OnDisable()
    #endregion


    #region .  OnEnable()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnEnable()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnEnable()
    {
        _sliderOuterCircle             .onValueChanged.AddListener((value) => { OuterCircleRadius           = value; });
        _sliderInnerCircle             .onValueChanged.AddListener((value) => { InnerCircleRadius           = value; });
        _sliderDrawPoint               .onValueChanged.AddListener((value) => { DrawPointRadius             = value; });
        _sliderOuterCircleRotationSpeed.onValueChanged.AddListener((value) => { OuterCircleRotationSpeed    = value; });
        _sliderGraphPointDistance      .onValueChanged.AddListener((value) => { GraphPointDistanceThreshold = value; });

    }   // OnEnable()
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

        //if (UIManager.Instance.IsStarted)
        //{
        //    InitializePoints();
        //    ClearGraph();
        //}

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
		OuterCircle.transform.Rotate( transform.forward,  OuterCircleRotationSpeed * Time.deltaTime);
		InnerCircle.transform.Rotate(-transform.forward, _innerCircleRotationSpeed * Time.deltaTime);

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
		if (_isCurveClosed) return;
		//if (_shouldDraw) return;

        if (UIManager.Instance.IsStarted)
        {
            if (_isFirstTime)
            {
                _isFirstTime = false;
                InitializePoints();
            }

            RotatePoints();
            AddPointToGraph(DrawPoint.transform.position);
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
		_lineRendererOuterCircle.positionCount = 3;
		_lineRendererOuterCircle.SetPosition(0, transform  .transform.position);
		_lineRendererOuterCircle.SetPosition(1, InnerCircle.transform.position);
		_lineRendererOuterCircle.SetPosition(2, DrawPoint  .transform.position);

    }   //  UpdateLine()
    #endregion


}   // class SpiroGraph
