using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN
{
    public class SoftwareInfo : AbstractPersistenceObject
    {

        private string _dbUpgradePath;
        public string DBUpgradePath
        {
            get
            {
                return _dbUpgradePath;
            }
            set
            {
                _dbUpgradePath = value;
            }
        }
        private string _softwareUpgratePath;
        public string SoftwareUpgratePath
        {
            get
            {
                return _softwareUpgratePath;
            }
            set
            {
                _softwareUpgratePath = value;
            }
        }
        private Version _dbVersion;
        public Version DBVersion
        {
            get
            {
                return _dbVersion;
            }
            set
            {
                _dbVersion = value;
            }
        }
        private Version _softwareVersion;
        public Version SoftwareVersion
        {
            get
            {
                return _softwareVersion;
            }
            set
            {
                _softwareVersion = value;
            }
        }
        private DateTime _lastUpdate;
        public DateTime LastUpdate
        {
            get
            {
                return _lastUpdate;
            }
            set
            {
                _lastUpdate = value;
            }
        }

    }
}
