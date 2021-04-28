namespace Interview_Project.Controllers
{
    public static class EmployeeConstraint
    {
        public const string EmpIdPattern = @"[A-Z][A-Z][A-Z][1-9][0-9][0-9][0-9][0-9][FM]|[A-Z]-[A-Z][1-9][0-9][0-9][0-9][0-9][FM]";
        public const short JobIdDefaultValue = 1;
        public const byte JobLvlDefaultValue = 10;
    }
}