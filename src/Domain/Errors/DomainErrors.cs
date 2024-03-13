using SharedKernel;

namespace Domain.Errors;

public static class DomainErrors
{
    public static class User
    {
        public static readonly Error EmailAlreadyInUse = new(
            "Member.EmailAlreadyInUse",
            "The specified email is already in use");

        public static readonly Func<Guid, Error> NotFound = id => new Error(
            "Member.NotFound",
            $"The member with the identifier {id} was not found.");
    }

    public static class Client
    {
        public static readonly Error RutAlreadyInUse = new(
            "Client.RutAlreadyInUse",
            "The specified rut is already in use");

        public static readonly Func<Guid, Error> NotFound = id => new Error(
            "Client.NotFound",
            $"The client with the identifier {id} was not found.");
    }

    public static class UserName
    {
 
        public static readonly Error InvalidFormat = new(
            "RUN.InvalidFormat",
            "RUN format is invalid");
        public static readonly Error Empty = new(
            "RUN.Empty",
            "RUN is empty");
        public static readonly Error RutInvalid = new(
           "RUN.RunInvalid",
           "RUN is invalid");
    }

    public static class RUT
    {

        public static readonly Error InvalidFormat = new(
            "Rut.InvalidFormat",
            "Rut format is invalid");
        public static readonly Error Empty = new(
            "Rut.Empty",
            "Rut is empty");
        public static readonly Error RutInvalid = new(
           "Rut.RutInvalid",
           "Rut is invalid");
    }

    public static class Email
    {
        public static readonly Error Empty = new(
            "Email.Empty",
            "Email is empty");

        public static readonly Error InvalidFormat = new(
            "Email.InvalidFormat",
            "Email format is invalid");
    }

    public static class FirstName
    {
        public static readonly Error Empty = new(
            "FirstName.Empty",
            "First name is empty");

        public static readonly Error TooLong = new(
            "LastName.TooLong",
            "FirstName name is too long");
    }

    public static class LastName
    {
        public static readonly Error Empty = new(
            "LastName.Empty",
            "Last name is empty");

        public static readonly Error TooLong = new(
            "LastName.TooLong",
            "Last name is too long");
    }

    public static class Transaction
    {
        public static readonly Error BadFormat = new(
            "Trasanction.BadFormtat",
            "The Transaction Id is in bad format");

        public static readonly Error Empty = new(
            "TransactionId.Empty",
            "Transaction Id is empty");

        public static readonly Func<string, Error> NotFound = id => new Error(
            "Transaction.NotFound",
            $"The Transaction with the identifier {id} was not found.");
    }
}
