using UnityEngine;
using UnityEngine.UI;


public class SliderScript : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Public Variables:
    // -----------------
    //   ThisSlider
    // -------------------------------------------------------------------------

    #region .  Public Variables  .

    public Slider ThisSlider;

    #endregion



    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   OnSliderValueChanged()
    // -------------------------------------------------------------------------

    #region .  OnSliderValueChanged()  .
    //// -------------------------------------------------------------------------
    ////   Method.......:  OnSliderValueChanged()
    ////   Description..:  Invoked when the value of the slider changes.
    ////   Parameters...:  None
    ////   Returns......:  Nothing
    //// -------------------------------------------------------------------------
    //public void OnSliderValueChanged(float value)
    //{
    //    Debug.Log($"Slider Value:  {value}");

    //    _textValue.text = value.ToString("#0.00");

    //}   // OnSliderValueChanged()
    #endregion



    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   OnDisable()
    //   Start()
    //   Update()
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
        //GetComponent<Slider>().onValueChanged.RemoveListener(delegate { ThisSlider.GetComponent<SliderScript>().OnSliderValueChanged(this.GetComponent<Slider>().value); });
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
        // Adds a listener to the slider and invokes a method when the value changes.
        //GetComponent<Slider>().onValueChanged.AddListener(delegate { ThisSlider.GetComponent<SliderScript>().OnSliderValueChanged(this.GetComponent<Slider>().value); });

        //_textValue = GameObject.FindGameObjectWithTag("Value").GetComponent<TMP_Text>();

        Transform thatText  = ThisSlider.transform.Find("Label Value");
        Text      textValue = thatText.GetComponent<Text>();

        ThisSlider.onValueChanged.AddListener( (value) => { textValue.text = value.ToString("#0.00"); } );

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


}	// class Slider
