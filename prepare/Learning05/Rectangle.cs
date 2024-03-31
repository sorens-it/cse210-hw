class Rectangle : Shape {
    private double _khWidth;
    private double _khLength;

    public Rectangle(string khColor, double khWidth, double khLength) {
        _khColor = khColor;
        _khWidth = khWidth;
        _khLength = khLength;
    }

    public override double KhGetArea() {
        return _khLength * _khWidth;
    }
}