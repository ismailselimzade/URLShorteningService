namespace URLShorteningService.Services
{
    public static class ShortCodeGenerator
    {
        public static string Generate()
        {
            string code = string.Empty;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            for (int i = 0; i < 5; ++i)
            {
                int index = random.Next(0, chars.Length);
                code += chars[index];
            }

            return code;
        }
    }
}
