using UnityEngine;


public class GameManager : MonoBehaviour
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
        GameObject spirograph        = Instantiate(SpirographPrefab);
        float      outerCircleRadius = Spirograph.Instance.OuterCircleRadius;
        float      coordinateX       = (Screen.width / 2f) - outerCircleRadius - 10f;

        spirograph.transform.SetPositionAndRotation(new Vector3(coordinateX, 0f, 0f), Quaternion.identity);

    }	// Start()
    #endregion


}	// class GameManager
