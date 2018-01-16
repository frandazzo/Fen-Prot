//#define FENEAL
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS
{
    [SecureContext()]
    public class CustomerHandler : SimpletHandler
    {

        public override  string ObjectTypeName
        {
            get { return "Customer"; }
        }



        //#region MembriSovrascritti
        //[Secure(Area = "Contatti", Alias = "Visualizza contatto", MacroArea = "Applicativo")]
        //public void CheckSecurityForView()
        //{
        //    SecurityManager.Instance.Check();
        //}


        //[Secure(Area = "Contatti", Alias = "Inserisci contatto", MacroArea = "Applicativo")]
        //public void CheckSecurityForInsert()
        //{
        //    SecurityManager.Instance.Check();
        //}


        //[Secure(Area = "Contatti", Alias = "Aggiorna contatto", MacroArea = "Applicativo")]
        //public void CheckSecurityForUpdate()
        //{
        //    SecurityManager.Instance.Check();
        //}

        //[Secure(Area = "Contatti", Alias = "Elimina contatto", MacroArea = "Applicativo")]
        //public void CheckSecurityForDeletion()
        //{
        //    SecurityManager.Instance.Check();
        //}


        //public override AbstractPersistenceObject GetElementById(string id)
        //{
        //    CheckSecurityForView();
        //    return base.GetElementById(id);
        //}


        //public override void SaveOrUpdate(AbstractPersistenceObject element)
        //{
        //    if (element == null)
        //        return;

        //    if (element.Key == null)
        //        CheckSecurityForInsert();
        //    else
        //        CheckSecurityForUpdate();

        //    base.SaveOrUpdate(element);
        //}


        //public override void Delete(AbstractPersistenceObject element)
        //{
        //    CheckSecurityForDeletion();
        //    base.Delete(element);
        //}


        //public override IList GetAll()
        //{
        //    CheckSecurityForView();
        //    return base.GetAll();
        //}

//#endregion

       


        public IList SearchCustomers(CustomerSearchDTO dto)
        {
            //CheckSecurityForView();

            Query q = _ps.CreateNewQuery("MapperCustomer");

#if (FENEAL)
            q.SetTable("DB_UTENTE");
#else
            q.SetTable("App_Customers");
#endif
            q.SetMaxNumberOfReturnedRecords(dto.MaxResult);


            CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);


            if (!string.IsNullOrEmpty(dto.Descrizione))
                c.AddCriteria (Criteria.Matches("COGNOME",dto.Descrizione ,_ps.DBType ));

            if (!string.IsNullOrEmpty(dto.Responsable))
                c.AddCriteria(Criteria.Matches("NOME", dto.Responsable, _ps.DBType));

            if (dto.CheckPrivate)
            {
                if (dto.IsPrivate)
                    c.AddCriteria(Criteria.Equal("IS_PRIVATO", "1"));
                else
                    c.AddCriteria(Criteria.Equal("IS_PRIVATO", "0"));
            }


            if (!string.IsNullOrEmpty(dto.Cellulare))
                c.AddCriteria (Criteria.Matches("CELL1",dto.Cellulare ,_ps.DBType ));

              if (!string.IsNullOrEmpty(dto.Mail))
                c.AddCriteria (Criteria.Matches("MAIL",dto.Mail ,_ps.DBType ));

             if (!string.IsNullOrEmpty(dto.Piva))
                c.AddCriteria (Criteria.Matches("CODICE_FISCALE",dto.Piva ,_ps.DBType ));


            if (dto.Resource != null)
                c.AddCriteria (Criteria.Equal("ResourceID",dto.Resource.Id.ToString()  ));

            if (dto.Province != null)
                if (dto.Province.Id  != -1)
                    c.AddCriteria (Criteria.Equal("ID_TB_PROVINCIE_RESIDENZA",dto.Province.Id.ToString()  ));

             if (dto.Comune != null)
                if (dto.Comune.Id  != -1)
                    c.AddCriteria (Criteria.Equal("ID_TB_COMUNI_RESIDENZA",dto.Comune.Id.ToString()  ));

            

            q.AddWhereClause (c);

            string d = q.CreateQuery(_ps);

            return q.Execute(_ps);
        }

    }
}
