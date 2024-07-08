using HidApi;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DualSenseAPI.Util
{
    /// <summary>
    /// Utilities to scann for DualSense controllers on HID.
    /// </summary>
    internal class HidScanner
    {
        //private readonly  IDeviceFactory hidFactory;

        private static HidScanner? _instance = null;
        /// <summary>
        /// Singleton HidScanner instance.
        /// </summary>
        internal static HidScanner Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HidScanner();
                }
                return _instance;
            }
        }

        private HidScanner()
        {
        }

        /// <summary>
        /// Lists connected devices.
        /// </summary>
        /// <returns>An enumerable of connected devices.</returns>
        public IEnumerable<HidApi.DeviceInfo> ListDevices()
        {
            HidApi.Hid.Init();
            var devices = HidApi.Hid.Enumerate(1356, 3302);

            return devices;
        }

        /// <summary>
        /// Gets a device from its information.
        /// </summary>
        /// <param name="deviceDefinition">The information for the connected device.</param>
        /// <returns>The actual device.</returns>
        public Device GetConnectedDevice(DeviceInfo deviceDefinition)
        {
            return deviceDefinition.ConnectToDevice();
        }
    }
}
