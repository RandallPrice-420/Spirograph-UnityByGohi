using UnityEngine;
using UnityEngine.UI;


// -----------------------------------------------------------------------------
//  Class........:  ShowSliderValue
//
//  Description..:  Attach this to the Slider object.
// -----------------------------------------------------------------------------

public class ShowSliderValue : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Public Variables:
    // -----------------
    //   ThisSlider
    //   FormatString
    // -------------------------------------------------------------------------

    #region .  Public Variables  .

    public Slider ThisSlider;
    public string FormatString = "";

    #endregion



    // -------------------------------------------------------------------------
    // Private Variables:
    // ------------------
    //   _textValue
    // -------------------------------------------------------------------------

    #region .  Private Variables  .

    private Text _textValue;

    #endregion



    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   UpdateLabel()
    // -------------------------------------------------------------------------

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
    //   OnDisable()
    //   Start()
    // -------------------------------------------------------------------------

    #region .  OnDisable()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnDisable()
    //   Description..:  Remove the slistener for the Slider.
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnDisable()
    {
        GetComponent<Slider>().onValueChanged.RemoveAllListeners();

    }   // OnDisable()
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
        _textValue = transform.GetComponentInChildren<Text>();

        ThisSlider.onValueChanged.AddListener( (value) => { UpdateLabel(value,  FormatString); } );

        UpdateLabel(ThisSlider.value, FormatString);

    }   // Start()
    #endregion


}	// class ShowSliderValue
