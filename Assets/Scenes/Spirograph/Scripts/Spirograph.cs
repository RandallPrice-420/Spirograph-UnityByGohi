using System.Collections.Generic;
using TMPro;
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
    //   OuterCircle
    //   InnerCircle
    //   DrawPoint
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
    public GameObject OuterCircle;
    public GameObject InnerCircle;
    public GameObject DrawPoint;

    [Space, Header("Spirograph Controls")]
    public float OuterCircleRadius;             // =   15.0f;
    public float InnerCircleRadius;             // =    9.5f;
	public float DrawPointRadius;               // =    5.0f;
    public float OuterCircleRotationSpeed;      // = 2500.0f;

    [Space, Header("Spirograph Optimization")]
	[Range(0.0001f, 1.0f)] public float DrawInterval                = .0001f;      // .005f
    [Range(100, 50000)]    public int   MaximumGraphPoints          = 5000;        // 5000.0
	                       public float GraphPointDistanceThreshold = .001f;       // .01f

    [Space]
    public TMP_Text TMP_MaximumGraphPointsValue;
    public TMP_Text TMP_GraphPointCountValue;

    #endregion



    // -------------------------------------------------------------------------
    // Private Variables:
    // ------------------
    //   _firstGraphPoint
    //   _graphPoints
    //   _innerCircleRotationSpeed
    //   _isCurveClosed
    //   _isFirstTime
    //   _isMaxPointsReacheded
    //   _pointCount
    //   _lastDrawTime
    //
    //   _sliderOuterCircle
    //   _sliderInnerCircle
    //   _sliderDrawPoint
    //   _sliderOuterCircleRotationSpeed
    //   _sliderGraphPointDistance
    //
    //   _lineRendererOuterCircle
    //   _lineRendererSpirograph
    // -------------------------------------------------------------------------

    #region .  Private Variables  .

    private Vector3       _firstGraphPoint;
    private List<Vector3> _graphPoints;
    private float         _innerCircleRotationSpeed;
	private bool          _isCurveClosed        = false;
	private bool          _isFirstTime          = true;
	private bool          _isMaxPointsReacheded = false;
    private int           _pointCount           = 0;
	private float         _lastDrawTime;

    private Slider        _sliderOuterCircle;
    private Slider        _sliderInnerCircle;
    private Slider        _sliderDrawPoint;
    private Slider        _sliderOuterCircleRotationSpeed;
    private Slider        _sliderGraphPointDistance;
    private Slider        _sliderMaximumGraphPoints;

    private LineRenderer  _lineRendererOuterCircle;
    private LineRenderer  _lineRendererSpirograph;

    #endregion



    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   ClearGraph()
    //   ClearLineVisuals()
    // -------------------------------------------------------------------------

    #region .  ClearGraph()  .
    // -------------------------------------------------------------------------
    //  Method.......:  ClearGraph()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void ClearGraph()
	{
        _isCurveClosed        = false;
        _isFirstTime          = true;
        _isMaxPointsReacheded = false;
        _lastDrawTime         = 0f;

        _graphPoints?.Clear();

		_lineRendererSpirograph.positionCount = 0;

    }   //  ClearGraph()
    #endregion


    #region .  ClearLineVisuals()  .
    // -------------------------------------------------------------------------
    //  Method.......:  ClearLineVisuals()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void ClearLineVisuals()
	{
		//_shouldDraw = true;
		_lineRendererOuterCircle.positionCount = 0;

		OuterCircle.SetActive(false);

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
        // Increment the graph point count and update the UI.
        _pointCount++;
        TMP_GraphPointCountValue.text = _pointCount.ToString();

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

            if (_graphPoints.Count > MaximumGraphPoints)
            {
                Debug.Log($"Maximum points reached = {MaximumGraphPoints}");

                _isMaxPointsReacheded = true;
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
        _sliderOuterCircle                 = UIManager.Instance.Slider_OuterCircle;
        _sliderInnerCircle                 = UIManager.Instance.Slider_InnerCircle;
        _sliderDrawPoint                   = UIManager.Instance.Slider_DrawPoint;
        _sliderOuterCircleRotationSpeed    = UIManager.Instance.Slider_OuterCircleRotationSpeed;
        _sliderGraphPointDistance          = UIManager.Instance.Slider_GraphPointDistance;
        _sliderMaximumGraphPoints          = UIManager.Instance.Slider_MaximumGraphPoints;

        _lineRendererOuterCircle           = OuterCircle.GetComponent<LineRenderer>();
        _lineRendererSpirograph            = gameObject .GetComponent<LineRenderer>();

        TMP_MaximumGraphPointsValue        = GameObject.Find("TMP_MaximumGraphPointsValue").GetComponent<TMP_Text>();
        TMP_GraphPointCountValue           = GameObject.Find("TMP_GraphPointCountValue")   .GetComponent<TMP_Text>();

        //TMP_MaximumGraphPointsValue        = UIManager.Instance.TMP_MaximumGraphPointsValue;
        //TMP_GraphPointCountValue           = UIManager.Instance.TMP_GraphPointCountValue;

        TMP_MaximumGraphPointsValue.text   = MaximumGraphPoints.ToString();
        TMP_GraphPointCountValue   .text   = "0";

    }	// Awake()
    #endregion


    #region .  DrawSpiroGraph()  .
    // -------------------------------------------------------------------------
    //  Method.......:  DrawSpiroGraph()
    //  Description..:  This method draws the spirograph.  Set the position count
    //                  of the LineRenderer to the number of points in the graph.
    //                  Loop through the list of points and draw the line.
    //  Parameters...:  None 
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void DrawSpiroGraph()
	{
        _lineRendererSpirograph.positionCount = _graphPoints.Count;

		for (int i = 0; i < _graphPoints.Count; i++)
        {
            TMP_GraphPointCountValue.text = i.ToString();

            _lineRendererSpirograph.SetPosition(i, _graphPoints[i]);
		}

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
		Gizmos.DrawWireSphere(OuterCircle.transform.position, OuterCircleRadius);

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(InnerCircle.transform.position, InnerCircleRadius);

		Gizmos.color = Color.magenta;
		Gizmos.DrawSphere(DrawPoint.transform.position, drawSphereRadius);

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
        //SliderHandler.OnValueChanged -= this.OuterCircleValueChanged;

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
        //SliderHandler.OnValueChanged += this.OuterCircleValueChanged;

        _sliderOuterCircle             .onValueChanged.AddListener((value) => { OuterCircleRadius           = value; });
        _sliderInnerCircle             .onValueChanged.AddListener((value) => { InnerCircleRadius           = value; });
        _sliderDrawPoint               .onValueChanged.AddListener((value) => { DrawPointRadius             = value; });
        _sliderOuterCircleRotationSpeed.onValueChanged.AddListener((value) => { OuterCircleRotationSpeed    = value; });
        _sliderGraphPointDistance      .onValueChanged.AddListener((value) => { GraphPointDistanceThreshold = value; });

    }   // OnEnable()

    private void OuterCircleValueChanged()
    {
        OuterCircleRadius = _sliderOuterCircle.value;
    }
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
		//_shouldDraw = false;
		OuterCircle.SetActive(true);

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


    #region .  SliderValueChanged()  .
    // -------------------------------------------------------------------------
    //  Method.......:  SliderValueChanged()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void SliderValueChanged(Slider slider, float value)
    {
        slider.value = value;

    }   //  SliderValueChanged()
    #endregion


    #region .  Start()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Start()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Start()
    {

        _lineRendererOuterCircle.gameObject.SetActive(false);

    }   // Start()
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
        if ((_isCurveClosed) || (_isMaxPointsReacheded))
        {
            return;
        }

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
