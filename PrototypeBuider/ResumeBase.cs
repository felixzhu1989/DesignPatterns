namespace PrototypeBuilder
{
   public abstract class ResumeBase
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string ExpectedSalary { get; set; }
        public abstract void Display();
    }
}
