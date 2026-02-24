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
    //   IsStarted
    // -------------------------------------------------------------------------

    #region .  Public Variables  .

    public Button Button_Pause;
    public Button Button_Resume;
    public Button Button_Reset;
    public Button Button_Start;
    public Button Button_Stop;

    public bool   IsStarted = false;

    #endregion



    // -------------------------------------------------------------------------
    // SerializeField Private Variables:
    // ---------------------------------
    //   _variable
    // -------------------------------------------------------------------------

    #region .  Private Variables  .

    //[SerializeField] private float _variable = 0f;

    #endregion



    // -------------------------------------------------------------------------
    // Private Variables:
    // ------------------
    //   _variable
    // -------------------------------------------------------------------------

    #region .  Private Variables  .

    //private float _variable;

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

        Button_Start .interactable   = false;

        Button_Pause .gameObject.SetActive(false);
        Button_Pause .interactable   = false;

        Button_Resume.gameObject.SetActive(true);
        Button_Resume.interactable   = true;

        Button_Stop  .interactable   = true;

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

        Button_Start.interactable = false;

        Button_Pause .gameObject.SetActive(true);
        Button_Pause .interactable = true;

        Button_Resume.gameObject.SetActive(false);
        Button_Resume.interactable = false;

        Button_Stop  .interactable = true;

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

        Button_Start .interactable = true;

        Button_Pause .gameObject.SetActive(false);
        Button_Pause .interactable = false;

        Button_Resume.gameObject.SetActive(false);
        Button_Resume.interactable = false;

        Button_Stop  .interactable = false;

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

        Button_Start .interactable = false;

        Button_Pause .gameObject.SetActive(true);
        Button_Pause .interactable = true;

        Button_Reset .interactable = true;

        Button_Resume.gameObject.SetActive(false);
        Button_Resume.interactable = false;

        Button_Stop  .interactable = true;

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

        Button_Start .interactable = true;

        Button_Pause .gameObject.SetActive(true);
        Button_Pause .interactable = false;

        Button_Reset .interactable = false;

        Button_Resume.gameObject.SetActive(false);
        Button_Resume.interactable = false;

        Button_Stop  .interactable = false;

    }   // OnStopButtonClicked()
    #endregion



    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Start()
    //   Update()
    // -------------------------------------------------------------------------

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
    //}   // Awake()
    #endregion


}	// class UIManager
