using UnityEngine;
[System.Serializable]

public abstract class Item : MonoBehaviour
{
    public GameObject Prefab;
    public string ID,Name,Description;
    public float Weight;
    public int Worth;
}