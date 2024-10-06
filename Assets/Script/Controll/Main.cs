using UnityEngine;

public class Main : MonoBehaviour
{
    void Start()
    {
        Instantiate((GameObject)PrefabMng.GetData("PanelLogin"), gameObject.transform);
    }
}