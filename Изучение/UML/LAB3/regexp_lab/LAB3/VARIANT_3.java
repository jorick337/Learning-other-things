import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class VARIANT_3 {
    public static void main(String[] args) throws IOException {
        String FilePath = "C:\\Users\\Admin\\IdeaProjects\\regexp_lab\\LAB3\\file.txt";
        String text = ReadFile(FilePath);
        String Cleanedtext = checkWithRegExp(text);
        System.out.print(Cleanedtext);
    }
    public static String ReadFile(String FilePath) throws IOException {
        StringBuilder content = new StringBuilder();
        try (BufferedReader reader = new BufferedReader(new FileReader(FilePath))) {
            String line;
            while ((line = reader.readLine()) != null) {
                content.append(line).append("\n");
            }
        }
        return content.toString();
    }
    public static String checkWithRegExp(String text){
        Pattern Name = Pattern.compile("\\b[А-ЯЁ][а-яё]*\\s[А-ЯЁ][а-яё]*\\b");
        Pattern Phone = Pattern.compile("\\b\\d{3}[-.\\s]?\\d{3}[-.\\s]?\\d{4}\\b");
        Pattern Location = Pattern.compile("\\b[А-ЯЁ][а-яё]*(?:,\\s[А-ЯЁ]{2})?\\b");

        Matcher matcher = Name.matcher(text);
        text = matcher.replaceAll("[censored]");

        matcher = Phone.matcher(text);
        text = matcher.replaceAll("[censored]");

        matcher = Location.matcher(text);
        text = matcher.replaceAll("[censored]");

        return text;
    }
}
