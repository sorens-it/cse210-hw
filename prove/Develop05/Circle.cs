class Circle : Shape {
    private double _khRadius;

    public Circle(string khColor, double khRadius) {
        _khColor = khColor;
        _khRadius = khRadius;
    }

    public override double KhGetArea()
    {
        return 3.1415926 * (_khRadius * _khRadius);
    }


}