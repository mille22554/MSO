using UnityEngine;

public class PageMain : MonoBehaviour
{
    private void Start()
    {
        ObjectPool.Get(PrefabMng.GetData("PanelHome").GetComponent<PanelHome>(), gameObject.transform);
        ObjectPool.Get(PrefabMng.GetData("PanelPerson").GetComponent<PanelPerson>(), gameObject.transform).gameObject.SetActive(false);

        var panelBag = ObjectPool.Get(PrefabMng.GetData("PanelBag").GetComponent<PanelBag>(), gameObject.transform);
        panelBag.SetInfo();
        panelBag.gameObject.SetActive(false);

        ObjectPool.Get(PrefabMng.GetData("PanelInfo").GetComponent<PanelInfo>(), gameObject.transform).SetInfo();
    }
}