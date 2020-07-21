namespace ACT.ViewModel
{
    public class UnitUserJoinUserModel
    {
        public decimal? Id { get; set; }

        public decimal? UnitId { get; set; }
        public decimal UserId { get; set; }

        public bool IsResponsible { get; set; }

        public string FullName { get; set; }

        public string UnitName { get; set; }
    }
}