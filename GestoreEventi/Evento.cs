using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Evento
    {
        private string titolo;
        private DateTime data;
        private int postiTot;
        private int prenotazioni;

        public Evento(int postiTot, string titolo, DateTime data)
        {
            if (postiTot > 0)
            {
                this.postiTot = postiTot;
            }
            else
            {
                throw new NotValidNumberException("I posti non possono esseri minori o uguali a 0");
            }
            Titolo = titolo;
            Data = data;
            this.prenotazioni = 0;
        }

        public string Titolo
        {
            get
            {
                return this.titolo;
            }
            set
            {
                if (value != "")
                {
                    this.titolo = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
        public DateTime Data
        {
            get
            {
                return this.data;
            }
            set
            {
                if (DateTime.Compare(value, DateTime.Today) >= 0)
                {
                    this.data = value;
                }
                else
                {
                    throw new NotValidDateException("La data è già passata");
                }
            }
        }
        public int PostiTotali
        {
            get
            {
                return this.postiTot;
            }
        }
        public int Prenotazioni
        {
            get
            {
                return this.prenotazioni;
            }
        }

        public void PrenotaPosti(int n)
        {
            int postiDisponibili = PostiTotali - Prenotazioni;
            if (DateTime.Compare(this.data, DateTime.Today) < 0)
            {
                throw new NotValidDateException("La data è già passata");
            }
            else if (n > postiDisponibili)
            {
                throw new Exception("Non ci sono posti disponibili");
            } else
            {
                this.prenotazioni += n;
            }
        }

        public void DisdiciPosti(int n)
        {
            if (DateTime.Compare(this.data, DateTime.Today) < 0)
            {
                throw new NotValidDateException("La data è già passata");
            } else if (n > PostiTotali)
            {
                throw new Exception("Non ci sono posti da disdire sufficienti");
            } else
            {
                this.prenotazioni -= n;
            }
        }

        public override string ToString()
        {
            return $"{Data.ToString("dd/MM/yyyy")} - {Titolo}";
        }
    }

    [Serializable]
    internal class NotValidNumberException : Exception
    {
        public NotValidNumberException()
        {
        }

        public NotValidNumberException(string? message) : base(message)
        {
        }

        public NotValidNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotValidNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class NotValidDateException : Exception
    {
        public NotValidDateException()
        {
        }

        public NotValidDateException(string? message) : base(message)
        {
        }

        public NotValidDateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotValidDateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
