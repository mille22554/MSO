using TMPro;
using UnityEngine;
using UnityEngine.UI;

using Cysharp.Threading.Tasks;

public class PanelLogin : MonoBehaviour
{
    public TMP_InputField account;
    public TextMeshProUGUI accountTitle;
    public TextMeshProUGUI hint;
    public TextMeshProUGUI testLogin;
    public Button btnLogin;

    private void Awake()
    {
        btnLogin.onClick.AddListener(OnLogin);
    }
    private void OnLogin()
    {
        if (account.text == "")
        {
            hint.text = "帳號不能空白!";
            return;
        }

        hint.text = "";

        CheckSave(SaveMng.LoadGame(account.text + GameData.version[0]), 0);
        if (GameData.save.playerData == null)
        {
            GameData.save.playerData = new PlayerData(account.text);
            SaveMng.SaveGame(GameData.save.playerData.account + GameData.version[0], GameData.save);
        }
        if (GameData.save.playerData.name == null)
        {
            btnLogin.onClick.RemoveListener(OnLogin);
            SetAccountText("");
            accountTitle.text = "名稱";
            testLogin.text = "確定";
            btnLogin.onClick.AddListener(OnSetName);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    private async void SetAccountText(string str)
    {
        await UniTask.NextFrame();
        account.text = str;
    }
    private void OnSetName()
    {
        if (string.IsNullOrEmpty(account.text)) hint.text = "名稱不能空白!";
        else
        {
            GameData.save.playerData.name = account.text;
            SaveMng.SaveGame(GameData.save.playerData.account + GameData.version[0], GameData.save);
            gameObject.SetActive(false);
        }
    }
    private void CheckSave(SaveData save, int ver)
    {
        if (save == null)
        {
            ver++;
            if (ver >= GameData.version.Length) SaveMng.SaveGame(account.text + GameData.version[0], new SaveData());
            else CheckSave(SaveMng.LoadGame(account.text + GameData.version[ver]), ver);
        }
        else GameData.save = save;
    }
    private void OnDisable()
    {
        btnLogin.onClick.RemoveAllListeners();
    }
    private void OnEnable()
    {
        btnLogin.onClick.AddListener(OnLogin);
        account.text = "";
        accountTitle.text = "帳號";
        testLogin.text = "登入";
    }
}