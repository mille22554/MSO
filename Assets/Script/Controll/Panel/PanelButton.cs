using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour
{
    public Button btnHome;
    public Button btnPerson;
    public Button btnSkill;
    public Button btnBag;
    public Button btnForge;
    public Button btnShop;

    private void Awake()
    {
        btnHome.onClick.AddListener(OnPageSwitch);
        btnPerson.onClick.AddListener(OnPageSwitch);
        btnSkill.onClick.AddListener(OnPageSwitch);
        btnBag.onClick.AddListener(OnPageSwitch);
        btnForge.onClick.AddListener(OnPageSwitch);
        btnShop.onClick.AddListener(OnPageSwitch);
    }
    private void OnPageSwitch()
    {
        var target = EventSystem.current.currentSelectedGameObject.name.Replace("btn", "Panel");
        EventMng.EmitEvent(EventName.OnPageSwitch, target);
    }
}