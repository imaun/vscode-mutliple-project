namespace SampleProject.Lib;

public class SampleClass
{

    public SampleClass() {
        Name = "Sample";
    }

    public string Name { get; private set; }

    public void Echo() {
        Console.WriteLine($"My name is '{Name}'");
    }
    
}
