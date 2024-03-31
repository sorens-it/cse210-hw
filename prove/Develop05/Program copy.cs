class Program
{
    static void Main(string[] args)
    {
        Square khSqare1 = new Square("Orange", 5);
        Console.WriteLine(khSqare1.KhGetColor());
        Console.WriteLine(khSqare1.KhGetArea());

        Rectangle khRectangle1 = new Rectangle("Red", 3, 7);
        Console.WriteLine(khRectangle1.KhGetColor());
        Console.WriteLine(khRectangle1.KhGetArea());
        
        Circle khCircle1 = new Circle("Black", 6);
        Console.WriteLine(khCircle1.KhGetColor());
        Console.WriteLine(khCircle1.KhGetArea());

        List<Shape> khShapeList = new List<Shape>{
            new Square("Orange", 5),
            new Rectangle("Red", 3, 7), 
            new Circle("Black", 6)
        };

        foreach (Shape khShape in khShapeList) {
            Console.WriteLine(khShape.KhGetColor());
            Console.WriteLine(khShape.KhGetArea());
        }
    }
}