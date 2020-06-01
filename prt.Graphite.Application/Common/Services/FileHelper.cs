namespace Prt.Graphit.Application.Common.Services
{
    public static class FileHelper
    {
        private static string GetTypeFile(string text) => text.Trim('.');

        public static FileTypeInfo GetContentType(string text)
        {
            string contentType = string.Empty;

            var _typeFile = GetTypeFile(text);
            switch (_typeFile)
            {
                case "jpg":
                    contentType = $"image/{_typeFile}";
                    break;
                case "jpeg":
                    contentType = $"image/{_typeFile}";
                    break;
                case "gif":
                    contentType = $"image/{_typeFile}";
                    break;
                case "png":
                    contentType = $"image/{_typeFile}";
                    break;
                case "mp4":
                    contentType = $"video/{_typeFile}";
                    break;
                case "mpeg4":
                    contentType = $"video/{_typeFile}";
                    break;
                case "mpeg":
                    contentType = $"video/{_typeFile}";
                    break;
                case "vmk":
                    contentType = $"video/{_typeFile}";
                    break;
                case "wma":
                    contentType = $"video/{_typeFile}";
                    break;
                case "zip":
                    contentType = $"application/zip";
                    break;
                default:
                    contentType = $"";
                    break;
            }


            return new FileTypeInfo
            {
                TypeFileString = contentType
            };
        }
    }

    public class FileTypeInfo
    {
        public string TypeFileString { get; set; }
    }
}
