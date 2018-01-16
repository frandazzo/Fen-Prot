using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.DEPLOYMENT.CORE;
using WIN.TECHNICAL.DEPLOYMENT;

using WIN.TECHNICAL.DEPLOYMENT.CORE.LICENCE;

using WIN.TECHNICAL.DEPLOYMENT.TimingClasses;

namespace WIN.SCHEDULING_APP.GUI.Licensing
{
    public class LicenceFactory
    {

        public static ILicence  CreateTrialLicence(DateTime activationDate, int trialDays,string hardwareId)
        {
            ILicence l = new Licence();
            l.Type = LicenceTypes.Trial;
            l.TrialDays = trialDays;
            l.ActivationDate = activationDate;
            l.HardwareId = hardwareId ;
            return l;
        }


        public static ILicence CreateFullLicence(DateTime activationDate, string activationCode,string hardwareId)
        {
            ILicence l = new Licence();
            l.Type = LicenceTypes.All;
            l.ActivationCode = activationCode;
            l.ActivationDate = activationDate;
            l.HardwareId = hardwareId ;
            return l;
        }


        public static ILicence CreateTemporaryLicence(DateTime activationDate, string activationCode, TemporalRange validity,string hardwareId)
        {
            ILicence l = new Licence();
            l.Type = LicenceTypes.Temporary;
            l.ActivationCode = activationCode;
            l.ActivationDate = activationDate;
            l.Validity = validity;
            l.HardwareId = hardwareId ;
            return l;
        }



        public static ILicence  CreateLicence(LicenceTypes type, DateTime activationDate, string activationCode, TemporalRange validity, int trialDays,string hardwareId)
        {
            switch (type)
            {
                case LicenceTypes.Temporary:
                    return CreateTemporaryLicence(activationDate, activationCode, validity,hardwareId );
                case LicenceTypes.Trial:
                    return CreateTrialLicence(activationDate, trialDays,hardwareId);
                case LicenceTypes.All:
                    return CreateFullLicence(activationDate, activationCode,hardwareId);
                default:
                    return null;
            }
        }


    }
}
