using System.Collections.Generic;
using UnityEngine;

public class scr_General : MonoBehaviour
{
    public static scr_General m_General;

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

    [Header("Main settings")]
    [SerializeField] D_MainSettings _d_MainSettings;

    //GET
    //  Main
    public string GET_InventoryName { get => _d_MainSettings.str_InventoryName; }
}
