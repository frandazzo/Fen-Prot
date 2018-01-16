using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.DEPLOYMENT.CORE;
using WIN.TECHNICAL.DEPLOYMENT.CHECKERS;
using WIN.TECHNICAL.DEPLOYMENT.ACTIONS;
using WIN.TECHNICAL.DEPLOYMENT;
using WIN.TECHNICAL.DEPLOYMENT.CORE.CHECKERS;

namespace WIN.SCHEDULING_APP.GUI.Licensing
{
    public class DecisionTreeManager : AbstractDecisionTreeManager
    {


        public DecisionTreeManager(string hardwareId)
        {
            _hardwareId = hardwareId;
        }

        private string _hardwareId;


        public override void Initialize()
        {
            ValidityChecker temporaryValidator = new ValidityChecker(new DummyChecker(new FirstRunActivationCodeAction(_hardwareId )), new DummyAction(), InstallationManager.Instance.InstallationInfo.Licence);
            TemporaryChecker temporary = new TemporaryChecker(new DummyChecker(new DummyAction()), temporaryValidator, InstallationManager.Instance.InstallationInfo.Licence);
            ValidityChecker trialValidator = new ValidityChecker(new DummyChecker(new FirstRunActivationCodeAction(_hardwareId )), new DummyAction(), InstallationManager.Instance.InstallationInfo.Licence);
            TrialChecker trial = new TrialChecker(temporary, trialValidator, InstallationManager.Instance.InstallationInfo.Licence);
            _decisionTree = trial;
        }
    }
}
