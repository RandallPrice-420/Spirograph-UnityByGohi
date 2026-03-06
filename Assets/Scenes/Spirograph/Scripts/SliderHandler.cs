using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SliderHandler : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Public Static Events and Delegates:
    // -----------------------------------
    //   OnValueChanged
    // -------------------------------------------------------------------------

    #region .  Public Events  .

    public static event Action OnValueChanged = delegate { };

    #endregion



    // -------------------------------------------------------------------------
    // Public Variables:
    // -----------------
    //   SliderControl
    // -------------------------------------------------------------------------

    #region .  Public Variables  .

    public Slider SliderControl;

    #endregion



    // -------------------------------------------------------------------------
    // Private Variables:
    // ------------------
    //   _textFormat
    //   _textValue
    // -------------------------------------------------------------------------

    #region .  Private Variables  .

    private TMP_Text _textFormat;
    private TMP_Text _textValue;

    #endregion



    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   OnSliderValueChanged()
    // -------------------------------------------------------------------------

    #region .  OnSliderValueChanged()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnSliderValueChanged()
    //   Description..:  Update the sliders' Value label text.
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnSliderValueChanged()
    {
        if (_textFormat.text.EndsWith("%"))
        {
            SliderControl.value *= 100;
        }

        _textValue.text = SliderControl.value.ToString(_textFormat.text);

    }   // OnSliderValueChanged()
    #endregion



    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Awake()
    //   OnDisable()
    //   OnEnable()
    //   CheckForComponent()
    //   Start()
    // -------------------------------------------------------------------------

    #region .  Awake()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Awake()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Awake()
    {
        if (CheckForComponent(SliderControl.gameObject, SliderControl.name)) return;

        _textValue  = SliderControl.GetComponentsInChildren<TMP_Text>()[1];
        _textFormat = SliderControl.GetComponentsInChildren<TMP_Text>()[2];

        if (CheckForComponent(_textValue.gameObject,  $"_textValue.name:  {_textValue.name}"))   return;
        if (CheckForComponent(_textFormat.gameObject, $"_textFormat.name:  {_textFormat.name}")) return;

    }   // Awake()
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
        OnValueChanged -= OnSliderValueChanged;

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
        OnValueChanged += OnSliderValueChanged;

    }   // OnEnable()
    #endregion


    #region .  CheckForComponent()  .
    // -------------------------------------------------------------------------
    //   Method.......:  CheckForComponent()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private bool CheckForComponent(GameObject component, string name)
    {
        bool isNull = (component == null);

        if (isNull)
        {
            Debug.Log($"Component: {component},  is null - make sure to assign it to the Slider Handler script in the Inspector.");
        }

        return isNull;

    }   // CheckForComponent()
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
        OnSliderValueChanged();
    
    }   // Start()
    #endregion


}	// class SliderHandler
