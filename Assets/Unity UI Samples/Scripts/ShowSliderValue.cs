using UnityEngine;
using UnityEngine.UI;


// -----------------------------------------------------------------------------
//  Class........:  ShowSliderValue
//
//  Description..:  Attach this to the Slider object.
// -----------------------------------------------------------------------------

[RequireComponent(typeof(Text))]
public class ShowSliderValue : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Private Serialize Variables:
    // ----------------------------
    //   _labelValue
    // -------------------------------------------------------------------------

    #region .  Private Serialize Variables  .

    [SerializeField] private Text _labelValue;

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
    public void UpdateLabel(float value, string format = "")
	{
		if (this.TryGetComponent<Text>(out var labelValue))
		{
            labelValue.text = format switch
            {
                "%" => Mathf.RoundToInt(value * 100) + "%",
                 _  => value.ToString(format),
            };
        }

    }	// UpdateLabel()
    #endregion


}	// class ShowSliderValue
