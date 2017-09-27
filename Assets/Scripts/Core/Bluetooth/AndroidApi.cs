using UnityEngine;

namespace core.Bluetooth
{
    class AndroidApi
    {
        public static void CallAndroidFunc(string funcStr, params object[] args)
        {
#if UNITY_ANDROID
            using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    jo.Call(funcStr, args);
                }
            }
#endif
        }
        public static string CallAndroidFuncString(string funcStr, params object[] args)
        {
#if UNITY_ANDROID
            using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    return jo.Call<string>(funcStr, args);
                }
            }
#else
			return null;
#endif
        }
    }
}
