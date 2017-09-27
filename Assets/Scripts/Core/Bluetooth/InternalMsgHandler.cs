using UnityEngine;
using Utils;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace core.Bluetooth
{
    public class InternalMsgHandler : MonoBehaviour
    {
		public static InternalMsgHandler _instance = null;
        private  bool _bleStat = false;
        bool isOpenBlueTooth = true;

        public Transform bluetoothPanel;
        public Image messageImage;
        public GameObject blueButton;

        void Awake()
		{
			_instance = this;
		}

		public static InternalMsgHandler Instance()
		{
			return _instance;
		}

        void Update()
        {
            if (SceneManager.GetActiveScene().name.Equals("Scene3(Main)"))
            {
                bluetoothPanel = GameObject.Find("Panels").transform.GetChild(1);
                
                blueButton = bluetoothPanel.FindChild("BlueButton").gameObject;
                messageImage = bluetoothPanel.FindChild("MessageImage").GetComponent<Image>();
                if (isOpenBlueTooth)
                {
                    blueButton.GetComponent<Button>().onClick.AddListener(OnScanBtnClick);
                    isOpenBlueTooth = false;
                }
             
            }
            if (SceneManager.GetActiveScene().name.Equals("Scene5(SuanShu)"))
            {
                isOpenBlueTooth = true;
            }
        }


        private void OnScanBtnClick()
        {
            if (!BleStat)
            {
                BleApi.BleScan();
                Debug.Log("正在连接中···");
                messageImage.sprite = Resources.Load<Sprite>("_RealUI/连接中");
            }
            else
            {
                BleApi.DisconnectBle();
            }
        }

        private bool BleStat
        {
            
            get
            {
                return _bleStat;
            }
            set
            {
                _bleStat = value;
                if (_bleStat)
                {
                    Debug.Log("连接成功");
                    messageImage.sprite = Resources.Load<Sprite>("_RealUI/连接成功");

                }
                else
                {
                    Debug.Log("连接失败");
                    messageImage.sprite = Resources.Load<Sprite>("_RealUI/连接失败");
                }
            }
        }
       

        void GetBleStatus(string status)
        {
            // 连接状态改变主动通知；
            //check ble connect status
            if (status == "true")
            {
                // 蓝牙连接成功处理
                BleStat = true;

            }
            else if (status == "false")
            {
                // 蓝牙连接失败处理
                BleStat = false;
            }
        }

       void GetBleReply(string msg)
        {
            // 按键响应，
            // { 02:换子弹，03:开火，04:换武器}
            byte[] arr = HexString.Hex2bytes(msg);
            if (null == arr || arr.Length == 0) return;
            switch (arr[0])
            {
                case 0x02:


                    if (SceneManager.GetActiveScene().name.Equals("Scene5(SuanShu)"))
                    {
                        if (BalletManager.Instance.isFire == true)
                            BalletManager.Instance.AddBallet();
                        //若暂停面板激活，换弹键 退出到主界面
                        else if (BalletManager.Instance.isFire == false && GameObject.Find("Panels").transform.GetChild(1).gameObject.activeInHierarchy)
                            UIManager.Instance.BackButtonOnPanelClick();
                        //若游戏结束面板激活，换弹键 退出到主界面
                        else if (BalletManager.Instance.isFire == false && GameObject.Find("Panels").transform.GetChild(2).gameObject.activeInHierarchy)
                            UIManager.Instance.BackButtonOnPanelClick();
                    }

                    break;
                case 0x03:
                    if (SceneManager.GetActiveScene().name.Equals("Scene3(Main)"))
                    {
                        UIManager.Instance.MainScene_SuanShu_BtnClick();//连接成功自动进入游戏界面
                    }
                    if (SceneManager.GetActiveScene().name.Equals("Scene5(SuanShu)"))
                    {
                        if (BalletManager.Instance.isFire == true)
                            BalletManager.Instance.Fire();
                        //若暂停面板激活，发射键 下一关
                        else if (BalletManager.Instance.isFire == false && GameObject.Find("Panels").transform.GetChild(1).gameObject.activeInHierarchy)
                            UIManager.Instance.OnPassLevelPanelClick();
                        //若游戏结束面板激活，发射键 重玩本关
                        else if (BalletManager.Instance.isFire == false && GameObject.Find("Panels").transform.GetChild(2).gameObject.activeInHierarchy)
                            UIManager.Instance.TryAgainButtonOnPanelClick();

                    }
                    break;
                case 0x04:

                    break;
                default:
                    break;
            }
        }

        void GetBleData(string data)
        {
            // 接收蓝牙数据
            // AR枪项目未使用
        }
    }
}
