using UnityEngine;
using UnityEngine.UI;


public class UIManager : Singleton<UIManager>
{
    // -------------------------------------------------------------------------
    // Public Static Events and Delegates:
    // -----------------------------------
    //   OnBrickCountChanged
    // -------------------------------------------------------------------------

    #region .  Public Events  .

    //public static event Action<int> OnBrickCountChanged = delegate { };

    #endregion



    // -------------------------------------------------------------------------
    // Public Variables:
    // -----------------
    //   Button_Pause
    //   Button_Reset
    //   Button_Resume
    //   Button_Start
    //   Button_Stop
    //   SliderOuterCircle
    //   SliderInnerCircle
    //   SliderDrawPoint
    //   IsStarted
    // -------------------------------------------------------------------------

    #region .  Public Variables  .

    public Button Button_Pause;
    public Button Button_Resume;
    public Button Button_Reset;
    public Button Button_Start;
    public Button Button_Stop;

    public Slider Slider_OuterCircle;
    public Slider Slider_InnerCircle;
    public Slider Slider_DrawPoint;
    public Slider Slider_OuterCircleRotationSpeed;

    public bool   IsStarted = false;

    #endregion



    // -------------------------------------------------------------------------
    // SerializeField Private Variables:
    // ---------------------------------
    //   _variable
    // -------------------------------------------------------------------------

    #region .  SerializeField Private Variables  .

    //[SerializeField] private float _variable = 0f;

    #endregion



    // -------------------------------------------------------------------------
    // Private Variables:
    // ------------------
    //   _variable
    // -------------------------------------------------------------------------

    #region .  Private Variables  .

    //private float _variable;

    private Text _textOuterCircleValue;
    private Text _textInnerCircleValue;
    private Text _textDrawPointValue;
    private Text _textOuterCircleRotstionSpeed;

    #endregion



    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   OnPauseButtonClicked()
    //   OnResetButtonClicked()
    //   OnResumeButtonClicked()
    //   OnStartButtonClicked()
    //   OnStopButtonClicked()
    // -------------------------------------------------------------------------

    #region .  OnPauseButtonClicked()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnPauseButtonClicked()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnPauseButtonClicked()
    {
        Time.timeScale = 0f;

        SetButton(Button_Start,  true,  false);
        SetButton(Button_Pause,  false, false);
        SetButton(Button_Resume, true,  true);
        SetButton(Button_Stop,   true,  true);

    }   // OnPauseButtonClicked()
    #endregion


    #region .  OnResumeButtonClicked()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnResumeButtonClicked()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnResumeButtonClicked()
    {
        Time.timeScale = 1f;

        SetButton(Button_Start,  true,  false);
        SetButton(Button_Pause,  true,  true);
        SetButton(Button_Resume, false, false);
        SetButton(Button_Stop,   true,  true);

    }   // OnResumeButtonClicked()
    #endregion


    #region .  OnResetButtonClicked()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnResetButtonClicked()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnResetButtonClicked()
    {
        IsStarted = false;

        SetButton(Button_Start,  true,  true);
        SetButton(Button_Pause,  true,  false);
        SetButton(Button_Resume, false, false);
        SetButton(Button_Stop,   true,  false);

    }   // OnResetButtonClicked()
    #endregion


    #region .  OnStartButtonClicked()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnStartButtonClicked()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnStartButtonClicked()
    {
        IsStarted = true;

        SetButton(Button_Start,  true,  false);
        SetButton(Button_Pause,  true,  true);
        SetButton(Button_Reset,  true,  true);
        SetButton(Button_Resume, false, false);
        SetButton(Button_Stop,   true,  true);

    }   // OnStartButtonClicked()
    #endregion


    #region .  OnStopButtonClicked()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnStopButtonClicked()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnStopButtonClicked()
    {
        IsStarted = false;

        SetButton(Button_Start,  true,  true);
        SetButton(Button_Pause,  true,  false);
        SetButton(Button_Reset,  true,  true);
        SetButton(Button_Resume, false, false);
        SetButton(Button_Stop,   true,  false);

    }   // OnStopButtonClicked()
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



    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   SetButton()
    //   Start()
    //   Update()
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

        _textOuterCircleValue                 = Slider_OuterCircle             .GetComponentInChildren<Text>();
        _textInnerCircleValue                 = Slider_InnerCircle             .GetComponentInChildren<Text>();
        _textDrawPointValue                   = Slider_DrawPoint               .GetComponentInChildren<Text>();
        _textOuterCircleRotstionSpeed         = Slider_OuterCircleRotationSpeed.GetComponentInChildren<Text>();

        _textOuterCircleValue        .text    = Slider_OuterCircle             .value.ToString();
        _textInnerCircleValue        .text    = Slider_InnerCircle             .value.ToString();
        _textDrawPointValue          .text    = Slider_DrawPoint               .value.ToString();
        _textOuterCircleRotstionSpeed.text    = Slider_OuterCircleRotationSpeed.value.ToString();

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

        //Configure();

    }   // Start()
    #endregion


    #region .  Update()  .
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
