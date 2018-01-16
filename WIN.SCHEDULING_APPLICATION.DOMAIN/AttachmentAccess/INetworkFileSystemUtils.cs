using System;
namespace WIN.SCHEDULING_APPLICATION.DOMAIN.AttachmentAccess
{
    public interface INetworkFileSystemUtils
    {
        string CopyLocalFileToUncFolder(string localFileName, string uncFolder, string filename, bool overwrite);
        string CopyUncFileToLocalTempFolder(string uncFileName);
        void DeleteUncFile(string uncFileName);
        bool UncFileExist(string uncfilename);

        bool UncFolderExist(string uncfilename);
    }
}
