using UnityEngine;

public class scr_Bootstrap: MonoBehaviour
{
    [SerializeField] private scr_UI_Handler _ui_Handler;
    [SerializeField] private scr_UI_Inventory _ui_Inventory;
    [SerializeField] private scr_Enemy_EnemyFactory _enemyFactory;
    private scr_Inventory _inventory;

    void Awake()
    {
        _ui_Handler.V_Initialise();

        _inventory = new scr_Inventory();
        _ui_Inventory.V_Initialise(_inventory);
  
        _enemyFactory.V_InstaniateEnemies();
    }
}




