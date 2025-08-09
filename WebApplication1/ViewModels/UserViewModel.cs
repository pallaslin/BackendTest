using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.ViewModels
{
    public class UserViewModel
    {

        /// <summary>
        /// 中文名稱
        /// </summary>
        [MaxLength(60,ErrorMessage = "長度不可超過60個字")]
        [Display(Name = "中文名稱")]
        public string CName { get; set; }

        /// <summary>
        /// 英文名稱
        /// </summary>
        [MaxLength(40, ErrorMessage = "長度不可超過40個字")]
        [Display(Name = "英文名稱")]
        public string EName { get; set; }

        /// <summary>
        /// 簡稱
        /// </summary>
        [MaxLength(40, ErrorMessage = "長度不可超過40個字")]
        [Display(Name = "簡稱")]
        public string SName { get; set; }

        /// <summary>
        /// 使用者信箱
        /// </summary>
        [MaxLength(60, ErrorMessage = "長度不可超過60個字")]
        [Display(Name = "使用者信箱")]
        public string EMail { get; set; }

        /// <summary>
        /// 狀況
        /// </summary>
        [Display(Name = "狀況")]
        public byte? Status { get; set; }

        /// <summary>
        /// 停用否
        /// </summary>
        [Display(Name = "是否停用/不可登入")]
        public bool? IsStop { get; set; }

        [MaxLength(60, ErrorMessage = "長度不可超過60個字")]
        [Display(Name = "停用原因")]
        [AllowNull]
        public string? StopMemo { get; set; }

        /// <summary>
        /// 登入帳號
        /// </summary>
        [MaxLength(30, ErrorMessage = "長度不可超過30個字")]
        [Display(Name = "登入帳號")]
        public string Account { get; set; }

        /// <summary>
        /// 登入密碼
        /// </summary>
        [MaxLength(60, ErrorMessage = "長度不可超過60個字")]
        [Display(Name = "登入密碼")]
        public string AccountPwd { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Display(Name = "備註")]
        [MaxLength(120, ErrorMessage = "長度不可超過120個字")]
        [AllowNull]
        public string? Memo { get; set; }
    }

    public class UserListViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// 中文名稱
        /// </summary>
        [MaxLength(60, ErrorMessage = "長度不可超過60個字")]
        [Display(Name = "中文名稱")]
        public string CName { get; set; }

        /// <summary>
        /// 英文名稱
        /// </summary>
        [MaxLength(40, ErrorMessage = "長度不可超過40個字")]
        [Display(Name = "英文名稱")]
        public string EName { get; set; }

        /// <summary>
        /// 狀況
        /// </summary>
        [Display(Name = "狀況")]
        public byte? Status { get; set; }
    }

    public class ModifyUserViewModel
    {
        public string Sid { get; set; }
        /// <summary>
        /// 中文名稱
        /// </summary>
        [MaxLength(60, ErrorMessage = "長度不可超過60個字")]
        [Display(Name = "中文名稱")]
        public string CName { get; set; }

        /// <summary>
        /// 英文名稱
        /// </summary>
        [MaxLength(40, ErrorMessage = "長度不可超過40個字")]
        [Display(Name = "英文名稱")]
        public string EName { get; set; }

        /// <summary>
        /// 簡稱
        /// </summary>
        [MaxLength(40, ErrorMessage = "長度不可超過40個字")]
        [Display(Name = "簡稱")]
        public string SName { get; set; }

        /// <summary>
        /// 使用者信箱
        /// </summary>
        [MaxLength(60, ErrorMessage = "長度不可超過60個字")]
        [Display(Name = "使用者信箱")]
        public string EMail { get; set; }

        /// <summary>
        /// 狀況
        /// </summary>
        [Display(Name = "狀況")]
        public byte? Status { get; set; }

        /// <summary>
        /// 停用否
        /// </summary>
        [Display(Name = "是否停用/不可登入")]
        public bool? IsStop { get; set; }

        [MaxLength(60, ErrorMessage = "長度不可超過60個字")]
        [Display(Name = "停用原因")]
        [AllowNull]
        public string? StopMemo { get; set; }

        /// <summary>
        /// 登入帳號
        /// </summary>
        [MaxLength(30, ErrorMessage = "長度不可超過30個字")]
        [Display(Name = "登入帳號")]
        public string Account { get; set; }

        /// <summary>
        /// 登入密碼
        /// </summary>
        [MaxLength(60, ErrorMessage = "長度不可超過60個字")]
        [Display(Name = "登入密碼")]
        public string AccountPwd { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Display(Name = "備註")]
        [MaxLength(120, ErrorMessage = "長度不可超過120個字")]
        [AllowNull]
        public string? Memo { get; set; }
    }

}
