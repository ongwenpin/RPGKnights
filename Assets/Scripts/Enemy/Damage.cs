using UnityEngine;

public class Damage : MonoBehaviour
{
    public enum Dmg
    {
        magic, physical, trueDmg,
    }

    public Dmg damageType;
}
