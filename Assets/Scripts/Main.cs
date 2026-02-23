using UnityEngine;


public class Main : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Public Variables:
    // -----------------
    //   //BackgroundPrefab
    //   SpirographPrefab
    // -------------------------------------------------------------------------

    #region .  Public Variables  .

    //public GameObject BackgroundPrefab;
    public GameObject SpirographPrefab;

    #endregion



    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Start()
    // -------------------------------------------------------------------------

    #region .  Start()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Start()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Start()
    {
        //Instantiate(BackgroundPrefab, Vector3.zero, Quaternion.identity);
        Instantiate(SpirographPrefab, Vector3.zero, Quaternion.identity);

    }	// Start()
    #endregion


}	// class Main
