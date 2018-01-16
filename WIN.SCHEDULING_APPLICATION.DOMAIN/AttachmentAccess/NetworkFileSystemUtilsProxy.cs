using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.AttachmentAccess
{
    public class NetworkFileSystemUtilsProxy: INetworkFileSystemUtils
    {

        private INetworkFileSystemUtils CreateFileSystemUtilsWithImpersonation()
        {
            FileSystemUtilsWithImpersonation f = new FileSystemUtilsWithImpersonation(
                NetworkCredentials.Instance().NetworkUsername,
                NetworkCredentials.Instance().NetworkPassord,
                NetworkCredentials.Instance().NetworkDomain);
            return f;
        }

        public string CopyLocalFileToUncFolder(string localFileName, string uncFolder, string filename, bool overwrite)
        {
           
                string path = localFileName;

                FileInfo ff = new FileInfo(localFileName);
                DirectoryInfo dd = new DirectoryInfo(uncFolder);
                if (ff.Exists)
                {
                    try
                    {
                        string result = "";
                        if (dd.FullName.EndsWith(@"\") || dd.FullName.EndsWith(@"/"))
                            result = dd.FullName + filename;
                        else
                            result = dd.FullName + "/" + filename;

                        File.Copy(path, result, overwrite);
                        return result;
                    }
                    catch
                    {
                        // se cè errore vuol dire che non ho accesso 
                        //e quindi provo direttamente vcon le credenziali
                        return CreateFileSystemUtilsWithImpersonation().CopyLocalFileToUncFolder(localFileName, uncFolder, filename, overwrite);
                    }

                }
                return "";

        }

        public string CopyUncFileToLocalTempFolder(string uncFileName)
        {
            try
            {
                string uncPath = uncFileName;

                FileInfo ff = new FileInfo(uncPath);

                string result = Path.GetTempPath() + ff.Name;
                File.Copy(uncPath, result, true);
                return result;

            }
            catch
            {

                return CreateFileSystemUtilsWithImpersonation().CopyUncFileToLocalTempFolder(uncFileName);
            }
        }

        public void DeleteUncFile(string uncFileName)
        {
            try
            {
                File.Delete(uncFileName);
            }
            catch
            {
                CreateFileSystemUtilsWithImpersonation().DeleteUncFile(uncFileName);
            }
        }

        public FileInfo CretateUncFileFinfo(string filename){
            if (UncFileExist(filename))
            {
                return new FileInfo(filename);
            }

            return null;

        }

        public DirectoryInfo CreateUncFolderFinfo(string filename)
        {
            if (UncFolderExist(filename))
            {
                return new DirectoryInfo(filename);
            }

            return null;

        }


        public bool UncFileExist(string uncfilename)
        {
           
                FileInfo ff = new FileInfo(uncfilename);
                bool exist = ff.Exists;

                //se non esiste verifico con le credenziali del network
                if (!exist)
                    return CreateFileSystemUtilsWithImpersonation().UncFileExist(uncfilename);

                return true;
            
        }

        public bool UncFolderExist(string uncfilename)
        {

            DirectoryInfo ff = new DirectoryInfo(uncfilename);
            bool exist = ff.Exists;

            //se non esiste verifico con le credenziali del network
            if (!exist)
                return CreateFileSystemUtilsWithImpersonation().UncFolderExist(uncfilename);

            return true;

        }
    }
}
