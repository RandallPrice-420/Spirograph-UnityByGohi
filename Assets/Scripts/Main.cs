using UnityEngine;


public class Main : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Public Variables:
    // -----------------
    //   SpirographPrefab
    // -------------------------------------------------------------------------

    #region .  Public Variables  .

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
        Instantiate(SpirographPrefab);
        //Instantiate(SpirographPrefab, Vector3.zero, Quaternion.identity);

    }	// Start()
    #endregion


}	// class Main
