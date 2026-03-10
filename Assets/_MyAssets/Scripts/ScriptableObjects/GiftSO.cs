
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GiftSO", menuName = "Scriptable Objects/GiftSO")]
public class GiftSO : ScriptableObject
{
    public string giftName;

    public GameObject prefab;

    public List<AnimalSO> likedBy;
    public List<AnimalSO> dislikedBy;
}
