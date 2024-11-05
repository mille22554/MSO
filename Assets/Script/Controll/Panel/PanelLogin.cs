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
        if (GameData.PlayerData == null)
        {
            GameData.PlayerData = new PlayerData(account.text);
            SaveMng.SaveGame();
        }
        if (GameData.PlayerData.name == null)
        {
            btnLogin.onClick.RemoveListener(OnLogin);
            SetAccountText("");
            accountTitle.text = "名稱";
            testLogin.text = "確定";
            btnLogin.onClick.AddListener(OnSetName);
        }
        else EnterGame();
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
            GameData.PlayerData.name = account.text;
            SaveMng.SaveGame();
            EnterGame();
        }
    }
    private void CheckSave(SaveData save, int ver)
    {
        if (save == null)
        {
            ver++;
            if (ver >= GameData.version.Length)
            {
                GameData.save = new SaveData();
                SaveMng.SaveGame();
            }
            else CheckSave(SaveMng.LoadGame(account.text + GameData.version[ver]), ver);
        }
        else GameData.save = save;
    }
    private void EnterGame()
    {
        ObjectPool.Put(this);
        EventMng.EmitEvent(EventName.EnterGame);
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