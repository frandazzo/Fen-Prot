using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.PERSISTENCE;
using System.Collections;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.MainSubSystems
{
    public class SecurityDBSortingServices : ISortStrategy
    {

        #region ISortStrategy Membri di

        public System.Collections.ArrayList SortList(object ListToSort)
        {
              IList list = ListToSort as ArrayList;
              ArrayList result= new ArrayList();

              ArrayList profiliDirty = new ArrayList();
              ArrayList profiliDeleted = new ArrayList();
              ArrayList profiliNew = new ArrayList();


              ArrayList rpDirty = new ArrayList();
              ArrayList rpDeleted = new ArrayList();
              ArrayList rpNew = new ArrayList();

              ArrayList permessiDirty = new ArrayList();
              ArrayList permessiDeleted = new ArrayList();
              ArrayList permessiNew = new ArrayList();


              ArrayList ruoliDirty = new ArrayList();
              ArrayList ruoliDeleted = new ArrayList();
              ArrayList ruoliNew = new ArrayList();


              ArrayList utentiDirty = new ArrayList();
              ArrayList utentiDeleted = new ArrayList();
              ArrayList utentiNew = new ArrayList();

                foreach (AbstractDbCommand elem in list)
	            {
        		      if( elem.GetObjectType().Name == "Role" && elem is DBInsertCommand ) 
                      {
                            ruoliNew.Add(elem);
                      }

                      if(  elem.GetObjectType().Name == "Role" && elem is DBUpdateCommand ) 
                      {
                        ruoliDirty.Add(elem);
                      }

                      if( elem.GetObjectType().Name == "Role" && elem is DBDeleteCommand ) 
                      {
                        ruoliDeleted.Add(elem);
                      }

                      if(  elem.GetObjectType().Name == "User" && elem is DBInsertCommand ) 
                      {
                        utentiNew.Add(elem);
                      }

                      if(  elem.GetObjectType().Name == "User" && elem is DBUpdateCommand ) 
                      {
                        utentiDirty.Add(elem);
                      }

                      if(  elem.GetObjectType().Name == "User" && elem is DBDeleteCommand ) 
                      {
                        utentiDeleted.Add(elem);
                      }

                      if(  elem.GetObjectType().Name == "RoleProfile" && elem is DBInsertCommand ) 
                      {
                        rpNew.Add(elem);
                      }

                      if(  elem.GetObjectType().Name == "RoleProfile" && elem is DBDeleteCommand ) 
                      {
                        rpDeleted.Add(elem);
                      }


                      if(  elem.GetObjectType().Name == "Profile" && elem is DBInsertCommand ) 
                      {
                        profiliNew.Add(elem);
                      }

                      if(  elem.GetObjectType().Name == "Profile" && elem is DBUpdateCommand ) 
                      {
                        profiliDirty.Add(elem);
                      }

                      if(  elem.GetObjectType().Name == "Profile" && elem is DBDeleteCommand ) 
                      {
                        profiliDeleted.Add(elem);
                      }



                      if(  elem.GetObjectType().Name == "Permission" && elem is DBInsertCommand ) 
                      {
                        permessiNew.Add(elem);
                      }

                      if(  elem.GetObjectType().Name == "Permission" && elem is DBUpdateCommand ) 
                      {
                        permessiDirty.Add(elem);
                      }

                      if (elem.GetObjectType().Name == "Permission" && elem is DBDeleteCommand)
                      {
                        permessiDeleted.Add(elem);
                      }
	             }


                foreach (AbstractDbCommand elem in ruoliNew)
                {
                    result.Add(elem);
                }
                foreach (AbstractDbCommand elem in utentiNew)
                {
                    result.Add(elem);
                }
                foreach (AbstractDbCommand elem in rpNew)
                {
                    result.Add(elem);
                }
                foreach (AbstractDbCommand elem in profiliNew)
                {
                    result.Add(elem);
                }
                foreach (AbstractDbCommand elem in permessiNew)
                {
                    result.Add(elem);
                }


                foreach (AbstractDbCommand elem in ruoliDirty)
                {
                    result.Add(elem);
                }
                foreach (AbstractDbCommand elem in utentiDirty)
                {
                    result.Add(elem);
                }
                foreach (AbstractDbCommand elem in profiliDirty)
                {
                    result.Add(elem);
                }
                foreach (AbstractDbCommand elem in permessiDirty)
                {
                    result.Add(elem);
                }



                foreach (AbstractDbCommand elem in ruoliDeleted)
                {
                    result.Add(elem);
                }
                foreach (AbstractDbCommand elem in utentiDeleted)
                {
                    result.Add(elem);
                }
                foreach (AbstractDbCommand elem in rpDeleted)
                {
                    result.Add(elem);
                }
                foreach (AbstractDbCommand elem in profiliDeleted)
                {
                    result.Add(elem);
                }
                foreach (AbstractDbCommand elem in permessiDeleted)
                {
                    result.Add(elem);
                }

                return result;
        }

        #endregion
    }
}
