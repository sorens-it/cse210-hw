class Square : Shape {
    private double _khSide;

    public Square(string khColor, double khSide) {
        _khColor = khColor;
        _khSide = khSide;
    }

    public override double KhGetArea() {
        return _khSide * _khSide;
    }
}