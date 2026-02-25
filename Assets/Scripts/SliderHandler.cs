using System;
using UnityEngine;
using UnityEngine.UI;


public class SliderHandler : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Public Static Events and Delegates:
    // -----------------------------------
    //   OnSliderValueChanged
    // -------------------------------------------------------------------------

    #region .  Public Events  .

    public static event Action<Single> OnSliderValueChanged = delegate { };

    #endregion



    // -------------------------------------------------------------------------
    // Public Variables:
    // -----------------
    //   FormatString
    // -------------------------------------------------------------------------

    #region .  Public Variables  .

    public string FormatString = "";

    #endregion



    // -------------------------------------------------------------------------
    // SerializeField Private Variables:
    // ---------------------------------
    //   _variable  --  COMMENTED OUT
    // -------------------------------------------------------------------------

    #region .  SerializeField Private Variables  .

    //[SerializeField] private float _variable = 0f;

    #endregion



    // -------------------------------------------------------------------------
    // Private Variables:
    // ------------------
    //   _slider
    //   _textValue
    // -------------------------------------------------------------------------

    #region .  Private Variables  .`

    private Slider _slider;
    private Text   _textValue;

    #endregion



    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   SliderChanged()
    // -------------------------------------------------------------------------

    #region .  SliderChanged()  .
    // -------------------------------------------------------------------------
    //   Method.......:  SliderChanged()
    //   Description..:  Assign to the OnValueChanged() event in the Inspector.
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void SliderChanged()
    {
        // Update the sliders' display text label Value property.
        _textValue.text = _slider.value.ToString(FormatString);

        // Fire the event to notify all listeners.
        OnSliderValueChanged?.Invoke(_slider.value);

    }   // SliderChanged()
    #endregion


    #region .  UpdateLabel()  .
    // -------------------------------------------------------------------------
    //  Method.......:  UpdateLabel()
    //  Description..:  
    //  Parameters...:  float:   the slider value.
    //                  string:  an optional format string, these are supported:
    //                           "%", "#0", "#00", "#0.0", "#0.00", etc.
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void UpdateLabel(float value, string formatString = "")
    {
        if (formatString.EndsWith("%"))
        {
            value *= 100;
        }

        _textValue.text = value.ToString(formatString);

    }	// UpdateLabel()
    #endregion



    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Start()
    //   Update()  --  COMMENTED OUT
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
        //_slider    = transform.GetComponent<Slider>();
        //_textValue = transform.GetComponentInChildren<Text>();

        _slider = GetComponent<Slider>();
        if (_slider != null)
        {
            _slider.onValueChanged.AddListener((value) => { UpdateLabel(value, FormatString); });

            _textValue = _slider.GetComponentInChildren<Text>();
            if (_textValue != null)
            {
                UpdateLabel(_slider.value, FormatString);
            }
        }

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
    //}
    //// Update()
    #endregion


}	// class SliderHandler
