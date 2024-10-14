using UnityEngine;

public class PageMain : MonoBehaviour
{
    private void Start()
    {
        ObjectPool.Get(PrefabMng.GetData("PanelInfo").GetComponent<PanelInfo>(), gameObject.transform).SetInfo();
    }
}