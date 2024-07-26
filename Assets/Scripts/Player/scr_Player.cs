using UnityEngine;

public class scr_Player: MonoBehaviour
{
    [SerializeField] private D_Player _d_player;
    [SerializeField] private scr_UI_HealthBar _healthBar;
    private scr_FileManager_JSONHandler _jsonHandler;
    private string _dataFileName = "Player.json";
    private int _HP;
    private float _fullHP;
    private int _bodyCount;

    void Awake()
    {
        _jsonHandler = new scr_FileManager_JSONHandler();

        V_CheckPlayerData();

        scr_EventBus.Instance.EnemyDestroyed += V_OnEnemyDestroyed;

        _HP = _d_player.Health;
        _fullHP = _HP;
        _bodyCount = _d_player.BodyCount;
    }

    public void V_TakeDamage(int damage)
    {
        _HP -= damage;

        _healthBar.V_ChangeHealthBalue(damage / _fullHP);

        Debug.Log("Player accept " + damage + " damage, health now " + _HP);

        if (_HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void V_SaveInitialPlayerData()
    {
        var playerData  = new D_Player()
        {
            Name = "Player",
            Level = 1,
            Health = 100,
            BodyCount = 0
        };

        _jsonHandler.V_SaveDataToJSONFile(_dataFileName, playerData);
    }

    public void V_SavePlayerData()
    {
        _jsonHandler.V_SaveDataToJSONFile(_dataFileName,_d_player);
    }

    private void V_CheckPlayerData()
    {
        if (_jsonHandler.Is_JSON_Exist(_dataFileName))
        {
            _d_player = _jsonHandler.V_ReadDataFromJSONFile<D_Player>(_dataFileName);
        }
        else
        {
            V_SaveInitialPlayerData();
            _d_player = _jsonHandler.V_ReadDataFromJSONFile<D_Player>(_dataFileName);
        }
    }

    private void V_OnEnemyDestroyed()
    {
        _d_player.BodyCount++;
        V_SavePlayerData();
    }

    void OnDestroy()
    {
        scr_EventBus.Instance.EnemyDestroyed -= V_OnEnemyDestroyed;
    }
}
