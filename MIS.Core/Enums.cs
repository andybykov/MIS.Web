namespace MIS.Core
{
    // Роли
    public enum UserRole
    {
        Client = 0,
        Doctor = 1,
        Admin = 2
    }
    // Пол
    public enum Gender
    {
        Male = 0,
        Female = 1,
        Unknown = 2
    }
    public enum OrderStatus
    {
        New,
        Completed,
        Cancelled
    }
}
