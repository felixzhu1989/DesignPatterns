namespace Adapter
{
    public class Computer
    {
        private IUsb _usb;
        public void SetUsb(IUsb usb)
        {
            _usb = usb;
        }

        public void ConnectUsb()
        {
            if (_usb != null)
            {
                _usb.Request();
            }
        }
    }
}
