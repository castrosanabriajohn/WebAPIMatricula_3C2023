namespace API.Dal.General;

public class Encrypter
{
    public static string Decrypt(string pTexto)
    {
        string result = string.Empty;
        byte[] decrypted = Convert.FromBase64String(pTexto);
        result = System.Text.Encoding.Unicode.GetString(decrypted);
        return result;
    }


    public static string Encrypt(string pTexto)
    {
        string result = string.Empty;
        byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(pTexto);
        result = Convert.ToBase64String(encrypted);
        return result;
    }
}