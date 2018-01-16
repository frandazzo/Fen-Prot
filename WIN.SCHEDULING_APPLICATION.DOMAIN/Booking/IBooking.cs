using System;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Booking
{
    public interface IBooking
    {
        System.Collections.IList Assignments { get; set; }
        DateTime Date { get; set; }
        string Notes { get; set; }
        string Notes1 { get; set; }
        BookingType BookingType { get; set; }
        int Id { get; }
        void AddAssignment(Assignment assignment);
        //bool CanBeAssignementAdded(DateTime start, DateTime end, BookingResource resource);
        void RemoveAssignment(Assignment assignment);
        AbstractPersistenceObject BaseObject { get; }

        Operator Operator { get; set; }
        int Color { get; set; }
        bool ColorBookings { get; set; }
        bool Confirmed { get; }
        void ConfirmBooking();
        void UnConfirmBooking();

        BookingPayment Payment { get; set; }
        BookingState State { get; }


        void SetStayTax(float tax);
        void SetTotal(float total);
        void SetAccount(DateTime date, float account, PaymentType type);
        void SetRestOfTypePayment(DateTime date, float restOfPayment, PaymentType type);





     
    }

    public enum BookingState
    {
        NotConfirmed,
        ConfirmedWithAccont,
        ConfimedWithoutAccount,
        Closed

    }

}
