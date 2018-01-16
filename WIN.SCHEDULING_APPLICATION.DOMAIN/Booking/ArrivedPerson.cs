using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Booking
{
    public class ArrivedPerson
    {
        private Checkin _checkin;

        public ArrivedPerson(Checkin checkin)
        {
            if (checkin == null)
                throw new ArgumentException("Checkin nullo");
            _checkin = checkin;
        }

        public string Stanza
        {
            get
            {
                return _checkin.Assignment.Resource.Descrizione;
            }
        }


        public string NomeCliente
        {
            get
            {
                return _checkin.Customer.Nome;
            }
        }


        public string CognomeCliente
        {
            get
            {
                return _checkin.Customer.Cognome;
            }
        }

        public DateTime? DataNascitaCliente
        {
            get
            {
                if (_checkin.Customer.DataNascita == DateTime.MinValue)
                    return null;
                return _checkin.Customer.DataNascita;
            }
        }


        public string NazionalitaCliente
        {
            get
            {
                return _checkin.Customer.Nazionalita.Descrizione;
            }
        }


        public string ProvinciaNascitaCliente
        {
            get
            {
                return _checkin.Customer.ProvinciaNascita.Descrizione ;
            }
        }
        public string ProvinciaNascitaSigla
        {
            get
            {
                return _checkin.Customer.ProvinciaNascita.Sigla;
            }
        }


        public string ComuneNascitaCliente
        {
            get
            {
                return _checkin.Customer.ComuneNascita.Descrizione;
            }
        }


        public string NazioneCliente
        {
            get
            {
                return _checkin.Customer.Residenza.Nazione.Descrizione;
            }
        }

        public string ProvinciaCliente
        {
            get
            {
                return _checkin.Customer.Residenza.Provincia.Descrizione;
            }
        }

        public string ComuneCliente
        {
            get
            {
                return _checkin.Customer.Residenza.Comune.Descrizione;
            }
        }

        public string IndirizzoCliente
        {
            get
            {
                return _checkin.Customer.Residenza.Via;
            }
        }

        public string CapCliente
        {
            get
            {
                return _checkin.Customer.Residenza.Cap;
            }
        }

        public string Cellulare1Cliente
        {
            get
            {
                return _checkin.Customer.Comunicazione.Cellulare1;
            }
        }

        public string Cellulare2Cliente
        {
            get
            {
                return _checkin.Customer.Comunicazione.Cellulare2;
            }
        }

        public string TelefonoCliente
        {
            get
            {
                return _checkin.Customer.Comunicazione.TelefonoUfficio;
            }
        }


        public string FaxCliente
        {
            get
            {
                return _checkin.Customer.Comunicazione.Fax;
            }
        }

        public string MailCliente
        {
            get
            {
                return _checkin.Customer.Comunicazione.Mail;
            }
        }

        public string TipoDocumentoCliente
        {
            get
            {
                return _checkin.Customer.Marca;
            }
        }


        public string NumeroDocumentoCliente
        {
            get
            {
                return _checkin.Customer.Modello;
            }
        }

        public string LuogoRilascioDocumentoCliente
        {
            get
            {
                return _checkin.Customer.Matricola;
            }
        }

        public string NoteCliente
        {
            get
            {
                return _checkin.Customer.Note;
            }
        }

        public string CodiceFiscaleCliente
        {
            get
            {
                return _checkin.Customer.CodiceFiscale;
            }
        }

        public string SessoCliente
        {
            get
            {
                if (_checkin.Customer.Sesso == BASEREUSE.AbstractPersona.Sex.Maschio)
                    return "M";
                return "F";
            }
        }
        
    }
}
