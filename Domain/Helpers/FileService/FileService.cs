namespace VinilProjeto.Service.FileService;

public class FileService
{
    public bool saveImagemService(string path, Stream content)
    {
        
        string directoryName = Path.GetDirectoryName(path)
                               ?? throw new Exception($"Diretório {path} não encontrado ou nulo!");

        if (!Directory.Exists(directoryName))
            Directory.CreateDirectory(directoryName);

        using FileStream file = new FileStream(path, FileMode.Create);
        content.CopyTo(file);
        
        return File.Exists(path);
    }

    public bool deleteImage(string path)
    {
        
        if(File.Exists(path))
            File.Delete(path);
        else
        {
            throw new Exception("Arquivo não encontrado!");
        }
        
        return true;
    }
    
    public bool deleteDiretorio(string path)
    {
        string directoryName = Path.GetDirectoryName(path) ??
                               throw new Exception("Diretório {path} não encontrado ou nulo!");

        if (!Directory.Exists(directoryName))
        {
            Directory.Delete(path);
        }

        return true;
    }

}