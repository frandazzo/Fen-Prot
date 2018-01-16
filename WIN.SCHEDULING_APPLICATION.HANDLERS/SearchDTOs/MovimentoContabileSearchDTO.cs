using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs
{
    public class MovimentoContabileSearchDTO: IsearchDTO
    {
    
        private DataRange _range;
        private IList<Provincia> _province = new List<Provincia>();
        private IList<Regione> _regioni = new List<Regione>();
        private IList<CausaleAmministrativa> _causali = new List<CausaleAmministrativa>();
        private bool _forRimesse = false;
        private int _year;


        public MovimentoContabileSearchDTO(int year, IList<Provincia> province, IList<Regione> regioni, IList<CausaleAmministrativa> causali, bool forRimesse)
        {
            _forRimesse = forRimesse;
            _province = province;
            _causali = causali;
            _regioni= regioni;
            _range = new DataRange(new DateTime(year, 1, 1), new DateTime(year, 12, 31));
            _year = year;
            
        }

     

        public WIN.TECHNICAL.PERSISTENCE.AbstractBoolCriteria GenerateSql()
        {
            CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);
            if (_forRimesse)
                c.AddCriteria(Criteria.Equal("Anno",_year.ToString()));
            else
                c.AddCriteria(Criteria.DateTimeContained("Data", _range.Start, _range.Finish, DataAccessServices.Instance().PersistenceFacade.DBType));

                if (_province != null)
                    foreach (Provincia item in _province)
                    {
                        c.AddCriteria(Criteria.Equal("Id_Provincia",item.Id.ToString()));
                    }

                if (_regioni != null)
                    foreach (Regione item in _regioni)
                    {
                        c.AddCriteria(Criteria.Equal("Id_Regione", item.Id.ToString()));
                    }

                if (_causali != null)
                    foreach (CausaleAmministrativa item in _causali)
                    {
                        c.AddCriteria(Criteria.Equal("Id_CausaleAmministrazione", item.Id.ToString()));
                    }


                return c;
        }

    }
}

