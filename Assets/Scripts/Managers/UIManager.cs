using UnityEngine;
using UnityEngine.UI;


public class UIManager : Singleton<UIManager>
{
    // -------------------------------------------------------------------------
    // Public Variables:
    // -----------------
    //   Button_Pause
    //   Button_Random
    //   Button_Reset
    //   Button_Resume
    //   Button_Start
    //   Button_Stop
    //   IsStarted
    //   Slider_OuterCircle
    //   Slider_InnerCircle
    //   Slider_DrawPoint
    //   Slider_OuterCircleRotationSpeed
    //   Slider_GraphPointDistance
    // -------------------------------------------------------------------------

    #region .  Public Variables  .

    public Button Button_Pause;
    public Button Button_Random;
    public Button Button_Resume;
    public Button Button_Reset;
    public Button Button_Start;
    public Button Button_Stop;

    public bool   IsStarted = false;

    public Slider Slider_OuterCircle;
    public Slider Slider_InnerCircle;
    public Slider Slider_DrawPoint;
    public Slider Slider_OuterCircleRotationSpeed;
    public Slider Slider_GraphPointDistance;

    #endregion



    // -------------------------------------------------------------------------
    // Private Variables:
    // ------------------
    //   _textOuterCircleValue
    //   _textInnerCircleValue
    //   _textDrawPointValue
    //   _textOuterCircleRotstionSpeed
    //   _textGraphPointDistance
    // -------------------------------------------------------------------------

    #region .  Private Variables  .

    private Text _textOuterCircleValue;
    private Text _textInnerCircleValue;
    private Text _textDrawPointValue;
    private Text _textOuterCircleRotstionSpeed;
    private Text _textGraphPointDistance;

    #endregion



    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   OnButtonPauseClicked()
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
        Time.timeScale = 0f;

        SetButton(Button_Start,  true,  false);
        SetButton(Button_Pause,  false, false);
        SetButton(Button_Resume, true,  true );
        SetButton(Button_Stop,   true,  true );
        SetButton(Button_Random, true,  false);

    }   // OnButtonPauseClicked()
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
        IsStarted = false;

        SetButton(Button_Start,  true,  true );
        SetButton(Button_Pause,  true,  false);
        SetButton(Button_Resume, false, false);
        SetButton(Button_Stop,   true,  false);
        SetButton(Button_Random, true,  true );

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
        Time.timeScale = 1f;

        SetButton(Button_Start,  true,  false);
        SetButton(Button_Pause,  true,  true );
        SetButton(Button_Resume, false, false);
        SetButton(Button_Stop,   true,  true );
        SetButton(Button_Random, true,  false);

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
        IsStarted = true;

        SetButton(Button_Start,  true,  false);
        SetButton(Button_Pause,  true,  true );
        SetButton(Button_Reset,  true,  true );
        SetButton(Button_Resume, false, false);
        SetButton(Button_Stop,   true,  false);

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
        IsStarted = false;

        SetButton(Button_Start,  true,  true );
        SetButton(Button_Pause,  true,  false);
        SetButton(Button_Reset,  true,  true );
        SetButton(Button_Resume, false, false);
        SetButton(Button_Stop,   true,  false);
        SetButton(Button_Random, true,  true );

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



    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Configure()
    //   SetButton()
    //   Start()
    //   Update()  --  COMMENTED OUT
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
        Slider_OuterCircle             .value = Spirograph.Instance.OuterCircleRadius;
        Slider_InnerCircle             .value = Spirograph.Instance.InnerCircleRadius;
        Slider_DrawPoint               .value = Spirograph.Instance.DrawPointRadius;
        Slider_OuterCircleRotationSpeed.value = Spirograph.Instance.OuterCircleRotationSpeed;
        Slider_GraphPointDistance      .value = Spirograph.Instance.GraphPointDistanceThreshold;

        _textOuterCircleValue                 = Slider_OuterCircle             .GetComponentInChildren<Text>();
        _textInnerCircleValue                 = Slider_InnerCircle             .GetComponentInChildren<Text>();
        _textDrawPointValue                   = Slider_DrawPoint               .GetComponentInChildren<Text>();
        _textOuterCircleRotstionSpeed         = Slider_OuterCircleRotationSpeed.GetComponentInChildren<Text>();
        _textGraphPointDistance               = Slider_GraphPointDistance      .GetComponentInChildren<Text>();

        _textOuterCircleValue        .text    = Slider_OuterCircle             .value.ToString();
        _textInnerCircleValue        .text    = Slider_InnerCircle             .value.ToString();
        _textDrawPointValue          .text    = Slider_DrawPoint               .value.ToString();
        _textOuterCircleRotstionSpeed.text    = Slider_OuterCircleRotationSpeed.value.ToString();
        _textGraphPointDistance      .text    = Slider_GraphPointDistance      .value.ToString();

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

        Text text  = button.GetComponentInChildren<Text>();
        text.color = (interactable) ? Color.white : Color.gray;

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
        IsStarted = false;

        Configure();

    }   // Start()
    #endregion


    #region .  Update()  --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////   Method.......:  Update()
    ////   Description..:  
    ////   Parameters...:  None
    ////   Returns......:  Nothing
    //// -------------------------------------------------------------------------
    //private void Update()
    //{
    //}   // Update()
    #endregion


}	// class UIManager
