public class LedPrinter extends Printer{
    public LedPrinter(){
        view = "Светодиодный";
        change = new Led();
    }
}
