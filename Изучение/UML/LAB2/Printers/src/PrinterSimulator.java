public class PrinterSimulator {
    public static void main(String[] args){
        Printer lazer = new LazerPrinter();
        lazer.performPrint();

        Printer jet = new JetPrinter();
        jet.performPrint();

        Printer led = new LedPrinter();
        led.performPrint();

        Printer matrix = new MatrixPrinter();
        matrix.performPrint();
    }
}
