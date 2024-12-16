namespace FitnessTrackingApp.Common;

public static class GeneralApplicationConstants
{
    //Areas
    public const string AdminAreaName = "Admin";
    public const string TrainerAreaName = "Trainer";

    //Roles
    public const string AdminRoleName = "Administrator";
    public const string TrainerRoleName = "Trainer";
    public const string CustomerRoleName = "Customer";

    //Seed UserIDs
    public const string CustomerId = "998CD43D-18C0-45A1-8945-AD10A045879C";
    public const string AdminId = "93A51770-AD3D-4D2C-8EC9-87D500D1B713";
    public static readonly string[] TrainerIds = [
        "417ae2a4-ffbb-4e27-855e-d353004e0e91", 
        "e61ce637-3ba1-44a2-8c05-b7c0595c3e5b", 
        "cba94579-9df9-4cda-bf3e-ff5f51048d4b", 
        "90162da5-8408-493a-8dae-99995094cf09", 
        "b0209e85-b41c-472b-a767-037253b72665"];

    // Weekly Plans Pagination
    public const int PlansPerPage = 5;
    public const int StartPage = 1;
}