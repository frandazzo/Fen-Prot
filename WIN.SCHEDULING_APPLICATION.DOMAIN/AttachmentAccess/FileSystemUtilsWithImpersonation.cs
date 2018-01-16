using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace  WIN.SCHEDULING_APPLICATION.DOMAIN.AttachmentAccess
{
    public class FileSystemUtilsWithImpersonation : WIN.SCHEDULING_APPLICATION.DOMAIN.AttachmentAccess.INetworkFileSystemUtils
    {
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);


        private string usenrame;
        private string password;
        private string domain;

        public FileSystemUtilsWithImpersonation(string username, string password, string domain)
        {
            this.usenrame = username;
            this.password = password;
            this.domain = domain;

        }

        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public bool UncFileExist(string uncfilename)
        {
            SafeTokenHandle safeTokenHandle;
            try
            {

                bool fileExist = false;

                const int LOGON32_PROVIDER_DEFAULT = 0;
                //This parameter causes LogonUser to create a primary token.
                const int LOGON32_LOGON_NEW_CREDENTIALS = 9;

                // Call LogonUser to obtain a handle to an access token.
                bool returnValue = false;

               
                returnValue = LogonUser(this.usenrame, this.domain, this.password,
                LOGON32_LOGON_NEW_CREDENTIALS, LOGON32_PROVIDER_DEFAULT,
                out safeTokenHandle);
                

                if (false == returnValue)
                {
                    int ret = Marshal.GetLastWin32Error();
                    throw new System.ComponentModel.Win32Exception(ret);
                }

                using (safeTokenHandle)
                {
                    // Use the token handle returned by LogonUser.
                    using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
                    {
                        using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                        {


                            string uncPath = uncfilename;

                            FileInfo ff = new FileInfo(uncPath);
                            fileExist = ff.Exists;

                        }
                    }

                   
                    // Releasing the context object stops the impersonation
                    // Check the identity.
                    //Debug.WriteLine("After closing the context: " + WindowsIdentity.GetCurrent().Name);
                    return fileExist;
                }
            }
            catch (Exception ex)
            {
                throw new ImpersonationException("Errore nella procedura di impersonation: " + ex.Message, ex);
            }
        }

        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public string CopyUncFileToLocalTempFolder(string uncFileName)
        {
            SafeTokenHandle safeTokenHandle;
            try
            {
                string fileCopied = "";

                const int LOGON32_PROVIDER_DEFAULT = 0;
                //This parameter causes LogonUser to create a primary token.
                const int LOGON32_LOGON_NEW_CREDENTIALS = 9;

                // Call LogonUser to obtain a handle to an access token.
                bool returnValue = false;


                returnValue = LogonUser(this.usenrame, this.domain, this.password,
                LOGON32_LOGON_NEW_CREDENTIALS, LOGON32_PROVIDER_DEFAULT,
                out safeTokenHandle);


                if (false == returnValue)
                {
                    int ret = Marshal.GetLastWin32Error();
                    throw new System.ComponentModel.Win32Exception(ret);
                }
                using (safeTokenHandle)
                {
                    // Use the token handle returned by LogonUser.
                    using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
                    {
                        using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                        {

                            string uncPath = uncFileName;

                            FileInfo ff = new FileInfo(uncPath);
                            if (ff.Exists)
                            {
                                string result = Path.GetTempPath() + ff.Name;
                                File.Copy(uncPath, result, true);
                                fileCopied = result;
                            }

                        }
                    }

                   
                    // Releasing the context object stops the impersonation
                    // Check the identity.
                    return fileCopied;
                }
            }
            catch (Exception ex)
            {
                throw new ImpersonationException("Errore nella procedura di impersonation: " + ex.Message, ex);
            }
        }


        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public string CopyLocalFileToUncFolder(string localFileName, string uncFolder, string filename, bool overwrite)
        {
            SafeTokenHandle safeTokenHandle;
            try
            {
                string fileCopied = "";

                const int LOGON32_PROVIDER_DEFAULT = 0;
                //This parameter causes LogonUser to create a primary token.
                const int LOGON32_LOGON_NEW_CREDENTIALS = 9;

                // Call LogonUser to obtain a handle to an access token.
                bool returnValue = false;


                returnValue = LogonUser(this.usenrame, this.domain, this.password,
                LOGON32_LOGON_NEW_CREDENTIALS, LOGON32_PROVIDER_DEFAULT,
                out safeTokenHandle);


                if (false == returnValue)
                {
                    int ret = Marshal.GetLastWin32Error();
                    throw new System.ComponentModel.Win32Exception(ret);
                }
                using (safeTokenHandle)
                {
                    // Use the token handle returned by LogonUser.
                    using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
                    {
                        using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                        {

                            string path = localFileName;

                            FileInfo ff = new FileInfo(localFileName);
                            DirectoryInfo dd = new DirectoryInfo(uncFolder);
                            if (ff.Exists)
                            {
                                if (dd.Exists)
                                {
                                    string result = "";
                                    if (dd.FullName.EndsWith(@"\") || dd.FullName.EndsWith(@"/"))
                                        result = dd.FullName + filename;
                                    else
                                        result = dd.FullName + "/"  + filename;

                                    File.Copy(path, result, overwrite);
                                    fileCopied = result;
                                }
                            }

                        }
                    }


                    // Releasing the context object stops the impersonation
                    // Check the identity.
                    return fileCopied;
                }
            }
            catch (Exception ex)
            {
                throw new ImpersonationException("Errore nella procedura di impersonation: " + ex.Message, ex);
            }
        }


        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public void DeleteUncFile(string uncFileName)
        {
            SafeTokenHandle safeTokenHandle;
            try
            {
               

                const int LOGON32_PROVIDER_DEFAULT = 0;
                //This parameter causes LogonUser to create a primary token.
                const int LOGON32_LOGON_NEW_CREDENTIALS = 9;

                // Call LogonUser to obtain a handle to an access token.
                bool returnValue = false;


                returnValue = LogonUser(this.usenrame, this.domain, this.password,
                LOGON32_LOGON_NEW_CREDENTIALS, LOGON32_PROVIDER_DEFAULT,
                out safeTokenHandle);


                if (false == returnValue)
                {
                    int ret = Marshal.GetLastWin32Error();
                    throw new System.ComponentModel.Win32Exception(ret);
                }
                using (safeTokenHandle)
                {
                    // Use the token handle returned by LogonUser.
                    using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
                    {
                        using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                        {

                            string uncPath = uncFileName;

                            FileInfo ff = new FileInfo(uncPath);
                            if (ff.Exists)
                            {
                                ff.Delete();
                            }

                        }
                    }


                    // Releasing the context object stops the impersonation
                    // Check the identity.
                   
                }
            }
            catch (Exception ex)
            {
                throw new ImpersonationException("Errore nella procedura di impersonation: " + ex.Message, ex);
            }
        }


         [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public bool UncFolderExist(string uncfilename)
        {
            SafeTokenHandle safeTokenHandle;
            try
            {

                bool fileExist = false;

                const int LOGON32_PROVIDER_DEFAULT = 0;
                //This parameter causes LogonUser to create a primary token.
                const int LOGON32_LOGON_NEW_CREDENTIALS = 9;

                // Call LogonUser to obtain a handle to an access token.
                bool returnValue = false;


                returnValue = LogonUser(this.usenrame, this.domain, this.password,
                LOGON32_LOGON_NEW_CREDENTIALS, LOGON32_PROVIDER_DEFAULT,
                out safeTokenHandle);


                if (false == returnValue)
                {
                    int ret = Marshal.GetLastWin32Error();
                    throw new System.ComponentModel.Win32Exception(ret);
                }

                using (safeTokenHandle)
                {
                    // Use the token handle returned by LogonUser.
                    using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
                    {
                        using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                        {


                            string uncPath = uncfilename;

                            DirectoryInfo ff = new DirectoryInfo(uncPath);
                            fileExist = ff.Exists;

                        }
                    }


                    // Releasing the context object stops the impersonation
                    // Check the identity.
                    //Debug.WriteLine("After closing the context: " + WindowsIdentity.GetCurrent().Name);
                    return fileExist;
                }
            }
            catch (Exception ex)
            {
                throw new ImpersonationException("Errore nella procedura di impersonation: " + ex.Message, ex);
            }
        }
    }

    public class ImpersonationException : Exception
    {
        public ImpersonationException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }


    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeTokenHandle()
            : base(true)
        {
        }

        [DllImport("kernel32.dll")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr handle);

        protected override bool ReleaseHandle()
        {
            return CloseHandle(handle);
        }
    }

}
