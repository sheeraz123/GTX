using Common.Miscellaneous.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.UserMaster.GetUsersList
{
    public class GetUserVm:BaseResponse
    {
        public int TotalRecords { get; set; }
        public IReadOnlyList<GetUserDetailsVm> UserDetails { get; set; }
    }
    public class GetUserDetailsVm
    {
        public decimal Id { get; set; }
        public decimal UserTypeId { get; set; }
        public string? UserType { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public decimal Mobile { get; set; }
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
