using UnityEngine;

[CreateAssetMenu(fileName = "AnimalSO", menuName = "Scriptable Objects/AnimalSO")]
public class AnimalSO : ScriptableObject
{
    public string AnimalName;

    public GameObject prefab;

    public GiftSO GiftsWhenHappy;

}
