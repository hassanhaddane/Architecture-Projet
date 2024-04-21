// Namespace definition for holding constants specific to the GestionHotel API.
namespace GestionHotel.Apis.Constants
{
    // A static class that contains enums. 'Class' could be renamed for better clarity, e.g., 'BookingConstants'.
    public static class Class
    {
        // Enum for defining payment methods available within the hotel management system.
        public enum PaymentMethod
        {
            None = 0,        // Represents no payment method selected.
            CreditCard = 1,  // Payment via credit card.
            Cash = 2,        // Payment in cash.
            PayPal = 3,      // Payment through PayPal.
            Stripe = 4       // Payment via Stripe (online payment service).
        }

        // Enum for tracking the status of payments.
        public enum PaymentStatus
        {
            Pending = 0,  // Payment has been initiated but not completed.
            Paid = 1      // Payment has been completed successfully.
        }

        // Enum for managing the status of cancellation requests.
        public enum CancellationStatus
        {
            Pending = 0,   // Cancellation request is pending and has not been processed yet.
            Approved = 1,  // Cancellation request has been approved.
            Rejected = 2,  // Cancellation request has been rejected.
            Cancelled = 3, // Booking is officially cancelled.
            Refunded = 4   // Funds have been returned post-cancellation.
        }

        // Enum for describing the current status of a hotel room.
        public enum RoomStatus
        {
            Free = 0,         // Room is available for booking.
            Occupied = 1,     // Room is currently occupied by guests.
            Unavailable = 2,  // Room is not available for booking (e.g., due to maintenance).
        }
    }
}