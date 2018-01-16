//#define FENEAL
using System;
using System.Collections.Generic;
using System.Text;
using WIN.SECURITY.Core;
using WIN.SECURITY;
using WIN.TECHNICAL.PERSISTENCE;
using System.Collections;
using WIN.BASEREUSE;


namespace WIN.SCHEDULING_APPLICATION.HANDLERS.MainSubSystems
{
    public class SecureDataManager : ISecureDataAccess
    {
        private IPersistenceFacade ps = null;

        public SecureDataManager()
        {
            ps = DataAccessServices.Instance().PersistenceFacade;
        }

        public void BeginTransaction()
        {
            ps.BeginTransaction(new SecurityDBSortingServices());
        }

        public void MarkNew(AbstractPersistenceObject obj)
        {
            ps.MarkNew(obj);
        }
        public void MarkDirty(AbstractPersistenceObject obj)
        {
            ps.MarkDirty(obj);
        }
        public void MarkDelete(AbstractPersistenceObject obj)
        {
            ps.MarkRemoved(obj);
        }

        public void CommitTransaction()
        {
            try
            {
                ps.CommitTransaction();
            }
            catch (Exception)
            {
                ps.RollBackTRansaction();
                throw;
            }
        }

        #region ISecureDataAccess Membri di

        public void DeleteProfile(IProfile profile)
        {
            //
        }

        public void DeleteRole(IRole role)
        {
            //
        }

        public IList<IProfile> GetProfiles()
        {
          IList list  = ps.GetAllObjects("Profile");

          IList< IProfile> list1  = new List< IProfile>();
          foreach (IProfile elem in list)
          {
             list1.Add(elem);
          }

          return list1;
        }

        public IList<IRole> GetRoles()
        {
                IList list   = ps.GetAllObjects("Role");

                IList<IRole> list1 = new List<IRole>();
                foreach (IRole elem in list)
	            {
		             list1.Add(elem);
	            }
                return list1;
        }

        public IUser GetUser(string username, string password)
        {
              Query query  = ps.CreateNewQuery("MapperUser");
              CompositeCriteria mainCriteria   = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);

              mainCriteria.AddCriteria(Criteria.Equal("Username", "'" + username + "'"));
#if (FENEAL)
            mainCriteria.AddCriteria(Criteria.Equal("Password", "'" + password + "'"));
#else
              mainCriteria.AddCriteria(Criteria.Equal("Passwordd", "'" + password + "'"));
#endif

            query.AddWhereClause(mainCriteria);

              IList list   = query.Execute(ps);
              if (list.Count == 0)
                  return null;
              return list[0] as IUser;
        }

        public IList<IUser> GetUsers()
        {
            IList list   = ps.GetAllObjects("User");
            IList<IUser> list1  = new List<IUser>();
            foreach ( IUser elem in list)
            {
                list1.Add(elem);
            }
            return list1;
        }

        public void Save(IProfile profile)
        {
            //
        }

        public void Save(IUser user)
        {
            //
        }

        public void SaveRole(IRole role)
        {
            //
        }

        public IList<WIN.BASEREUSE.Role> GetNormalizedRoles()
        {
              List<WIN.BASEREUSE.Role>  list = new List<WIN.BASEREUSE.Role>();

          
              foreach (IRole elem in GetRoles())
              {
                  list.Add(elem as WIN.BASEREUSE.Role);
              }
              return list;
        }

        #endregion
    }
}
