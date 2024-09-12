using System.ComponentModel.DataAnnotations;

namespace UTC_ASP.NET_Web_Lab.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ảnh bắt buộc phải được chọn")]
        public IFormFile? ProfileImage { get; set; }
        public string? ProfileImagePath { get; set; }

        [Required(ErrorMessage = "Họ tên bắt buộc phải được nhập")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải có độ dài từ 4 đến 100 ký tự.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        [RegularExpression(
            @"[A-Za-z0-9._%+-]+@gmail.com",
            ErrorMessage = "Địa chỉ email phải có đuôi gmail.com"
        )]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu bắt buộc phải được nhập")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
            ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, chữ số và ký tự đặc biệt.")
        ]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Ngành học bắt buộc phải được chọn")]
        public Branch? Branch { get; set; }

        [Required(ErrorMessage = "Giới tính bắt buộc phải được chọn")]
        public Gender? Gender { get; set; }
        public bool IsRegular { get; set; }

        [Required(ErrorMessage = "Địa chỉ bắt buộc phải được nhập")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Ngày sinh bắt buộc phải được nhập")]
        [DataType(DataType.Date)]
        [Range(
            typeof(DateTime), "1/1/1963", "31/12/2005",
            ErrorMessage = "Ngày sinh phải nằm trong khoảng 1/1/1963 đến 31/12/2005"
        )]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Điểm là bắt buộc")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Điểm phải là một số hợp lệ")]
        public string? Score { get; set; }
    }
}
