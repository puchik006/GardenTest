using UnityEngine;

//Probably it's better to set enemy on server 

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class scr_Enemy_Data : ScriptableObject
{
    [SerializeField] private string _name;
    //[SerializeField] private Sprite _picture;
    [SerializeField] private int _hp;
    [SerializeField] private float _speed;
    [SerializeField] private string _itemToDrop;

    public string Name => _name;
    //public Sprite Picture => _picture;
    public int HP => _hp;
    public float Speed => _speed;
    public string ItemToDrop => _itemToDrop;
}
