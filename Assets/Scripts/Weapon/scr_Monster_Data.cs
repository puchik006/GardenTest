using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monster")]
public class scr_Monster_Data : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _picture;


    public string Name => _name;

}
