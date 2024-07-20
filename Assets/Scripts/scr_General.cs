using UnityEngine;

public class scr_General : MonoBehaviour
{
    public static scr_General m_General;

    [Header("Main settings")]
    [SerializeField] D_MainSettings _d_MainSettings;

    void Awake()
    {
        if (m_General == null)
        {
            m_General = this;
        }
    }

    void Update()
    {
        if (m_General == null)
        {
            m_General = this;
        }
    }


    //GET
    //  Main
    public string GET_InventoryName { get => _d_MainSettings.str_InventoryName; }

    //SET

}
