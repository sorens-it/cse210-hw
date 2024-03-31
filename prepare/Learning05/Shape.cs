abstract class Shape {
protected string _khColor;

public void KhSetColor(string khColor) {
    _khColor = "red";
}

public string KhGetColor() {
    return _khColor;
}

public abstract double KhGetArea();


}