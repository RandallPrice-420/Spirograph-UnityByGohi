using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : Singleton<UIManager>
{
    // -------------------------------------------------------------------------
    // Public Variables:
    // -----------------
    //   Button_Start
    //   Button_Pause
    //   Button_Resume
    //   Button_Stop
    //   Button_Random
    //   Button_Reset
    //   Button_Quit
    //
    //   Slider_OuterCircle
    //   Slider_InnerCircle
    //   Slider_DrawPoint
    //   Slider_OuterCircleRotationSpeed
    //   Slider_GraphPointDistance
    //   Slider_MaximiumGraphPoints
    //
    //   IsStarted
    // -------------------------------------------------------------------------

    #region .  Public Variables  .

    [Space, Header("Button Controls")]
    public Button   Button_Start;
    public Button   Button_Pause;
    public Button   Button_Resume;
    public Button   Button_Stop;
    public Button   Button_Random;
    public Button   Button_Reset;
    public Button   Button_Quit;

    [Space, Header("Slider Controls")]
    public Slider   Slider_OuterCircle;
    public Slider   Slider_InnerCircle;
    public Slider   Slider_DrawPoint;
    public Slider   Slider_OuterCircleRotationSpeed;
    public Slider   Slider_GraphPointDistance;
    public Slider   Slider_MaximumGraphPoints;

    [Space, Header("Information Controls")]
    public TMP_Text TMP_MaximumGraphPointsValue;
    public TMP_Text TMP_GraphPointCountValue;

    public bool   IsStarted            = false;
    public bool   IsMaxPointsReacheded = false;

    #endregion



    // -------------------------------------------------------------------------
    // Private Variables:
    // ------------------
    //   _tmp_OuterCircleValue
    //   _tmp_InnerCircleValue
    //   _tmp_DrawPointValue
    //   _tmp_OuterCircleRotstionSpeed
    //   _tmp_GraphPointDistance
    // -------------------------------------------------------------------------

    #region .  Private Variables  .

    private TMP_Text _tmp_OuterCircleValue;
    private TMP_Text _tmp_InnerCircleValue;
    private TMP_Text _tmp_DrawPointValue;
    private TMP_Text _tmp_OuterCircleRotstionSpeed;
    private TMP_Text _tmp_GraphPointDistance;

    #endregion



    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   OnButtonPauseClicked()
    //   OnButtonQuitClicked()
    //   OnButtonRandomClicked()
    //   OnButtonResetClicked()
    //   OnButtonResumeClicked()
    //   OnButtonStartClicked()
    //   OnButtonStopClicked()
    //   OnSliderOuterCircleChanged()
    //   OnSliderInnerCircleChanged()
    //   OnSliderDrawPointChanged()
    //   OnSliderOuterCircleRotationSpeedChanged()
    //   OnSliderGraphPointDistanceChanged()
    //   OnSliderMaximumGraphPointsChanged()
    // -------------------------------------------------------------------------

    #region .  OnButtonPauseClicked()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnButtonPauseClicked()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnButtonPauseClicked()
    {
        SetButton(Button_Start,  true,  false);
        SetButton(Button_Pause,  false, false);
        SetButton(Button_Resume, true,  true );
        SetButton(Button_Stop,   true,  true );
        SetButton(Button_Random, true,  false);
        SetButton(Button_Reset,  true,  false);
        SetButton(Button_Quit,   true,  false);

        IsStarted      = false;
        Time.timeScale = 0f;

    }   // OnButtonPauseClicked()
    #endregion


    #region .  OnButtonQuitClicked()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnButtonQuitClicked()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnButtonQuitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }   // OnButtonQuitClicked()
    #endregion


    #region .  OnButtonRandomClicked()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnButtonRandomClicked()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnButtonRandomClicked()
    {
        SetButton(Button_Start,  true,  true );
        SetButton(Button_Pause,  true,  false);
        SetButton(Button_Resume, false, false);
        SetButton(Button_Stop,   true,  false);
        SetButton(Button_Random, true,  true );
        SetButton(Button_Reset,  true,  true );
        SetButton(Button_Quit,   true,  true );

        SetRandomValues();

    }   // OnButtonRandomClicked()
    #endregion


    #region .  OnButtonResetClicked()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnButtonResetClicked()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnButtonResetClicked()
    {
        SetButton(Button_Start,  true,  true );
        SetButton(Button_Pause,  true,  false);
        SetButton(Button_Resume, false, false);
        SetButton(Button_Stop,   true,  false);
        SetButton(Button_Random, true,  true );
        SetButton(Button_Reset,  true,  false);
        SetButton(Button_Quit,   true,  true );

        IsStarted = false;

        Spirograph.Instance.ClearGraph();


    }   // OnButtonResetClicked()
    #endregion


    #region .  OnButtonResumeClicked()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnButtonResumeClicked()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnButtonResumeClicked()
    {
        SetButton(Button_Start,  true,  false);
        SetButton(Button_Pause,  true,  true );
        SetButton(Button_Resume, false, false);
        SetButton(Button_Stop,   true,  true );
        SetButton(Button_Random, true,  false);
        SetButton(Button_Reset,  true,  false);
        SetButton(Button_Quit,   true,  false);

        IsStarted      = true;
        Time.timeScale = 1f;

    }   // OnButtonResumeClicked()
    #endregion


    #region .  OnButtonStartClicked()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnButtonStartClicked()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnButtonStartClicked()
    {
        SetButton(Button_Start,  true,  false);
        SetButton(Button_Pause,  true,  true );
        SetButton(Button_Resume, false, false);
        SetButton(Button_Stop,   true,  true );
        SetButton(Button_Random, true,  false);
        SetButton(Button_Reset,  true,  false);
        SetButton(Button_Quit,   true,  false);

        IsStarted = true;

    }   // OnButtonStartClicked()
    #endregion


    #region .  OnButtonStopClicked()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnButtonStopClicked()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnButtonStopClicked()
    {
        SetButton(Button_Start,  true,  false);
        SetButton(Button_Pause,  true,  false);
        SetButton(Button_Resume, false, false);
        SetButton(Button_Stop,   true,  false);
        SetButton(Button_Random, true,  false);
        SetButton(Button_Reset,  true,  true );
        SetButton(Button_Quit,   true,  true );

        IsStarted = false;

    }   // OnButtonStopClicked()
    #endregion


    #region .  OnSliderOuterCircleChanged()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnSliderOuterCircleChanged()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnSliderOuterCircleChanged()
    {
        Spirograph.Instance.OuterCircleRadius = Slider_OuterCircle.value;

    }   // OnSliderOuterCircleChanged()
    #endregion


    #region .  OnSliderInnerCircleChanged()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnSliderInnerCircleChanged()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnSliderInnerCircleChanged()
    {
        Spirograph.Instance.InnerCircleRadius = Slider_InnerCircle.value;

    }   // OnSliderInnerCircleChanged()
    #endregion


    #region .  OnSliderDrawPointChanged()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnSliderDrawPointChanged()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnSliderDrawPointChanged()
    {
        Spirograph.Instance.DrawPointRadius = Slider_DrawPoint.value;

    }   // OnSliderDrawPointChanged()
    #endregion


    #region .  OnSliderOuterCircleRotationSpeedChanged()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnSliderOuterCircleRotationSpeedChanged()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnSliderOuterCircleRotationSpeedChanged()
    {
        Spirograph.Instance.OuterCircleRotationSpeed = Slider_OuterCircleRotationSpeed.value;

    }   // OnSliderOuterCircleRotationSpeedChanged()
    #endregion


    #region .  OnSliderGraphPointDistanceChanged()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnSliderGraphPointDistanceChanged()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnSliderGraphPointDistanceChanged()
    {
        Spirograph.Instance.GraphPointDistanceThreshold = Slider_GraphPointDistance.value;

    }   // OnSliderGraphPointDistanceChanged()
    #endregion


    #region .  OnSliderMaximumGraphPointsChanged()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnSliderMaximumGraphPointsChanged()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnSliderMaximumGraphPointsChanged()
    {
        Spirograph.Instance.MaximumGraphPoints = (int)Slider_MaximumGraphPoints.value;

    }   // OnSliderGraphPointDistanceChanged()
    #endregion



    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Configure()
    //   SetButton()
    //   SetRandomValues()
    //   Start()
    // -------------------------------------------------------------------------

    #region .  Configure()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Configure()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Configure()
    {
        IsStarted = false;

        OnButtonResetClicked();
        
        Spirograph.Instance.ClearGraph();

        Slider_OuterCircle             .value = Spirograph.Instance.OuterCircleRadius;
        Slider_InnerCircle             .value = Spirograph.Instance.InnerCircleRadius;
        Slider_DrawPoint               .value = Spirograph.Instance.DrawPointRadius;
        Slider_OuterCircleRotationSpeed.value = Spirograph.Instance.OuterCircleRotationSpeed;
        Slider_GraphPointDistance      .value = Spirograph.Instance.GraphPointDistanceThreshold;
        Slider_MaximumGraphPoints      .value = Spirograph.Instance.MaximumGraphPoints;

        _tmp_OuterCircleValue                 = Slider_OuterCircle             .GetComponentsInChildren<TMP_Text>()[1];
        _tmp_InnerCircleValue                 = Slider_InnerCircle             .GetComponentsInChildren<TMP_Text>()[1];
        _tmp_DrawPointValue                   = Slider_DrawPoint               .GetComponentsInChildren<TMP_Text>()[1];
        _tmp_OuterCircleRotstionSpeed         = Slider_OuterCircleRotationSpeed.GetComponentsInChildren<TMP_Text>()[1];
        _tmp_GraphPointDistance               = Slider_GraphPointDistance      .GetComponentsInChildren<TMP_Text>()[1];

        _tmp_OuterCircleValue        .text    = Slider_OuterCircle             .value.ToString();
        _tmp_InnerCircleValue        .text    = Slider_InnerCircle             .value.ToString();
        _tmp_DrawPointValue          .text    = Slider_DrawPoint               .value.ToString();
        _tmp_OuterCircleRotstionSpeed.text    = Slider_OuterCircleRotationSpeed.value.ToString();
        _tmp_GraphPointDistance      .text    = Slider_GraphPointDistance      .value.ToString();

        TMP_MaximumGraphPointsValue  .text    = Slider_MaximumGraphPoints      .value.ToString();

    }   // Configure()
    #endregion


    #region .  SetButton()  .
    // -------------------------------------------------------------------------
    //   Method.......:  SetButton()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void SetButton(Button button, bool active, bool interactable)
    {
        button.interactable = interactable;
        button.gameObject.SetActive(active);

        //TMP_Text text  = button.GetComponentInChildren<TMP_Text>();
        //text.color = (interactable) ? Color.white : Color.gray;

        button.GetComponentInChildren<TMP_Text>().color = (interactable) ? Color.white : Color.gray;

    }   // SetButton()
    #endregion


    #region .  SetRandomValues()  .
    // -------------------------------------------------------------------------
    //   Method.......:  SetRandomValues()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void SetRandomValues()
    {
        Slider_OuterCircle.value = Random.Range(Slider_OuterCircle.minValue, Slider_OuterCircle.maxValue);
        Slider_InnerCircle.value = Random.Range(Slider_InnerCircle.minValue, Slider_InnerCircle.maxValue);
        Slider_DrawPoint  .value = Random.Range(Slider_DrawPoint  .minValue, Slider_DrawPoint  .maxValue);

    }   // SetRandomValues()
    #endregion


    #region .  Start()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Start()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Start()
    {
        Configure();

    }   // Start()
    #endregion


}	// class UIManager
