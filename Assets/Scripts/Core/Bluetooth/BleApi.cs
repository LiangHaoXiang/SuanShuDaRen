namespace core.Bluetooth
{
    class BleApi
    {
        public static void BleScan()
        {
            AndroidApi.CallAndroidFunc("StartBleScan");
        }

		public static void StopBleScan()
		{
			AndroidApi.CallAndroidFunc("StopBleScan");
		}

		public static void DisconnectBle()
		{
			AndroidApi.CallAndroidFunc("DisconnectBle");
		}
    }
}
