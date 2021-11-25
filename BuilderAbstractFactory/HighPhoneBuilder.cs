namespace BuilderAbstractFactory
{
    public class HighPhoneBuilder:PhoneBuilder
    {
        public override void BuildCpu()
        {
            Phone.Cpu = new HighCpu();
        }

        public override void BuildMem()
        {
            Phone.Mem = new HighMem();
        }

        public override void BuildScreen()
        {
            Phone.Screen = new HighScreen();
        }
    }
}
