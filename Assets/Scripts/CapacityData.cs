using UnityEngine;

[CreateAssetMenu(fileName = "New Capacity Data", menuName = "Enemies/Capacity Data")]
public class CapacityData : ScriptableObject
{
    public GameObject enemyPrefab;
    public int capacityCost;
}